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
    public class CompanyJobSkillController : ApiController
    {
        private CompanyJobSkillLogic _logic;
        public CompanyJobSkillController()
        {
            _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
        }
        [Route("jobskill/{CompanyJobSkillId}")]
        [HttpGet, ResponseType(typeof(CompanyJobSkillPoco))]
        public IHttpActionResult GetCompanyJobSkill(Guid CompanyJobSkillId)
        {
            try
            {
                CompanyJobSkillPoco poco = _logic.Get(CompanyJobSkillId);
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
        [Route("jobskill")]
        [HttpGet, ResponseType(typeof(List<CompanyJobSkillPoco>))]
        public IHttpActionResult GetCompanyJobSkill()
        {
            try
            {
                List<CompanyJobSkillPoco> pocos = _logic.GetAll();
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
        [Route("jobskill")]
        [HttpPut]
        public IHttpActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
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
        [Route("jobskill")]
        [HttpPost]
        public IHttpActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
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
        [Route("jobskill")]
        [HttpDelete]
        public IHttpActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
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
