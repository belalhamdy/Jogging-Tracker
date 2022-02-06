using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jogging_Tracker.Data;
using Jogging_Tracker.DTOs.JoggingRecord;
using Jogging_Tracker.Models;
using Jogging_Tracker.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jogging_Tracker.Controllers
{
    /// <summary>
    /// Controller for Jogging Records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JoggingRecordController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of jogging record controller.
        /// </summary>
        /// <param name="dbContext"></param>
        public JoggingRecordController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// To test the API if it works.
        /// </summary>
        [HttpGet]
        [Route("home")]
        [AllowAnonymous]
        public IActionResult Home()
        {
            return Ok(GetReport("24391000-0a63-4bb1-971f-7611dd87d9f6",new GetJoggingRecordsDateFilter()
            {
                From = new DateTime(2022,1,20)
            }));
        }

        /// <summary>
        /// Adds a jogging record to the system
        /// </summary>
        /// <param name="record">The record to be added</param>
        /// <response code="200">Returned if the computer inserted successfully</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpPost]
        [Route("insert-jogging")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> InsertJogging([FromBody] List<AddJoggingRecordDto> records)
        {
            var userId = GetUserIds(Request);
            var joggingRecords = records.Select(x =>
            {
                var mapped = _mapper.Map<JoggingRecord>(x);
                mapped.UserId = userId;
                return mapped;
            });
            _dbContext.JoggingRecords.AddRange(joggingRecords);
            return Ok(await _dbContext.SaveChangesAsync());
        }

        /// <summary>
        /// Get jogging records of the logged in user.
        /// </summary>
        /// <response code="200">Returned if the computer inserted successfully</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpGet]
        [Route("get-my-jogging")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<IEnumerable<JoggingRecordDto>> GetMyJogging([FromQuery] GetJoggingRecordsDateFilter filter)
        {
            var userId = GetUserIds(Request);
            return Ok(GetJogging(userId, filter));
        }

        /// <summary>
        /// Get jogging records of a user and filter them.
        /// </summary>
        /// <param name="userId">The record to be added</param>
        /// <param name="filter">The record to be added</param>
        /// <response code="200">Returned if the computer inserted successfully</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpGet]
        [Route("get-user-jogging")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<IEnumerable<JoggingRecordDto>> GetUserJogging(string userId,
            [FromQuery] GetJoggingRecordsDateFilter filter)
        {
            return Ok(GetJogging(userId, filter));
        }

        /// <summary>
        ///  Gets user IDs given token.
        /// </summary>
        /// <param name="request">The request that contains token.</param>
        private static string GetUserIds(HttpRequest request)
        {
            string authHeader = request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(authHeader) as JwtSecurityToken;
            var userId = jsonToken?.Claims.First(claim => claim.Type == "UserId").Value;
            return userId;
        }

        /// <summary>
        /// Gets jogging records of a specified user given user id and filter to filter records on.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private IEnumerable<JoggingRecordDto> GetJogging(string userId, GetJoggingRecordsDateFilter filter)
        {
            return _dbContext.JoggingRecords
                .Where(x => x.UserId.Equals(userId) && x.Date >= filter.From && x.Date <= filter.To)
                .Select(x => _mapper.Map<JoggingRecordDto>(x));
        }

        private IEnumerable<JoggingRecordReport> GetReport(string userId, GetJoggingRecordsDateFilter filter)
        {
            return _dbContext.JoggingRecords
                .Where(x => x.UserId.Equals(userId) && x.Date >= filter.From && x.Date <= filter.To).AsEnumerable()
                .GroupBy(x => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.Date, CalendarWeekRule.FirstDay,
                    DayOfWeek.Monday)).Select(x => new
                {
                    Week = x.Key, Distance = x.Average(y => y.DistanceInMeters),
                    Duration = x.Average(y => y.DurationInSeconds)
                }).Select(x => new JoggingRecordReport()
                {
                    WeekNumber = x.Week, AverageDistance = x.Distance, AverageSpeed = x.Distance / x.Duration
                }).ToList();
        }
    }
}