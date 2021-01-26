using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Rekrut.Models;
using System.Data.Linq;
using System.Web.Http.Cors;

namespace Rekrut.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResumesController : ApiController
    {
        #region ======------ PRIVATE DATA ------========

        private readonly IRekrutDatabase db = new RekrutDatabase();

        #endregion

        #region ===--- GET: ---===

        // GET: api/Resumes
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.GetResumes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Resumes/5
        public IHttpActionResult GetByLocation(int param)
        {
            try
            {
                return Ok(db.GetResumesByLocation(param));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Resumes/param
        public IHttpActionResult GetByPosition(string param)
        {
            try
            {
                return Ok(db.GetResumesByPosition(param));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Resumes/param1/param2
        public IHttpActionResult GetByMinToMaxSalary(decimal param1, decimal param2)
        {
            try
            {
                return Ok(db.GetByMinToMaxSalary(param1, param2));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        // POST: api/Resumes
        public IHttpActionResult Post([FromBody]Resume postResume)
        {
            if (postResume == null)
            {
                return BadRequest("Нельзя добавить пустые значения");
            }
            else
            {
                var someRes = db.GetResumeById(postResume.IdRes);

                if (someRes == null)
                {
                    db.AddResume(postResume);
                }
                else
                {
                    return BadRequest("Нельзя добавить существующую запись");
                }
            }

            return Ok(db.GetResumeById(postResume.IdRes));
        }

        // PUT: api/Resumes/5

        public IHttpActionResult Put(long id, [FromBody]Resume purResume)
        {
            if (purResume == null)
            {
                return BadRequest("Нельзя изменять на пустые значения");
            }
            else
            {
                var someRes = db.GetResumeById(id);

                if (someRes != null)
                {
                    db.UpdateResume(someRes, purResume);
                }
                else
                {
                    return BadRequest("Нельзя изменять не существующую запись");
                }
            }

            return Ok(db.GetAccountByEmail(purResume.Email));
        }

        // DELETE: api/Resumes/5
        public IHttpActionResult Delete(long id)
        {
            try
            {
                db.DeleteResume(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
