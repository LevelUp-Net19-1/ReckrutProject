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
    public class TechnologiesController : ApiController
    {
        #region =======------ PRIVATE DATA ------====== 

        private readonly IRekrutDatabase _db = new RekrutDatabase();
        private Logger log = LogManager.GetCurrentClassLogger();

        #endregion

        // GET: api/Technologies
        public IHttpActionResult Get()
        {
            try
            {
                var technologi = _db.GetTechnologies();    //ToDo: Add Log

                log.Info(_db.GetTechnologies());

                return Ok(_db.GetTechnologies());
            }
            catch (Exception ex)
            {
                log.Error(ex);

                return BadRequest(ex.Message);
            }
        }

        // GET: api/Technologies/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var technologi = Request.CreateResponse(_db.GetTechnologiById(id));

                log.Info(_db.GetTechnologiById(id));

                return Ok(technologi.Content);
            }
            catch (Exception ex)
            {
                log.Error(ex);

                return BadRequest(ex.Message);
            }
        }

        // POST: api/Technologies
        public IHttpActionResult Post([FromBody]Technologi tech)
        {
            if (tech == null)
            {
                return BadRequest("Нельзя добавить пустые значения");
            }
            else
            {
                var someTech = _db.GetSkillByName(tech.Name);

                if (someTech == null)
                {
                    var data = _db.AddNewTechnologi(tech);

                    log.Info(data);
                }
                else
                {
                    return BadRequest("Нельзя добавить существующую запись");
                }
            }

            return Ok(_db.GetTechnologiById(tech.IdTech));
        }

        // PUT: api/Technologies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Technologies/5
        public void Delete(int id)
        {
        }
    }
}
