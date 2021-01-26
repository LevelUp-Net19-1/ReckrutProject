using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Rekrut.Models;

namespace Rekrut.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SkillVacancyController : ApiController
    {
        #region ======------ PRIVATE DATA ------========

        private readonly IRekrutDatabase db = new RekrutDatabase();

        #endregion

        // GET: api/SkillVacancy
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.GetAllSkillVacancy());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/SkillVacancy/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SkillVacancy
        public IHttpActionResult Post([FromBody]SkillVacancy postSkillVacancy)
        {
            if (postSkillVacancy == null)
            {
                return BadRequest("Нельзя добавить пустые значения");
            }
            else
            {
                var presentVac = db.GetSkillById(postSkillVacancy.IdSkill);
                var presentSkill = db.GetSkillById(postSkillVacancy.IdSkill);

                var someVacSkill = db.GetSkillVacancy(postSkillVacancy.IdSkill, postSkillVacancy.IdVacancy);

                if ((presentVac != null) && (presentSkill != null) && (someVacSkill == null))
                {
                    db.AddSkillToVacancy(postSkillVacancy);
                }
                else
                {
                    if (presentVac == null)
                    {
                        return BadRequest("Вакансии с таким ID не существует.");
                    }

                    if (presentSkill == null)
                    {
                        return BadRequest("Скил с таким ID не существует.");
                    }

                    if (someVacSkill != null)
                    {
                        return BadRequest("Нельзя добавить существующую запись.");
                    }
                }
            }

            return Ok(db.GetSkillResume(postSkillVacancy.IdSkill, postSkillVacancy.IdVacancy));
        }

        // PUT: api/SkillVacancy/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SkillVacancy/5
        public void Delete(int id)
        {
        }
    }
}
