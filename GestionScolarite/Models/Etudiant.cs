using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolarite.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }
        public int Account { get; set; } = -1;
        public string Name { get; set; } = "";
        public string Section { get; set; } = "";
       
        public Etudiant() { }

        public Etudiant(int account,string name)
        {
            Account = account;
            Name = name;
        }
    }
}