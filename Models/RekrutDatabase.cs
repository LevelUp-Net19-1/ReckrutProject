using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

namespace Rekrut.Models
{
    class RekrutDatabase : IRekrutDatabase
    {
        #region =======------- PRIVATE DATA -------=======

        private readonly string _connectionString = "Data Source=(local);Initial Catalog=RekrutDB;Integrated Security=True";
        private DataContext _db = null;

        #endregion

        #region =======----- CTOR -----=======

        public RekrutDatabase(/*string connectionString = "Data Source= DELLVENTCONTROL\\SQLEXPRESS; Initial Catalog = Rekrut; Integrated Security = True"*/)
        {
            _db = new DataContext(_connectionString);
        }

        #endregion

        #region ====----- Properties ----=====

        public Vacancy Vacancy { get; private set; }

        public Resume Resume { get; private set; }

        #endregion

        #region ===--- GET TECHNOLOGIES ---===

        public IEnumerable<Technologi> GetTechnologies()
        {
            var queryTechnologies = from tech in _db.GetTable<Technologi>()
                                    select tech;

            return queryTechnologies;
        }

        public Technologi GetTechnologiById(long id)
        {
            var getData = from tech in _db.GetTable<Technologi>()
                          select tech;

            Technologi queryTechnologies = (from tech in getData
                                            where tech.IdTech == id
                                            select tech).FirstOrDefault();

            return queryTechnologies;
        }

        public Technologi GetTechnologiByName(string name)
        {
            var tehnologi = (from t in _db.GetTable<Technologi>()
                             where t.Name == name
                             select t).FirstOrDefault();

            return tehnologi;
        }

        #endregion

        #region ===--- ADD TECHNOLOGIES ---===

        public Technologi AddNewTechnologi(Technologi data)
        {
            _db.GetTable<Technologi>().InsertOnSubmit(data);
            _db.SubmitChanges();

            return data;
        }

        #endregion

        #region ===--- GET SKILLS ---===

        public IEnumerable<Skill> GetSkills()
        {
            var querySkills = from tech in _db.GetTable<Skill>()
                              select tech;

            return querySkills;
        }

        public Skill GetSkillById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Идентификатор не может быть меньше нуля");
            }

            var getData = from tech in _db.GetTable<Skill>()
                          select tech;

