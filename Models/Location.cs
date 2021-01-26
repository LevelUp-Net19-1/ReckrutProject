using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq.Mapping;

namespace Rekrut.Models
{
    [Table(Name = "Locations")]
    public class Location
    {
        #region ===--- Data ---===

        [Column(IsPrimaryKey = true)]
        public long IdLocation { get; set; }
        [Column]
        public string Name { get; set; }

        #endregion
    }
}