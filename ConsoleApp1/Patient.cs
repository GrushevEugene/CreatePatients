using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public partial class Patient
    {
        public Guid Id { get; set; }
        public Name? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public bool? Active { get; set; }
        public Guid? NameId { get; set; }
    }

    public partial class Name
    {
        public Guid Id { get; set; }
        public string? Use { get; set; }
        public string? Family { get; set; }
        public string[]? Given { get; set; }
    }
}
