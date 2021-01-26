using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace Rekrut.Models
{
    [Table(Name ="Skills")]
    public class Skill
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)] 
        public long IdSkill { get; set; }
        [Column] 
        public long IdTech { get; set; }
        [Column] 
        public string Name { get; set; }
    }
}