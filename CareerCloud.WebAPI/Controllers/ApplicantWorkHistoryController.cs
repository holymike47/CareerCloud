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
    public class ApplicantWorkHistoryController : ApiController
    {
        private ApplicantWorkHistoryLogic _logic;
        public ApplicantWorkHistoryController()
        {
            _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
        }
        [Route("workhistory/{ApplicantWorkHistoryId}")]
        [HttpGet, ResponseType(typeof(ApplicantWorkHistoryPoco))]
        public IHttpActionResult GetApplicantWorkHistory(Guid ApplicantWorkHistoryId)
        {
            try
            {
                ApplicantWorkHistoryPoco poco = _logic.Get(ApplicantWorkHistoryId);
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
        [Route("workhistory")]
        [HttpGet, ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public IHttpActionResult GetApplicantWorkHistory()
        {
            try
            {
                List<ApplicantWorkHistoryPoco> pocos = _logic.GetAll();
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
        [Route("workhistory")]
        [HttpPut]
        public IHttpActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
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
        [Route("workhistory")]
        [HttpPost]
        public IHttpActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
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
        [Route("workhistory")]
        [HttpDelete]
        public IHttpActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
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
