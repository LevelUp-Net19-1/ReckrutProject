using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Rekrut.Models
{
    [Table(Name = "Accounts")]
    public class Account
    {
        #region ===--- Data ---===

        [Column(IsPrimaryKey = true)]
        public string Email { get; set; }
        [Column]
        public byte AccountType { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Surname { get; set; }
        [Column]
        public string ImageLink { get; set; }
        [Column]
        public byte IsDeleted { get; set; }

        #endregion
    }
}