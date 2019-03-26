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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;
        public ApplicantSkillController()
        {
            _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
        }
        [Route("skill/{ApplicantSkillId}")]
        [HttpGet, ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult GetApplicantSkill(Guid ApplicantSkillId)
        {
            try
            {
                ApplicantSkillPoco poco = _logic.Get(ApplicantSkillId);
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
        [Route("skill")]
        [HttpGet, ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult GetApplicantSkill()
        {
            try
            {
                List<ApplicantSkillPoco> pocos = _logic.GetAll();
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
        [Route("skill")]
        [HttpPut]
        public IHttpActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
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
        [Route("skill")]
        [HttpPost]
        public IHttpActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
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
        [Route("skill")]
        [HttpDelete]
        public IHttpActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
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
