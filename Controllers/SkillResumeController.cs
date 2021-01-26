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
    public class SkillResumeController : ApiController
    {
        #region ======------ PRIVATE DATA ------========

        private readonly IRekrutDatabase db = new RekrutDatabase();

        #endregion

        // GET: api/SkillResume
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.GetAllSkillResume());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/SkillResume/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SkillResume
        public void Post([FromBody]string value)
        {
        }

        // POST: api/SkillResume
        public IHttpActionResult Post([FromBody] SkillResume postSkillResume)
        {
            if (postSkillResume == null)
            {
                return BadRequest("Нельзя добавить пустые значения");
            }
            else
            {
                var presentRes = db.GetResumeById(postSkillResume.IdResume);
                var presentSkill = db.GetSkillById(postSkillResume.IdSkill);

                var someResSkill = db.GetSkillResume(postSkillResume.IdSkill, postSkillResume.IdResume);

                if ((presentRes != null) && (presentSkill != null) && (someResSkill == null))
                {
                    db.AddSkillToResume(postSkillResume);
                }
                else
                {
                    if (presentRes == null)
                    {
                        return BadRequest("Резюме с таким ID не существует.");
                    }

                    if (presentSkill == null)
                    {
                        return BadRequest("Скил с таким ID не существует.");
                    }

                    if (someResSkill != null)
                    {
                        return BadRequest("Нельзя добавить существующую запись.");
                    }
                }
            }

            return Ok(db.GetSkillResume(postSkillResume.IdSkill, postSkillResume.IdResume));
        }

        // PUT: api/SkillResume/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SkillResume/5
        public void Delete(int id)
        {
        }
    }
}
