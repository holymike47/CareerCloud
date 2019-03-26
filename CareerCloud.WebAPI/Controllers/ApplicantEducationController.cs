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
    public class ApplicantEducationController : ApiController
    {
        private ApplicantEducationLogic _logic;
        public ApplicantEducationController()
        {
            _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
        }
        [Route("education/{applicantEducationId}")]
        [HttpGet, ResponseType(typeof(ApplicantEducationPoco))]
        public IHttpActionResult GetApplicantEducation(Guid applicantEducationId)
        {
            try
            {
                ApplicantEducationPoco poco = _logic.Get(applicantEducationId);
                if (poco == null)
                {
                    return NotFound();
                }
                return Ok(poco);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("education")]
        [HttpGet,ResponseType(typeof(List<ApplicantEducationPoco>))]
        public IHttpActionResult GetApplicantEducation()
        {
            try
            {
                List<ApplicantEducationPoco> pocos = _logic.GetAll();
                if (pocos == null)
                {
                    return NotFound();
                }
                return Ok(pocos);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("education")]
        [HttpPut]
        public IHttpActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            try
            {
                _logic.Update(pocos);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("education")]
        [HttpPost]
        public IHttpActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            try
            {
                _logic.Add(pocos);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("education")]
        [HttpDelete]
        public IHttpActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            try
            {
                _logic.Delete(pocos);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
