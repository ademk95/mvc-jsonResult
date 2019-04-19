using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jqueryAjax02.Models
{
    public class Kisi
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Not { get; set; }
    }
}