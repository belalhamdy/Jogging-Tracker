using Jogging_Tracker.Data;
using Jogging_Tracker.Models;
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
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            Configuration = configuration;
        }
    }
}