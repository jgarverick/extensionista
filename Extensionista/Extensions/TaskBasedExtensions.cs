using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using System.Collections.Concurrent;

namespace Extensionista
{
    public static class TaskBasedExtensions
    {

        /// <summary>
        /// Executes a specified function on a collection via a BlockingCollection.
        /// </summary>
        /// <typeparam name="S">The type of source objects.</typeparam>
        /// <typeparam name="T">The type of return objects.</typeparam>
        /// <param name="objects">The collection using the extension method.</param>
        /// <param name="action">The function to execute.</param>
        /// <param name="limit">Optional. The upper limit of items to add to the collection 
        /// before blocking additional items.</param>
        /// <returns></returns>
        public static List<T> RunTaskBlocking<S,T>(this List<S> objects, Func<S,T> action, int limit = 0) 
        {
            BlockingCollection<S> collection = new BlockingCollection<S>();
            if (limit > 0) collection = new BlockingCollection<S>(limit);
            List<T> retval = new List<T>();
            Task producer = Task.Factory.StartNew(() =>
            {
                objects.ForEach(o => collection.Add(o));
                collection.CompleteAdding();
            });
            Task consumer = Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true)
                        retval.Add(action(collection.Take()));
                }
                catch (InvalidOperationException e)
                {
                    // Intentionally do nothing
                }
            });

            Task.WaitAll(producer, consumer);
            return retval;
        }
        /// <summary>
        /// Executes an action on a list of objects using Tasks.
        /// </summary>
        /// <typeparam name="T">The type of objects in the collection, and the type of object
        /// expected by the action.</typeparam>
        /// <param name="objects">The collection using the extension method.</param>
        /// <param name="action">The action or anonymous code block to execute.</param>
        public static void RunTaskAsync<T>(this List<T> objects, Action<T> action)
        {
            objects.ForEach(o =>
            {
                Task task = new Task(
                    () => action(o));
                task.Start();
            });
           
        }
        /// <summary>
        /// Executes an action on a list of objects utilizing Parallel loops and Tasks.
        /// </summary>
        /// <typeparam name="T">The type of objects in the collection, and the type of object
        /// expected by the action.</typeparam>
        /// <param name="objects">The collection using the extension method.</param>
        /// <param name="action">The action or anonymous code block to execute.</param>
        public static void RunTaskParallel<T>(this List<T> objects, Action<T> action)
        {
            Task task = Task.Factory.StartNew(() => Parallel.ForEach(objects, action));
            Task.WaitAll(task);
        }
    }
}
