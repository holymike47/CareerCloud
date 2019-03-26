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
    public class CompanyJobController : ApiController
    {
        private CompanyJobLogic _logic;
        public CompanyJobController()
        {
            _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
        }
        [Route("job/{CompanyJobId}")]
        [HttpGet, ResponseType(typeof(CompanyJobPoco))]
        public IHttpActionResult GetCompanyJob(Guid CompanyJobId)
        {
            try
            {
                CompanyJobPoco poco = _logic.Get(CompanyJobId);
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
        [Route("job")]
        [HttpGet, ResponseType(typeof(List<CompanyJobPoco>))]
        public IHttpActionResult GetCompanyJob()
        {
            try
            {
                List<CompanyJobPoco> pocos = _logic.GetAll();
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
        [Route("job")]
        [HttpPut]
        public IHttpActionResult PutCompanyJob([FromBody] CompanyJobPoco[] pocos)
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
        [Route("job")]
        [HttpPost]
        public IHttpActionResult PostCompanyJob([FromBody] CompanyJobPoco[] pocos)
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
        [Route("job")]
        [HttpDelete]
        public IHttpActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] pocos)
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
