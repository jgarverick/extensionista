using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Extensionista.TestCases
{
    public class SampleValidationClass
    {
        [Required]
        public int RecordID { get; set; }
        [Required]
        [StringLength(25,MinimumLength=4)]
        public string RecordName { get; set; }

    }
}
