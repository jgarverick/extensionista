using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Extensionista
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Extension method that finds types which implement an interface.
        /// </summary>
        /// <typeparam name="T">An interface of type T.</typeparam>
        /// <param name="asm">The assembly that will utilize the extension method.</param>
        /// <returns>An array of System.Type containing any types within the assembly
        /// that implement the interface specified by T.</returns>
        public static Type[] Implements<T>(this Assembly asm)
        {
            List<Type> types = new List<Type>();
            asm.GetTypes().ToList().ForEach(type =>
            {
                if (type.Implements<T>())
                    types.Add(type);
            });
            return types.ToArray();
        }
        /// <summary>
        /// Extension method that determines whether or not a type implements an interface.
        /// </summary>
        /// <typeparam name="T">An interface of type T.</typeparam>
        /// <param name="type">The type that will utilize the extension method.</param>
        /// <returns>True if the type implements T; false if it does not, or if T is
        /// not an interface.</returns>
        public static bool Implements<T>(this Type type)
        {
            if (typeof(T).IsInterface)
                return type.GetInterface(typeof(T).Name) != null;
            else
                return false;
        }

        /// <summary>
        /// Extension method used to find any types within an assembly that use a
        /// particular attribute.
        /// </summary>
        /// <typeparam name="T">An attribute class to search for.</typeparam>
        /// <param name="asm">The assembly that will utilize the extension method.</param>
        /// <returns>An array of System.Type containing any types that use the 
        /// attribute class T.</returns>
        public static Type[] AttributedWith<T>(this Assembly asm)
        {
            List<Type> types = new List<Type>();
            asm.GetTypes().ToList().ForEach(type =>
            {
                if (type.AttributedWith<T>())
                    types.Add(type);
            });
            return types.ToArray();
        }
        /// <summary>
        /// Extension method that determines whether or not a type contains a specific attribute.
        /// </summary>
        /// <typeparam name="T">An attribute class to search for.</typeparam>
        /// <param name="type">The type that will utilize the extension method.</param>
        /// <returns>True if the type is decorated with the attribute specified by T;
        /// false if it does not, or if T is not an attribute.</returns>
        public static bool AttributedWith<T>(this Type type)
        {
            if (typeof(Attribute).IsAssignableFrom(typeof(T)))
                return type.GetCustomAttributes(typeof(T), true).Any();
            else
                return false;
        }
        /// <summary>
        /// Extension method that determines whether or not an array of MemberInfo objects contains a specific attribute.
        /// </summary>
        /// <typeparam name="T">An attribute class to search for.</typeparam>
        /// <param name="type">The type that will utilize the extension method.</param>
        /// <returns>True if any MemberInfo is decorated with the attribute specified by T;
        /// false if it does not, or if T is not an attribute.</returns>
        public static bool AttributedWith<T>(this MemberInfo[] members)
        {
            if (typeof(Attribute).IsAssignableFrom(typeof(T)))
                return members.Where(x => x.AttributedWith<T>()).Any();
            else
                return false;
        }
        /// <summary>
        /// Extension method that determines whether or not a collection of MemberInfo objects contains a specific attribute.
        /// </summary>
        /// <typeparam name="T">An attribute class to search for.</typeparam>
        /// <param name="type">The type that will utilize the extension method.</param>
        /// <returns>True if any MemberInfo is decorated with the attribute specified by T;
        /// false if it does not, or if T is not an attribute.</returns>
        public static bool AttributedWith<T>(this IEnumerable<MemberInfo> members)
        {
            if (typeof(Attribute).IsAssignableFrom(typeof(T)))
                return members.Where(x => x.AttributedWith<T>()).Any();
            else
                return false;
        }
        /// <summary>
        /// Extension method that determines whether or not a member contains a specific attribute.
        /// </summary>
        /// <typeparam name="T">An attribute class to search for.</typeparam>
        /// <param name="type">The member that will utilize the extension method (FieldInfo, MemberInfo, PropertyInfo).</param>
        /// <returns>True if the MemberInfo is decorated with the attribute specified by T;
        /// false if it does not, or if T is not an attribute.</returns>
        public static bool AttributedWith<T>(this MemberInfo type)
        {
            if (typeof(Attribute).IsAssignableFrom(typeof(T)))
                return type.GetCustomAttributes(typeof(T), true).Any();
            else
                return false;
        }
        /// <summary>
        /// Connects an event handler (or code block) to a named event.
        /// </summary>
        /// <typeparam name="T">The type of event handler.</typeparam>
        /// <param name="value">The object using the extension method.</param>
        /// <param name="eventName">The name of the event to attach the action to.</param>
        /// <param name="action">The event handler or anonymous delegate to 
        /// associate with the event handler.</param>
        public static void Hitch<T>(this object value, string eventName, T action)
        {
            EventInfo ev = value.GetType().GetEvent(eventName);
            if (!(ev == null))
            {
                if (ev.EventHandlerType.IsAssignableFrom(typeof(T)))
                    ev.AddEventHandler(value, action as System.Delegate);
            }
            else
                throw new InvalidOperationException("The event type supplied does not exist in this class.");

        }
        /// <summary>
        /// Connects a list of event handlers (or code blocks) to a named event.
        /// </summary>
        /// <typeparam name="T">The type of event handler.</typeparam>
        /// <param name="value">The object using the extension method.</param>
        /// <param name="eventName">The name of the event to attach the action to.</param>
        /// <param name="actions">The collection of event handlers or anonymous delegates to 
        /// associate with the event handler.</param>
        public static void Hitch<T>(this object value, string eventName, List<T> actions)
        {
            EventInfo ev = value.GetType().GetEvent(eventName);
            if (!(ev == null))
            {
                if (ev.EventHandlerType.IsAssignableFrom(typeof(T)))
                    actions.ForEach(a => ev.AddEventHandler(value, a as System.Delegate));
            }
            else
                throw new InvalidOperationException("The event type supplied does not exist in this class.");

        }
        /// <summary>
        /// Synchronizes properties of the same name and type between two objects.
        /// </summary>
        /// <param name="source">The object containing the properties you wish to replicate.</param>
        /// <param name="destination">The object that will receive the property values from the source.</param>
        /// <returns>An object as defined by the destination, with values in any matching properties.</returns>
        public static object SyncProperties(this object source, object destination)
        {
            source.GetType().GetProperties().ToList().ForEach(src =>
            {
                if (destination.GetType().GetProperty(src.Name) != null)
                {
                    try
                    {
                        destination.GetType().GetProperty(src.Name).SetValue(destination, src.GetValue(source, null), null);
                    }
                    catch { }
                }
            });
            return destination;
        }
        /// <summary>
        /// Extracts a single attribute from a type.
        /// </summary>
        /// <typeparam name="T">The type of attribute to look for.</typeparam>
        /// <param name="type">The type to interrogate.</param>
        /// <returns>An attribute instance of type T.</returns>
        public static T ExtractAttribute<T>(this Type type)
        {
            if (!typeof(Attribute).IsAssignableFrom(typeof(T))) 
                throw new InvalidOperationException("Cannot extract an attribute of this type as it is not derived from Attribute.");
            return (T)type.GetCustomAttributes(typeof(T), true).SingleOrDefault();
        }
        /// <summary>
        /// Extracts a single attribute from a member (method, property, field).
        /// </summary>
        /// <typeparam name="T">The type of attribute to look for.</typeparam>
        /// <param name="member">The MemberInfo object to interrogate.</param>
        /// <returns>An attribute instance of type T.</returns>
        public static T ExtractAttribute<T>(this MemberInfo member)
        {
            if (!typeof(Attribute).IsAssignableFrom(typeof(T))) throw new InvalidOperationException("Cannot extract an attribute of this type as it is not derived from Attribute.");
            return (T)member.GetCustomAttributes(typeof(T), true).SingleOrDefault();
        }
        /// <summary>
        /// Extracts attributes from a type and optionally from any members of that type.
        /// </summary>
        /// <typeparam name="T">The type of attribute to look for.</typeparam>
        /// <param name="type">The type to interrogate.</param>
        /// <param name="checkMembers">Flag that indicates whether or not to check the type's members for the attribute.</param>
        /// <returns>A list of attribute instances of type T.</returns>
        public static List<T> ExtractAttributes<T>(this Type type, bool checkMembers = false)
        {
            if (!typeof(Attribute).IsAssignableFrom(typeof(T))) 
                throw new InvalidOperationException("Cannot extract an attribute of this type as it is not derived from Attribute.");

            List<T> results = new List<T>();
            results.AddRange(type.GetCustomAttributes(typeof(T), true).Select(x => (T)x).ToList());
            if (checkMembers)
            {
                type.GetType().GetMembers().ToList().ForEach(mem =>
                {
                    results.AddRange(mem.ExtractAttributes<T>());
                });
            }

            return results;
        }
        /// <summary>
        /// Extracts attributes from a type and optionally from any members of that type.
        /// </summary>
        /// <typeparam name="T">The type of attribute to look for.</typeparam>
        /// <param name="info">The type to interrogate.</param>
        /// <param name="checkMembers">Flag that indicates whether or not to check the type's members for the attribute.</param>
        /// <returns>A list of attribute instances of type T.</returns>
        public static List<T> ExtractAttributes<T>(this MemberInfo info)
        {
            if (!typeof(Attribute).IsAssignableFrom(typeof(T)))
                throw new InvalidOperationException("Cannot extract an attribute of this type as it is not derived from Attribute.");

            List<T> results = new List<T>();
            results.AddRange(info.GetCustomAttributes(typeof(T), true).Select(x => (T)x).ToList());

            return results;
        }
    }
}
