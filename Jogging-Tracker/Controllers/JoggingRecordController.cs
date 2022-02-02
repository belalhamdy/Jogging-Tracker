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
        public async Task<IActionResult> InsertJogging([FromBody] AddJoggingRecordDto record)
        {
            var mapped = _mapper.Map<JoggingRecord>(record);
            mapped.UserId = GetUserIds(Request);
            _dbContext.JoggingRecords.Add(mapped);
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
        public IActionResult GetMyJogging()
        {
            var userId = GetUserIds(Request);
            return Ok(_dbContext.JoggingRecords.Where(x => x.UserId.Equals(userId)).ToList());
        }

        /// <summary>
        /// Get jogging records of a user.
        /// </summary>
        /// <param name="userId">The record to be added</param>
        /// <response code="200">Returned if the computer inserted successfully</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpGet]
        [Route("get-user-jogging")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult GetMyJogging(string userId)
        {
            return Ok(_dbContext.JoggingRecords.Where(x => x.UserId.Equals(userId)).ToList());
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
    }
}