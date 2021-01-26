using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq.Mapping;

namespace Rekrut.Models
{
    [Table(Name = "Skills_Vacancies")]
    public class SkillVacancy
    {
        #region ===--- Data ---===

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long ID { get; set; }
        [Column]
        public long IdSkill { get; set; }
        [Column]
        public long IdVacancy { get; set; }
        [Column]
        public byte MinExperience { get; set; }
        [Column]
        public byte MaxExperience { get; set; }
        [Column]
        public byte Level { get; set; }

        #endregion
    }
}