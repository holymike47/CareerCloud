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
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;
        public CompanyLocationController()
        {
            _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
        }
        [Route("location/{CompanyLocationId}")]
        [HttpGet, ResponseType(typeof(CompanyLocationPoco))]
        public IHttpActionResult GetCompanyLocation(Guid CompanyLocationId)
        {
            try
            {
                CompanyLocationPoco poco = _logic.Get(CompanyLocationId);
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
        [Route("location")]
        [HttpGet, ResponseType(typeof(List<CompanyLocationPoco>))]
        public IHttpActionResult GetCompanyLocation()
        {
            try
            {
                List<CompanyLocationPoco> pocos = _logic.GetAll();
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
        [Route("location")]
        [HttpPut]
        public IHttpActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
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
        [Route("location")]
        [HttpPost]
        public IHttpActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
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
        [Route("location")]
        [HttpDelete]
        public IHttpActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
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
