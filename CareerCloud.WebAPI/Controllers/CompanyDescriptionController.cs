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
    public class CompanyDescriptionController : ApiController
    {
        private CompanyDescriptionLogic _logic;
        public CompanyDescriptionController()
        {
            _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
        }
        [Route("description/{CompanyDescriptionId}")]
        [HttpGet, ResponseType(typeof(CompanyDescriptionPoco))]
        public IHttpActionResult GetCompanyDescription(Guid CompanyDescriptionId)
        {
            try
            {
                CompanyDescriptionPoco poco = _logic.Get(CompanyDescriptionId);
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
        [Route("description")]
        [HttpGet, ResponseType(typeof(List<CompanyDescriptionPoco>))]
        public IHttpActionResult GetCompanyDescription()
        {
            try
            {
                List<CompanyDescriptionPoco> pocos = _logic.GetAll();
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
        [Route("description")]
        [HttpPut]
        public IHttpActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
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
        [Route("description")]
        [HttpPost]
        public IHttpActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
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
        [Route("description")]
        [HttpDelete]
        public IHttpActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
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