            return (from tech in getData
                    where tech.IdSkill == id
                    select tech).FirstOrDefault();
        }

        public Skill GetSkillByName(string name)
        {
            var skill = (from s in _db.GetTable<Skill>()
                         where s.Name == name
                         select s).FirstOrDefault();

            return skill;
        }

        #endregion

        #region ===--- ADD SKILLS ---===

        public Skill AddNewSkill(Skill data)
        {
            _db.GetTable<Skill>().InsertOnSubmit(data);
            _db.SubmitChanges();

            return data;
        }

        #endregion

        #region ===--- GET ACCOUNT ---===

        public IEnumerable<Account> GetAccounts()
        {
            return _db.GetTable<Account>()
                .Where(acc => acc.IsDeleted == 0);
        }

        public IEnumerable<Account> GetAccountsByType(byte type)
        {
            return _db.GetTable<Account>()
                .Where(acc => acc.AccountType == type);
        }

        public Account GetAccountByEmail(string email)
        {
            return _db.GetTable<Account>()
                .FirstOrDefault(a => a.Email == email);
        }

        #endregion

        #region ===--- ADD ACCOUNT ---===

        public void AddAccount(Account addAcc)
        {
            _db.GetTable<Account>()
                .InsertOnSubmit(addAcc);
            _db.SubmitChanges();
        }

        #endregion

        #region ===--- UPDATE ACCOUNT ---===

        public void UpdateAccount(Account accOld, Account accNew)
        {
            accOld.AccountType = accNew.AccountType;
            accOld.ImageLink = accNew.ImageLink;
            accOld.Name = accNew.Name;
            accOld.Surname = accNew.Surname;
            accOld.IsDeleted = accNew.IsDeleted;

            _db.SubmitChanges();
        }

        #endregion

        #region ===--- DELETE ACCOUNT ---===

        public void DeleteAccount(string email)
        {
            _db.GetTable<Account>()
                .FirstOrDefault(a => a.Email == email).IsDeleted = 1;
            _db.SubmitChanges();
        }

        #endregion

        #region ===--- GET RESUME ---===

        public IEnumerable<Resume> GetResumes()
        {
            return _db.GetTable<Resume>()
                .Where(acc => acc.IsDeleted == 0);
        }

        public IEnumerable<Resume> GetResumesByLocation(int idLoc)
        {
            return _db.GetTable<Resume>()
                .Where(acc => acc.IdLocation == idLoc);
        }

        public IEnumerable<Resume> GetResumesByEmail(string email)
        {
            return _db.GetTable<Resume>()
                .Where(acc => acc.Email == email);
        }

        public IEnumerable<Resume> GetResumesByPosition(string position)
        {
            return _db.GetTable<Resume>()
                .Where(acc => acc.Position == position);
        }

        public IEnumerable<Resume> GetByMinToMaxSalary(decimal min, decimal max)
        {
            return _db.GetTable<Resume>()
                .Where(acc => acc.Salary >= min && acc.Salary <= max)
                .OrderBy(s => s.Salary);
        }

        public Resume GetResumeById(long id)
        {
            return _db.GetTable<Resume>()
                .FirstOrDefault(a => a.IdRes == id);
        }

        #endregion

        #region ===--- ADD RESUME ---===

        public void AddResume(Resume addResume)
        {
            Resume = addResume;

            _db.GetTable<Resume>()
                .InsertOnSubmit(addResume);
            _db.SubmitChanges();
        }

        #endregion

        #region ===--- UPDATE RESUME ---===

        public void UpdateResume(Resume resOld, Resume resNew)
        {
            //resOld.IdLocation = resNew.IdLocation;    //TODO: можно ли тут менять
            //resOld.IsDeleted = resNew.IsDeleted;    //TODO: можно ли тут менять
            resOld.Position = resNew.Position;
            resOld.ResumeLink = resNew.ResumeLink;
            resOld.Salary = resNew.Salary;

            _db.SubmitChanges();
        }

        #endregion

        #region ===-- DELETE RESUME ---===

        public void DeleteResume(long id)
        {
            _db.GetTable<Resume>()
                .FirstOrDefault(a => a.IdRes == id).IsDeleted = 1;
            _db.SubmitChanges();
        }

        #endregion

        #region ===--- GET VACANCY ---===



        #endregion

        #region ===--- LOCATION ---===

        public IEnumerable<Location> GetAllLocations()
        {
            var result = from loc in _db.GetTable<Location>()
                         select loc;

            return result;
        }

        public Location GetLocationById(int id)
        {
            return _db.GetTable<Location>().FirstOrDefault(x => x.IdLocation == id);
        }

        public Location GetLocationByName(string name)
        {
            return _db.GetTable<Location>().FirstOrDefault(x => x.Name == name);
        }

        public void SaveLocation(Location loc)
        {
            Location item = _db.GetTable<Location>().FirstOrDefault(x => x.IdLocation == loc.IdLocation);


            if (item == null)
            {
                _db.GetTable<Location>().InsertOnSubmit(loc);
            }
            else
            {
                item.Name = loc.Name;
            }

            _db.SubmitChanges();
        }

        public void DeleteLocation(int id)
        {
            Location item = _db.GetTable<Location>().FirstOrDefault(x => x.IdLocation == id);
            _db.GetTable<Location>().DeleteOnSubmit(item);
            _db.SubmitChanges();
        }

        #endregion

        #region ===--- VACANCIES ---===

        public IEnumerable<Vacancy> GetAllVacancy()
        {
            var result = from vac in _db.GetTable<Vacancy>()
                         select vac;

            return result;
        }

        public Vacancy GetVacancyById(int id)
        {
            return _db.GetTable<Vacancy>().FirstOrDefault(x => x.IdVacancy == id);
        }

        public IEnumerable<Vacancy> GetVacancyByLocation(string name)
        {
            Location loc = _db.GetTable<Location>().FirstOrDefault(x => x.Name == name);
            IEnumerable<Vacancy> result = from vac in _db.GetTable<Vacancy>()
                                         where vac.IdLocation == loc.IdLocation
                                         select vac;
            return result;
        }

        public IEnumerable<Vacancy> GetVacancyByPosition(string pos)
        {
            IEnumerable<Vacancy> result = from vac in _db.GetTable<Vacancy>()
                                         where vac.Position == pos
                                         select vac;
            return result;
        }

        public IEnumerable<Vacancy> GetVacancyBySalary(decimal money)
        {
            IEnumerable<Vacancy> result = from vac in _db.GetTable<Vacancy>()
                                         where vac.Salary == money
                                         select vac;
            return result;
        }

        public Vacancy SaveVacancy(Vacancy vac)
        {
            Vacancy = vac;

            Vacancy item = _db.GetTable<Vacancy>().FirstOrDefault(x => x.IdVacancy == vac.IdVacancy);

            if (item == null)
            {
                _db.GetTable<Vacancy>().InsertOnSubmit(vac);
            }
            else
            {
                item.IdLocation = vac.IdLocation;    // TODO: можем ли мы тут менять или нужно делать дополнительные проверки
                item.Position = vac.Position;
                item.ProjectAbout = vac.ProjectAbout;
                item.Salary = vac.Salary;
                item.Email = vac.Email;    // TODO: можем ли мы тут менять или нужно делать дополнительные проверки

            }
            _db.SubmitChanges();

            return _db.GetTable<Vacancy>().FirstOrDefault(x => x.IdVacancy == vac.IdVacancy);
        }
        public void DeleteVacancy(int idVacancy)
        {
            Vacancy vac = _db.GetTable<Vacancy>().FirstOrDefault(x => x.IdVacancy == idVacancy);
            _db.GetTable<Vacancy>().DeleteOnSubmit(vac);
            _db.SubmitChanges();
        }

        #endregion

        #region ===--- ADD SKILLRESUME ---===

        public void AddSkillToResume(SkillResume addSkillResume)        
        {
            _db.GetTable<SkillResume>()    
                .InsertOnSubmit(addSkillResume);
            _db.SubmitChanges();
        }

        #endregion

        #region ===--- GET SKILLRESUME ---===

        public SkillResume GetSkillResume(long idSkill, long idResume)
        {
            return _db.GetTable<SkillResume>()
                .FirstOrDefault(sr => sr.IdResume == idResume && sr.IdSkill == idSkill);
        }

        public IEnumerable<SkillResume> GetAllSkillResume()
        {
            return _db.GetTable<SkillResume>();
        }

        public IQueryable<SkillResume> GetAllSkillResumeByIdRes(long idRes)
        {
            var allSkill = from r in _db.GetTable<SkillResume>()
                           where r.IdResume == idRes
                           select r;
            return allSkill;
        }


        #endregion

        #region ===--- ADD SKILLVACANCY ---===

        public void AddSkillToVacancy(SkillVacancy addSkillVacancy)
        {
            _db.GetTable<SkillVacancy>()    
                .InsertOnSubmit(addSkillVacancy);
            _db.SubmitChanges();
        }

        public IEnumerable<SkillVacancy> GetAllSkillVacancy()
        {
            return _db.GetTable<SkillVacancy>();
        }

        #endregion

        #region ===--- GET SKILLVACANCY ---===

        public SkillVacancy GetSkillVacancy(long idSkill, long idVacancy)
        {
            return _db.GetTable<SkillVacancy>()
                .FirstOrDefault(sr => sr.IdVacancy == idVacancy && sr.IdSkill == idSkill);
        }

        public IQueryable<SkillVacancy> GetAllSkillVavancyByIDVac(int idVac)
        {
            var result = from v in _db.GetTable<SkillVacancy>()
                         where v.IdVacancy == idVac
                         select v;

            return result;
        }

        #endregion
    }
}