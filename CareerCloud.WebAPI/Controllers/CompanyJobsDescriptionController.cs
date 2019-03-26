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
    public class CompanyJobsDescriptionController : ApiController
    {
        private CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            _logic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
        }
        [Route("jobdescription/{CompanyJobDescriptionId}")]
        [HttpGet, ResponseType(typeof(CompanyJobDescriptionPoco))]
        public IHttpActionResult GetCompanyJobsDescription(Guid CompanyJobDescriptionId)
        {
            try
            {
                CompanyJobDescriptionPoco poco = _logic.Get(CompanyJobDescriptionId);
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
        [Route("jobdescription")]
        [HttpGet, ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public IHttpActionResult GetCompanyJobsDescription()
        {
            try
            {
                List<CompanyJobDescriptionPoco> pocos = _logic.GetAll();
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
        [Route("jobdescription")]
        [HttpPut]
        public IHttpActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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
        [Route("jobdescription")]
        [HttpPost]
        public IHttpActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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
        [Route("jobdescription")]
        [HttpDelete]
        public IHttpActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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
