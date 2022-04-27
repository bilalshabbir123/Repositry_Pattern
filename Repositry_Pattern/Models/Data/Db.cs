using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repositry_Pattern.Models.Data
{
    public class Db:DbContext
    {
        public DbSet<BookDTO> Books { get; set; }
    }
}