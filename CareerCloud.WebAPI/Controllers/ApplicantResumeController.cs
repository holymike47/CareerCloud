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
    public class ApplicantResumeController : ApiController
    {
        private ApplicantResumeLogic _logic;
        public ApplicantResumeController()
        {
            _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
        }
        [Route("resume/{ApplicantResumeId}")]
        [HttpGet, ResponseType(typeof(ApplicantResumePoco))]
        public IHttpActionResult GetApplicantResume(Guid ApplicantResumeId)
        {
            try
            {
                ApplicantResumePoco poco = _logic.Get(ApplicantResumeId);
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
        [Route("resume")]
        [HttpGet, ResponseType(typeof(List<ApplicantResumePoco>))]
        public IHttpActionResult GetApplicantResume()
        {
            try
            {
                List<ApplicantResumePoco> pocos = _logic.GetAll();
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
        [Route("resume")]
        [HttpPut]
        public IHttpActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] pocos)
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
        [Route("resume")]
        [HttpPost]
        public IHttpActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] pocos)
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
        [Route("resume")]
        [HttpDelete]
        public IHttpActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] pocos)
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
