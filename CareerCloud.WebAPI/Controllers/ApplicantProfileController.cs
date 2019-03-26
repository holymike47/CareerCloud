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
    public class ApplicantProfileController : ApiController
    {
        private ApplicantProfileLogic _logic;
        public ApplicantProfileController()
        {
            _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
        }
        [Route("profile/{ApplicantProfileId}")]
        [HttpGet, ResponseType(typeof(ApplicantProfilePoco))]
        public IHttpActionResult GetApplicantProfile(Guid ApplicantProfileId)
        {
            try
            {
                ApplicantProfilePoco poco = _logic.Get(ApplicantProfileId);
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
        [HttpGet, ResponseType(typeof(List<ApplicantProfilePoco>))]
        public IHttpActionResult GetApplicantProfile()
        {
            try
            {
                List<ApplicantProfilePoco> pocos = _logic.GetAll();
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
        public IHttpActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
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
        public IHttpActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
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
        public IHttpActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
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
