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
    public class CompanyJobEducationController : ApiController
    {
        private CompanyJobEducationLogic _logic;
        public CompanyJobEducationController()
        {
            _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
        }
        [Route("jobeducation/{CompanyJobEducationId}")]
        [HttpGet, ResponseType(typeof(CompanyJobEducationPoco))]
        public IHttpActionResult GetCompanyJobEducation(Guid CompanyJobEducationId)
        {
            try
            {
                CompanyJobEducationPoco poco = _logic.Get(CompanyJobEducationId);
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
        [Route("jobeducation")]
        [HttpGet, ResponseType(typeof(List<CompanyJobEducationPoco>))]
        public IHttpActionResult GetCompanyJobEducation()
        {
            try
            {
                List<CompanyJobEducationPoco> pocos = _logic.GetAll();
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
        [Route("jobeducation")]
        [HttpPut]
        public IHttpActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
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
        [Route("jobeducation")]
        [HttpPost]
        public IHttpActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
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
        [Route("jobeducation")]
        [HttpDelete]
        public IHttpActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
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
