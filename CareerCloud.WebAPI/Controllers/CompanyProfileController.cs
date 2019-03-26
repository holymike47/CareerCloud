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
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileLogic _logic;
        public CompanyProfileController()
        {
            _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
        }
        [Route("profile/{CompanyProfileId}")]
        [HttpGet, ResponseType(typeof(CompanyProfilePoco))]
        public IHttpActionResult GetCompanyProfile(Guid CompanyProfileId)
        {
            try
            {
                CompanyProfilePoco poco = _logic.Get(CompanyProfileId);
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
        [Route("profile")]
        [HttpGet, ResponseType(typeof(List<CompanyProfilePoco>))]
        public IHttpActionResult GetCompanyProfile()
        {
            try
            {
                List<CompanyProfilePoco> pocos = _logic.GetAll();
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
        [Route("profile")]
        [HttpPut]
        public IHttpActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
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
        [Route("profile")]
        [HttpPost]
        public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
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
        [Route("profile")]
        [HttpDelete]
        public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
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
