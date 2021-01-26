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
    public class VacancyController : ApiController
    {
        #region ======------ PRIVATE DATA ------========

        private readonly IRekrutDatabase _db = new RekrutDatabase();

        #endregion

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_db.GetAllVacancy());

            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
                
            }
            
        }

        // GET api/values/5
        public IHttpActionResult GetByLoc(string param)
        {
            try
            {
                return Ok(_db.GetVacancyByLocation(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

       
        public IHttpActionResult GetByPos(string param)
        {
            try
            {
                return Ok(_db.GetVacancyByPosition(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        public IHttpActionResult GetBySal(decimal param)
        {
            try
            {
                return Ok(_db.GetVacancyBySalary(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        // POST api/values
        public IHttpActionResult Post([FromBody] Vacancy vac)
        {
            try
            {
                return Ok(_db.SaveVacancy(vac));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/Vacancy/5
        public void Put([FromBody]Vacancy vac)
        {
            //try
            //{
            //    return Ok(_db.SaveVacancy(vac));

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}           
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _db.DeleteVacancy(id);
        }
    }
}
