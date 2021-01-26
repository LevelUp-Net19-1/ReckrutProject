using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq.Mapping;

namespace Rekrut.Models
{
    [Table(Name = "Vacancies")]
    public class Vacancy
    {
        [Column(IsPrimaryKey =true, CanBeNull = false, DbType = "bigint identity", IsDbGenerated = true)]
        public int IdVacancy { get; set; }
        
        [Column(CanBeNull = false, DbType = "char (50) not null")]
        public string Email { get; set; }
        
        [Column(CanBeNull = false, DbType = "bigint not null")]
        public int IdLocation { get; set; }

        [Column(CanBeNull = false, DbType = "char (50) not null")]
        public string Position { get; set; }
        
        [Column(CanBeNull = true, DbType = "money null")]
        public decimal Salary { get; set; }

        [Column(CanBeNull = true, DbType = "nvarchar(2048) null")]
        public string ProjectAbout { get; set; }

        //IdLocation bigint               not null,
        //Position char (50)             not null,
        //Salary money                null,
        //ProjectAbout         nvarchar(2048)       null,
        //constraint PK_VACANCY primary key(IdVacancy)
    }
}