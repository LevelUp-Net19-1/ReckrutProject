using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Rekrut.Models
{
    [Table(Name = "Resumes")]
    public class Resume
    {
        #region ===--- Data ---===

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long IdRes { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public long IdLocation { get; set; }
        [Column]
        public string Position { get; set; }
        [Column]
        public decimal Salary { get; set; }
        [Column]
        public string ResumeLink { get; set; }
        [Column]
        public byte IsDeleted { get; set; }

        #endregion
    }
}