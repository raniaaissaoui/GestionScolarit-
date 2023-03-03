using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarite.Models
{
    public class Matiere
    {
        public int MatiereId { get; set; }
        public string Name { get; set; }
        public string coeff { get; set; }
        public string Assignation { get; set; } = "Not Assigned";
    }
}