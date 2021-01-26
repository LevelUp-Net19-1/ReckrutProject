using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrut.Models
{
    interface IRekrutDatabase
    {
        #region ===--- Properties ---===

        Vacancy Vacancy { get; }
        Resume Resume { get; }

        #endregion

        #region ===--- Technologies ---===

        IEnumerable<Technologi> GetTechnologies();
        Technologi GetTechnologiById(long id);
        Technologi AddNewTechnologi(Technologi data);
        Technologi GetTechnologiByName(string name);

        #endregion

        #region ===--- Skills ---===

        IEnumerable<Skill> GetSkills();
        Skill GetSkillById(long id);
        Skill AddNewSkill(Skill data);
        Skill GetSkillByName(string name);

        #endregion

        #region ===--- Accounts ---===

        IEnumerable<Account> GetAccounts();
        IEnumerable<Account> GetAccountsByType(byte type);
        Account GetAccountByEmail(string email);
        void AddAccount(Account acc);
        void UpdateAccount(Account accOld, Account accNew);
        void DeleteAccount(string email);

        #endregion

        #region ===--- Resumes ---===

        IEnumerable<Resume> GetResumes();
        IEnumerable<Resume> GetResumesByEmail(string email);
        IEnumerable<Resume> GetResumesByLocation(int idLoc);
        IEnumerable<Resume> GetResumesByPosition(string position);
        IEnumerable<Resume> GetByMinToMaxSalary(decimal min, decimal max);
        Resume GetResumeById(long id);
        void AddResume(Resume addResume);
        void UpdateResume(Resume resOld, Resume resNew);
        void DeleteResume(long id);

        #endregion

        #region ===--- Locations ---===

        Location GetLocationById(int id);
        IEnumerable<Location> GetAllLocations();
        Location GetLocationByName(string name);
        void SaveLocation(Location loc);
        void DeleteLocation(int id);

        #endregion

        #region ===--- Vacancies ---===

        IEnumerable<Vacancy> GetAllVacancy();
        Vacancy GetVacancyById(int id);
        IEnumerable<Vacancy> GetVacancyByLocation(string name);
        IEnumerable<Vacancy> GetVacancyBySalary(decimal money);
        IEnumerable<Vacancy> GetVacancyByPosition(string pos);
        Vacancy SaveVacancy(Vacancy vac);
        void DeleteVacancy(int idVacancy);

        #endregion

        #region ===--- SkillsResumes ---===

        IQueryable<SkillResume> GetAllSkillResumeByIdRes(long idRes);
        void AddSkillToResume(SkillResume newSkillResume);
        SkillResume GetSkillResume(long idSkill, long idResume);
        IEnumerable<SkillResume> GetAllSkillResume();

        #endregion

        #region ===--- SkillsVacancies ---===

        void AddSkillToVacancy(SkillVacancy newSkillVacancy);
        SkillVacancy GetSkillVacancy(long idSkill, long idVacancy);
        IEnumerable<SkillVacancy> GetAllSkillVacancy();
        IQueryable<SkillVacancy> GetAllSkillVavancyByIDVac(int idVac);

        #endregion
    }
}
