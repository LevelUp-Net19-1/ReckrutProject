using Rekrut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Rekrut.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SeachController : ApiController
    {
        private Seach _seach = new Seach();


        // GET: api/Seach/5
        public IHttpActionResult GetAllVacancyForResume()
        {
            try
            {
                return Ok(_seach.GetAllVacancyByResume());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        public IHttpActionResult GetAllResumeForVacancy(int id)
        {
            try
            {
                return Ok(_seach.GetAllResumeByVacancy(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        // POST: api/Seach
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Seach/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Seach/5
        public void Delete(int id)
        {
        }
    }
}
