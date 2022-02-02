using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Jogging_Tracker.Data;
using Jogging_Tracker.DTOs.JoggingRecord;
using Jogging_Tracker.Models;
using Jogging_Tracker.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Jogging_Tracker.Controllers
{
    /// <summary>
    /// Controller for Jogging Records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JoggingRecordController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor of jogging record controller.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="configuration"></param>
        public JoggingRecordController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            Configuration = configuration;
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
            
            _dbContext.JoggingRecords.Add(new JoggingRecord()
            {
                UserId = GetUserIds(Request),
                Date = record.Date,
                DistanceInMeters = record.DistanceInMeters,
                DurationInSeconds = record.DurationInSeconds
            });
            return Ok(await _dbContext.SaveChangesAsync());
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