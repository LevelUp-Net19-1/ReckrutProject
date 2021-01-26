using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Rekrut.Models
{
    public class Seach
    {
        private IRekrutDatabase _rek = new RekrutDatabase();

        public IEnumerable<Vacancy> GetAllVacancyByResume()
        {
            Resume res = _rek.Resume;
            Location loc = _rek.GetLocationById((int)res.IdLocation);
            var allvac = _rek.GetVacancyByLocation(loc.Name);

            var skillRes = _rek.GetAllSkillResumeByIdRes(res.IdRes);

            List<Vacancy> result = new List<Vacancy>();

            int check = 0;

            foreach (var vac in allvac)
            {
                foreach (var i in skillRes)
                {
                    foreach (var item in _rek.GetAllSkillVavancyByIDVac(vac.IdVacancy))
                    {
                        if ((i.IdSkill == item.IdSkill) && (item.MinExperience <= i.Experience))
                        {
                            check++;
                        }
                    }
                }
                if (skillRes.Count() == check)
                {
                    result.Add(vac);
                }

                check = 0;
            }

            return result;

        }

        public IEnumerable<Resume> GetAllResumeByVacancy(int id)
        {
            var vac = _rek.GetVacancyById(id);
            var allres = _rek.GetResumesByLocation(vac.IdLocation);

            var skillVac = _rek.GetAllSkillVavancyByIDVac(vac.IdVacancy);

            List<Resume> result = new List<Resume>();
            int check = 0;

            foreach (var res in allres)
            {
                foreach (var i in skillVac)
                {
                    foreach (var item in _rek.GetAllSkillResumeByIdRes(res.IdRes))
                    {
                        if ((i.IdSkill == item.IdSkill) && (i.MinExperience <= item.Experience))
                        {
                            check++;
                        }
                    }
                }
                if (skillVac.Count() == check)
                {
                    result.Add(res);
                }

                check = 0;
            }

            return result;

        }
    }
}