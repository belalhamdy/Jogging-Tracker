using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Jogging_Tracker.Data;
using Jogging_Tracker.DTOs.Account;
using Jogging_Tracker.Models;
using Jogging_Tracker.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Jogging_Tracker.Controllers
{
    /// <summary>
    /// Controller for Accounts.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor of account controller.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="configuration"></param>
        public AccountController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            Configuration = configuration;
        }

        /// <summary>
        /// To test the API if it works.
        /// </summary>
        [HttpGet]
        [Route("home")]
        [AllowAnonymous]
        public IActionResult Home()
        {
            return Ok();
        }

        /// <summary>
        /// Registers a normal user to the system.
        /// </summary>
        /// <param name="model">The data of the user</param>
        /// <response code="200">Returned if user is registered successfully</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpPost]
        [Route("register-user")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto model)
        {
            try
            {
                await Register(model, UserRoles.User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("User created successfully.");
        }

        /// <summary>
        /// Registers an admin user to the system.
        /// </summary>
        /// <param name="model">The data of the user</param>
        /// <response code="200">Returned if user is registered successfully</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpPost]
        [Route("register-admin")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto model)
        {
            try
            {
                await Register(model, UserRoles.Admin);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Admin created successfully.");
        }

        /// <summary>
        /// Registers a user manager to the system.
        /// </summary>
        /// <param name="model">The data of the user</param>
        /// <response code="200">Returned if user is registered successfully</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpPost]
        [Route("register-manager")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserManager([FromBody] RegisterDto model)
        {
            try
            {
                await Register(model, UserRoles.User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("User manager created successfully.");
        }

        /// <summary>
        /// Logging in a user to the system.
        /// </summary>
        /// <param name="model">The data of the user</param>
        /// <response code="200">Returned if user is logged in successfully</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized();
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("UserId", user.Id),
            };
            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                Configuration["JWT:ValidIssuer"],
                Configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(7),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                role = string.Join(",", userRoles)
            });
        }
        
        /// <summary>
        /// Gets all system users.
        /// </summary>
        /// <response code="200">Returned if users are returned successfully</response>
        /// <response code="403">Returned if you are not authorized to view all users.</response>
        /// <response code="500">Returned if an internal server error</response>
        [HttpPost]
        [Route("get-users")]
        [Authorize(Roles = UserRoles.Admin)]
        [Authorize(Roles = UserRoles.UserManager)]
        public ActionResult<IEnumerable<AccountDto>> GetUsers()
        {
            return Ok(_dbContext.Users.Select(x => _mapper.Map<AccountDto>(x)));
        }
        
        /// <summary>
        /// Registers a user in the system given the information and role.
        /// </summary>
        /// <param name="model">User information</param>
        /// <param name="role">User role</param>
        /// <exception cref="Exception"></exception>
        private async Task Register(RegisterDto model, string role)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new Exception("User Already Exists.");
            var user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new Exception("User creation failed! Please check user details and try again.");
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}