using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transfer.Models
{
    public class Command
    {
        [Key]
        public int Dbnm { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string desc { get; set; }
        public int? atk { get; set; }
        public int? def { get; set; }
        public int? level { get; set; }
        [Required]
        public string race { get; set; }
        public string attribute { get; set; }
        public int? scale { get; set; }
        public int? linkval { get; set; }
    }
}
 