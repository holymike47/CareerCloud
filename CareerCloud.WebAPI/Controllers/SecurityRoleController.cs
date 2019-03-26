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
    public class SecurityRoleController : ApiController
    {
        private SecurityRoleLogic _logic;
        public SecurityRoleController()
        {
            _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
        }
        [Route("role/{SecurityRoleId}")]
        [HttpGet, ResponseType(typeof(SecurityRolePoco))]
        public IHttpActionResult GetSecurityRole(Guid SecurityRoleId)
        {
            try
            {
                SecurityRolePoco poco = _logic.Get(SecurityRoleId);
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
        [Route("role")]
        [HttpGet, ResponseType(typeof(List<SecurityRolePoco>))]
        public IHttpActionResult GetSecurityRole()
        {
            try
            {
                List<SecurityRolePoco> pocos = _logic.GetAll();
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
        [Route("role")]
        [HttpPut]
        public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
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
        [Route("role")]
        [HttpPost]
        public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
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
        [Route("role")]
        [HttpDelete]
        public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
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
