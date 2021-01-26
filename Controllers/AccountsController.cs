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
    public class AccountsController : ApiController
    {
        #region ======------ PRIVATE DATA ------========

        private readonly IRekrutDatabase db = new RekrutDatabase();

        #endregion

        #region ===--- GET: ---===

        /// <summary>
        /// GET: api/Accounts
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()    // get all accounts with 0 IsDeleted parameter
        {
            try
            {
                return Ok(db.GetAccounts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetByType(byte param)    // get all accounts with parameter IdAccType = param
        {
            try
            {
                return Ok(db.GetAccountsByType(param));                
            }
            catch (Exception ex)
            {                
                return BadRequest(ex.Message);
            }
        }

        #endregion

        // POST: api/Accounts
        public IHttpActionResult Post([FromBody] Account acc)
        {
            if (acc == null)
            {
                return BadRequest("Нельзя добавить пустые значения");
            }
            else
            {
                var someAcc = db.GetAccountByEmail(acc.Email);

                if (someAcc == null)
                {
                    db.AddAccount(acc);
                }
                else
                {
                    return BadRequest("Нельзя добавить существующую запись");
                }
            }

            return Ok(db.GetAccountByEmail(acc.Email));
        }

        // PUT: api/Accounts/5
        public IHttpActionResult Put(string id, [FromBody] Account acc)
        {
            if (acc == null)
            {
                return BadRequest("Нельзя изменять на пустые значения");
            }
            else
            {
                var someAcc = db.GetAccountByEmail(id);

                if (someAcc != null)
                {
                    db.UpdateAccount(someAcc, acc);
                }
                else
                {
                    return BadRequest("Нельзя изменять не существующую запись");
                }
            }

            return Ok(db.GetAccountByEmail(acc.Email));
        }

        // DELETE: api/Accounts/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                db.DeleteAccount(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
