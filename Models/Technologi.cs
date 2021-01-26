using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq.Mapping;

namespace Rekrut.Models
{
    [Table(Name ="Technologies")]
    public class Technologi
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)] 
        public long IdTech { get; set; }
        [Column] 
        public string Name { get; set; }
        [Column] 
        public string Discription { get; set; }
    }
}