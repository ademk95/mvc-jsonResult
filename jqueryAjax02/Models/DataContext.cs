using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace jqueryAjax02.Models
{
    public class DataContext:DbContext
    {
        public DataContext()
            : base("name=DataContext2")
        {
        }

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
    }
}