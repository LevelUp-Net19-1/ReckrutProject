using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq.Mapping;

namespace Rekrut.Models
{
    [Table(Name = "Skills_Resumes")]
    public class SkillResume
    {
        #region ===--- Data ---===

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long ID { get; set; }
        [Column]
        public long IdSkill { get; set; }
        [Column]
        public long IdResume { get; set; }
        [Column]
        public byte Level { get; set; }
        [Column]
        public byte Experience { get; set; }

        #endregion
    }
}