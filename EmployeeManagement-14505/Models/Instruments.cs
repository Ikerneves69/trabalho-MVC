using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementFull.Models
{
    public class Instruments
    {
        public int Id { get; set; }

        [Required] public string TypeOfInstrument { get; set; } = null!;
        [Required] public string Instrument { get; set; } = null!;
        [Required] public bool UsesStrings { get; set; }
    }
}