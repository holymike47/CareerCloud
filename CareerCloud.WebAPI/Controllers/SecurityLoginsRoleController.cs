using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginsRoleController : ApiController
    {
        private SecurityLoginsRoleLogic _logic;
        public SecurityLoginsRoleController()
        {
            _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
        }
        [Route("loginsrole/{SecurityLoginsRoleId}")]
        [HttpGet, ResponseType(typeof(SecurityLoginsRolePoco))]
        public IHttpActionResult GetSecurityLoginsRole(Guid SecurityLoginsRoleId)
        {
            try
            {
                SecurityLoginsRolePoco poco = _logic.Get(SecurityLoginsRoleId);
                if (poco == null)
                {
                    return NotFound();
                }
                return Ok(poco);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("loginsrole")]
        [HttpGet, ResponseType(typeof(List<SecurityLoginsRolePoco>))]
        public IHttpActionResult GetSecurityLoginsRole()
        {
            try
            {
                List<SecurityLoginsRolePoco> pocos = _logic.GetAll();
                if (pocos == null)
                {
                    return NotFound();
                }
                return Ok(pocos);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("loginsrole")]
        [HttpPut]
        public IHttpActionResult PutSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            try
            {
                _logic.Update(pocos);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("loginsrole")]
        [HttpPost]
        public IHttpActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            try
            {
                _logic.Add(pocos);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("loginsrole")]
        [HttpDelete]
        public IHttpActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            try
            {
                _logic.Delete(pocos);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
