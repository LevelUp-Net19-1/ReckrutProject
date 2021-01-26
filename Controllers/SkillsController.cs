using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Rekrut.Models;
using NLog;
using System.Web.Http.Cors;

namespace Rekrut.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SkillsController : ApiController
    {
        #region ======------ PRIVATE DATA ------========

        private readonly IRekrutDatabase _db = new RekrutDatabase();
        private Logger log = LogManager.GetCurrentClassLogger();

        #endregion

        // GET: api/Skills
        public IHttpActionResult Get()
        {
            try
            {
                var skills = from s in _db.GetSkills()
                             orderby s.Name
                             select s;

                log.Info(skills);

                return Ok(_db.GetSkills());    
            }
            catch (Exception ex)
            {
                log.Error(ex);

                return BadRequest(ex.Message);   
            }
        }

        // GET: api/Skills/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var skill = _db.GetSkillById(id);

                if (skill == null)
                {
                    return BadRequest("Нет данных по запросу");
                }

                log.Info(_db.GetSkillById(id));

                return Ok(skill);
            }
            catch (Exception ex)
            {
                log.Error(ex);

                return BadRequest(ex.Message);  
            }
        }

        // POST: api/Skills
        public IHttpActionResult Post([FromBody]Skill skill)
        {
            if (skill == null)
            {
                return BadRequest("Нельзя добавить пустые значения");
            }
            else
            {
                var someSkill = _db.GetSkillByName(skill.Name); 

                if (someSkill == null)
                {
                    var data = _db.AddNewSkill(skill);
                    log.Info(data);
                }
                else
                {
                    return BadRequest("Нельзя добавить существующую запись");
                }
            }

            return Ok();
        }

        // PUT: api/Skills/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Skills/5
        public void Delete(int id)
        {
        }
    }
}
