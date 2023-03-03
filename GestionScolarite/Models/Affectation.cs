using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolarite.Models
{
    public class Affectation
    {
        [Key]
        public int Id { get; set; }
        public int MatiereId { get; set; }
        public int EnseignantId { get; set; }
        public bool selectedOptions { get; set; }
        public List<Matiere> Options { get; set; }
    }
}