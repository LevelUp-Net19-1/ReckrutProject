using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data.Linq.Mapping;
using Rekrut.Models;
using System.Web.Http.Cors;

namespace Rekrut.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LocationController : ApiController
    {
        #region ======------ PRIVATE DATA ------========

        private readonly IRekrutDatabase db = new RekrutDatabase();

        #endregion

        // GET: api/Location
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.GetAllLocations());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetLocationByName(string param)
        {
            try
            {
                return Ok(db.GetLocationByName(param));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Location/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Location
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Location/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
        }
    }
}
