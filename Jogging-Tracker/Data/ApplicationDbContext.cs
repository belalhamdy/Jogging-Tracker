using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogging_Tracker.DTOs.JoggingRecord;
using Jogging_Tracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jogging_Tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedDatabase(builder);
        }

        public DbSet<JoggingRecord> JoggingRecords { get; set; }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var roles = GetRolesTable();
            var users = GetUsersTable();
            var usersRoles = users.Select((t, i) => new IdentityUserRole<string>()
                {RoleId = roles[Math.Min(i, roles.Count - 1)].Id, UserId = t.Id}).ToList();
            var joggingRecords = GetJoggingRecords();
            for (var i = 0; i < joggingRecords.Count; i++)
            {
                joggingRecords[i].UserId = users[i % 3 + 2].Id;
            }

            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<ApplicationUser>().HasData(users);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(usersRoles);
            modelBuilder.Entity<JoggingRecord>().HasData(joggingRecords);
        }

        private List<IdentityRole> GetRolesTable()
        {
            var roles = new List<string>()
            {
                Utilities.UserRoles.UserManager, Utilities.UserRoles.Admin, Utilities.UserRoles.User
            };
            return roles.Select(role => new IdentityRole()
                {Id = Guid.NewGuid().ToString(), Name = role, NormalizedName = role.ToUpper()}).ToList();
        }

        private List<ApplicationUser> GetUsersTable()
        {
            var usernames = new List<string>()
            {
                "manager", "admin", "user1", "user2", "user3"
            };
            var hasher = new PasswordHasher<ApplicationUser>();
            return usernames.Select(t => new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(), UserName = t, NormalizedUserName = t.ToUpper(),
                PasswordHash = hasher.HashPassword(null, "string"),Email = t + "@test.com"
            }).ToList();
        }

        private List<JoggingRecord> GetJoggingRecords()
        {
            return new List<JoggingRecord>()
            {
                new JoggingRecord()
                {
                    Date = new DateTime(637765954560000000), DistanceInMeters = 5901.753404672143,
                    DurationInSeconds = 18698.66947968248, RecordId = 1
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637765989120000000), DistanceInMeters = 714.9823398510622,
                    DurationInSeconds = 1719.1816452745343, RecordId = 2
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766023680000000), DistanceInMeters = 7043.3566559613355,
                    DurationInSeconds = 13786.739927708666, RecordId = 3
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766058240000000), DistanceInMeters = 3096.0341353785766,
                    DurationInSeconds = 11327.470865626567, RecordId = 4
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766092800000000), DistanceInMeters = 2965.903880535856,
                    DurationInSeconds = 4996.65063898155, RecordId = 5
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766127360000000), DistanceInMeters = 9373.39652056253,
                    DurationInSeconds = 7471.629841884835, RecordId = 6
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766161920000000), DistanceInMeters = 4571.089106873193,
                    DurationInSeconds = 4245.582141164684, RecordId = 7
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766196480000000), DistanceInMeters = 9350.225994816416,
                    DurationInSeconds = 17163.597389789793, RecordId = 8
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766231040000000), DistanceInMeters = 9472.24753848764,
                    DurationInSeconds = 17505.613899277254, RecordId = 9
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766265600000000), DistanceInMeters = 3787.13491808619,
                    DurationInSeconds = 12987.029012566025, RecordId = 10
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766300160000000), DistanceInMeters = 5835.496781835267,
                    DurationInSeconds = 8892.781769583298, RecordId = 11
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766334720000000), DistanceInMeters = 3970.6774319494557,
                    DurationInSeconds = 10423.944547793251, RecordId = 12
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766369280000000), DistanceInMeters = 9096.887444541138,
                    DurationInSeconds = 10866.761110537913, RecordId = 13
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766403840000000), DistanceInMeters = 9889.12975920805,
                    DurationInSeconds = 2453.981324722244, RecordId = 14
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766438400000000), DistanceInMeters = 7809.992601984525,
                    DurationInSeconds = 14437.514669933873, RecordId = 15
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766472960000000), DistanceInMeters = 470.49206855833717,
                    DurationInSeconds = 11920.445292111515, RecordId = 16
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766507520000000), DistanceInMeters = 9641.855347900895,
                    DurationInSeconds = 2117.788959058401, RecordId = 17
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766542080000000), DistanceInMeters = 7194.965223326463,
                    DurationInSeconds = 4457.74089068052, RecordId = 18
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766576640000000), DistanceInMeters = 3095.7833806489934,
                    DurationInSeconds = 18457.06429724887, RecordId = 19
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766611200000000), DistanceInMeters = 9330.246771931977,
                    DurationInSeconds = 3424.9333316099974, RecordId = 20
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766645760000000), DistanceInMeters = 9275.672451822573,
                    DurationInSeconds = 14018.510131986854, RecordId = 21
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766680320000000), DistanceInMeters = 3353.2287632184575,
                    DurationInSeconds = 2530.3081014047602, RecordId = 22
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766714880000000), DistanceInMeters = 6551.541684308179,
                    DurationInSeconds = 3692.6196693834963, RecordId = 23
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766749440000000), DistanceInMeters = 6442.406306179438,
                    DurationInSeconds = 13301.34182986441, RecordId = 24
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766784000000000), DistanceInMeters = 4703.143690299677,
                    DurationInSeconds = 12210.94258031044, RecordId = 25
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766818560000000), DistanceInMeters = 3658.160848459347,
                    DurationInSeconds = 3328.9196944973796, RecordId = 26
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766853120000000), DistanceInMeters = 9977.023381874047,
                    DurationInSeconds = 19176.950462352655, RecordId = 27
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766887680000000), DistanceInMeters = 8717.4390860912,
                    DurationInSeconds = 12618.411892902368, RecordId = 28
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766922240000000), DistanceInMeters = 5475.730044022927,
                    DurationInSeconds = 2144.941256237017, RecordId = 29
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766956800000000), DistanceInMeters = 6663.966784251589,
                    DurationInSeconds = 1107.6638397282593, RecordId = 30
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637766991360000000), DistanceInMeters = 3123.0970748557033,
                    DurationInSeconds = 14060.133882145585, RecordId = 31
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767025920000000), DistanceInMeters = 400.5093894165253,
                    DurationInSeconds = 10172.076180184618, RecordId = 32
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767060480000000), DistanceInMeters = 3091.646128897442,
                    DurationInSeconds = 12607.520064879613, RecordId = 33
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767095040000000), DistanceInMeters = 7747.943003382399,
                    DurationInSeconds = 16703.7781761953, RecordId = 34
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767129600000000), DistanceInMeters = 8590.984058264525,
                    DurationInSeconds = 9343.207841661335, RecordId = 35
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767164160000000), DistanceInMeters = 7683.076315404747,
                    DurationInSeconds = 1372.817695523986, RecordId = 36
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767198720000000), DistanceInMeters = 7959.757304154978,
                    DurationInSeconds = 19024.331186162544, RecordId = 37
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767233280000000), DistanceInMeters = 8627.881344221736,
                    DurationInSeconds = 5206.634084992964, RecordId = 38
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767267840000000), DistanceInMeters = 9189.67734668277,
                    DurationInSeconds = 19222.691198697346, RecordId = 39
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767302400000000), DistanceInMeters = 9093.49610799246,
                    DurationInSeconds = 6121.177375858242, RecordId = 40
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767336960000000), DistanceInMeters = 4558.1206629848175,
                    DurationInSeconds = 9889.74892047182, RecordId = 41
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767371520000000), DistanceInMeters = 2221.0329584239616,
                    DurationInSeconds = 4976.6518987799445, RecordId = 42
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767406080000000), DistanceInMeters = 4438.046538000865,
                    DurationInSeconds = 13657.420966345295, RecordId = 43
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767440640000000), DistanceInMeters = 9103.86729502258,
                    DurationInSeconds = 14386.643545201263, RecordId = 44
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767475200000000), DistanceInMeters = 8123.1169578144245,
                    DurationInSeconds = 11871.334266849912, RecordId = 45
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767509760000000), DistanceInMeters = 3559.488704312842,
                    DurationInSeconds = 10111.185895936178, RecordId = 46
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767544320000000), DistanceInMeters = 8402.274905532953,
                    DurationInSeconds = 2286.2892778282794, RecordId = 47
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767578880000000), DistanceInMeters = 731.9017014774821,
                    DurationInSeconds = 13211.24389845853, RecordId = 48
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767613440000000), DistanceInMeters = 3777.6472711652295,
                    DurationInSeconds = 19680.976008499725, RecordId = 49
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767648000000000), DistanceInMeters = 5213.299279954779,
                    DurationInSeconds = 12168.605967758067, RecordId = 50
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767682560000000), DistanceInMeters = 5872.236371352787,
                    DurationInSeconds = 3485.747033796778, RecordId = 51
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767717120000000), DistanceInMeters = 6204.437532088809,
                    DurationInSeconds = 4335.846696516393, RecordId = 52
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767751680000000), DistanceInMeters = 4934.605789608318,
                    DurationInSeconds = 14399.524761545035, RecordId = 53
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767786240000000), DistanceInMeters = 1051.6242608241641,
                    DurationInSeconds = 3202.445044718853, RecordId = 54
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767820800000000), DistanceInMeters = 9167.807631865513,
                    DurationInSeconds = 10620.121862166296, RecordId = 55
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767855360000000), DistanceInMeters = 5447.117768683683,
                    DurationInSeconds = 19994.51754841995, RecordId = 56
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767889920000000), DistanceInMeters = 8163.206695185088,
                    DurationInSeconds = 13864.20724009854, RecordId = 57
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767924480000000), DistanceInMeters = 6382.872277064428,
                    DurationInSeconds = 18298.018985231694, RecordId = 58
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767959040000000), DistanceInMeters = 3962.565286521412,
                    DurationInSeconds = 19700.037944135045, RecordId = 59
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637767993600000000), DistanceInMeters = 5635.927737287924,
                    DurationInSeconds = 12459.501255977, RecordId = 60
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768028160000000), DistanceInMeters = 3300.1788619733898,
                    DurationInSeconds = 4844.431046446597, RecordId = 61
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768062720000000), DistanceInMeters = 7240.418430846163,
                    DurationInSeconds = 8178.818396575875, RecordId = 62
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768097280000000), DistanceInMeters = 6800.931856169921,
                    DurationInSeconds = 5337.774548749306, RecordId = 63
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768131840000000), DistanceInMeters = 9879.658354766003,
                    DurationInSeconds = 12077.354083611599, RecordId = 64
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768166400000000), DistanceInMeters = 8700.102587104007,
                    DurationInSeconds = 17464.894274446815, RecordId = 65
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768200960000000), DistanceInMeters = 4130.13449906732,
                    DurationInSeconds = 6916.511797471326, RecordId = 66
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768235520000000), DistanceInMeters = 2390.870793134901,
                    DurationInSeconds = 9417.461614232943, RecordId = 67
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768270080000000), DistanceInMeters = 4122.339751854684,
                    DurationInSeconds = 18829.645695614334, RecordId = 68
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768304640000000), DistanceInMeters = 7618.5066210117575,
                    DurationInSeconds = 15159.359752570484, RecordId = 69
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768339200000000), DistanceInMeters = 3563.0292989851405,
                    DurationInSeconds = 4475.873461072759, RecordId = 70
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768373760000000), DistanceInMeters = 8545.519569220527,
                    DurationInSeconds = 13498.101618060171, RecordId = 71
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768408320000000), DistanceInMeters = 7938.901488775583,
                    DurationInSeconds = 19067.1799511981, RecordId = 72
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768442880000000), DistanceInMeters = 2725.902010402199,
                    DurationInSeconds = 296.9291409727555, RecordId = 73
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768477440000000), DistanceInMeters = 6401.878733970088,
                    DurationInSeconds = 8163.37520327166, RecordId = 74
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768512000000000), DistanceInMeters = 4704.202352190658,
                    DurationInSeconds = 11304.760343701346, RecordId = 75
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768546560000000), DistanceInMeters = 7506.409594862125,
                    DurationInSeconds = 4395.058372416126, RecordId = 76
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768581120000000), DistanceInMeters = 5594.2855040498125,
                    DurationInSeconds = 14652.262950929378, RecordId = 77
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768615680000000), DistanceInMeters = 3102.4247362686847,
                    DurationInSeconds = 12363.661121134106, RecordId = 78
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768650240000000), DistanceInMeters = 1953.755715997328,
                    DurationInSeconds = 2596.43977715894, RecordId = 79
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768684800000000), DistanceInMeters = 4951.025945536299,
                    DurationInSeconds = 5377.57601072542, RecordId = 80
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768719360000000), DistanceInMeters = 5120.799033043578,
                    DurationInSeconds = 493.74352830987254, RecordId = 81
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768753920000000), DistanceInMeters = 8042.01173884004,
                    DurationInSeconds = 18947.33722735412, RecordId = 82
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768788480000000), DistanceInMeters = 8302.71294147367,
                    DurationInSeconds = 4676.744745630264, RecordId = 83
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768823040000000), DistanceInMeters = 6042.9726121963395,
                    DurationInSeconds = 9957.687569972291, RecordId = 84
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768857600000000), DistanceInMeters = 5825.961266483491,
                    DurationInSeconds = 1923.0160460457357, RecordId = 85
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768892160000000), DistanceInMeters = 876.1333140148299,
                    DurationInSeconds = 7969.074276609401, RecordId = 86
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768926720000000), DistanceInMeters = 9841.52911303855,
                    DurationInSeconds = 261.6948258680714, RecordId = 87
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768961280000000), DistanceInMeters = 6415.703630998255,
                    DurationInSeconds = 718.182843230741, RecordId = 88
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637768995840000000), DistanceInMeters = 2920.96641282324,
                    DurationInSeconds = 17999.736964536678, RecordId = 89
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769030400000000), DistanceInMeters = 5280.114345131245,
                    DurationInSeconds = 1247.3458629688732, RecordId = 90
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769064960000000), DistanceInMeters = 2316.828796268136,
                    DurationInSeconds = 9000.304975172488, RecordId = 91
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769099520000000), DistanceInMeters = 2284.7749607490955,
                    DurationInSeconds = 13575.157338474584, RecordId = 92
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769134080000000), DistanceInMeters = 700.4047934738784,
                    DurationInSeconds = 19484.8596322733, RecordId = 93
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769168640000000), DistanceInMeters = 9164.28154760136,
                    DurationInSeconds = 17772.010875920525, RecordId = 94
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769203200000000), DistanceInMeters = 3481.123747512913,
                    DurationInSeconds = 3678.1733633826248, RecordId = 95
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769237760000000), DistanceInMeters = 4094.2129615926347,
                    DurationInSeconds = 13793.339390423447, RecordId = 96
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769272320000000), DistanceInMeters = 5004.391972297065,
                    DurationInSeconds = 3565.39670612801, RecordId = 97
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769306880000000), DistanceInMeters = 9874.147200011499,
                    DurationInSeconds = 5139.1378517659505, RecordId = 98
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769341440000000), DistanceInMeters = 1865.7782821712467,
                    DurationInSeconds = 15890.873427783952, RecordId = 99
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769376000000000), DistanceInMeters = 557.7659796776477,
                    DurationInSeconds = 11044.538474109075, RecordId = 100
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769410560000000), DistanceInMeters = 3696.5489572776696,
                    DurationInSeconds = 2505.2464136101294, RecordId = 101
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769445120000000), DistanceInMeters = 390.3294767139531,
                    DurationInSeconds = 13241.562439442352, RecordId = 102
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769479680000000), DistanceInMeters = 5039.27394475713,
                    DurationInSeconds = 19436.321561756773, RecordId = 103
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769514240000000), DistanceInMeters = 6917.875029306771,
                    DurationInSeconds = 601.990127198726, RecordId = 104
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769548800000000), DistanceInMeters = 9786.228233283065,
                    DurationInSeconds = 5826.018115467769, RecordId = 105
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769583360000000), DistanceInMeters = 289.3346142281413,
                    DurationInSeconds = 16875.965168054874, RecordId = 106
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769617920000000), DistanceInMeters = 9342.990772166702,
                    DurationInSeconds = 14303.117788539123, RecordId = 107
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769652480000000), DistanceInMeters = 669.3817100727226,
                    DurationInSeconds = 1214.229134181948, RecordId = 108
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769687040000000), DistanceInMeters = 2133.2800695633737,
                    DurationInSeconds = 19620.157003552726, RecordId = 109
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769721600000000), DistanceInMeters = 7626.065030185652,
                    DurationInSeconds = 8802.30936349279, RecordId = 110
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769756160000000), DistanceInMeters = 4100.629835772192,
                    DurationInSeconds = 11482.303576294278, RecordId = 111
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769790720000000), DistanceInMeters = 3186.439734422272,
                    DurationInSeconds = 18729.953442616745, RecordId = 112
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769825280000000), DistanceInMeters = 2836.757562311414,
                    DurationInSeconds = 17267.190841897213, RecordId = 113
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769859840000000), DistanceInMeters = 4163.168211575129,
                    DurationInSeconds = 2873.822572001662, RecordId = 114
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769894400000000), DistanceInMeters = 4150.164061078077,
                    DurationInSeconds = 15089.821307220674, RecordId = 115
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769928960000000), DistanceInMeters = 4591.379759970706,
                    DurationInSeconds = 1410.1170158113673, RecordId = 116
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769963520000000), DistanceInMeters = 5717.612730727328,
                    DurationInSeconds = 19638.981747678146, RecordId = 117
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637769998080000000), DistanceInMeters = 736.3680631672338,
                    DurationInSeconds = 9640.357847721869, RecordId = 118
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770032640000000), DistanceInMeters = 1508.2592492851456,
                    DurationInSeconds = 11429.649960290533, RecordId = 119
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770067200000000), DistanceInMeters = 6966.904540790915,
                    DurationInSeconds = 1309.6442627518318, RecordId = 120
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770101760000000), DistanceInMeters = 6605.502430901757,
                    DurationInSeconds = 14929.734507399937, RecordId = 121
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770136320000000), DistanceInMeters = 8719.54349204709,
                    DurationInSeconds = 7674.817012830226, RecordId = 122
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770170880000000), DistanceInMeters = 2863.4468535544147,
                    DurationInSeconds = 1153.1113034643834, RecordId = 123
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770205440000000), DistanceInMeters = 8485.958468136614,
                    DurationInSeconds = 4255.228430694037, RecordId = 124
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770240000000000), DistanceInMeters = 9788.099729370713,
                    DurationInSeconds = 9059.365956843943, RecordId = 125
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770274560000000), DistanceInMeters = 5493.673075180632,
                    DurationInSeconds = 12192.462286506227, RecordId = 126
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770309120000000), DistanceInMeters = 3143.4476011368774,
                    DurationInSeconds = 8863.297604837686, RecordId = 127
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770343680000000), DistanceInMeters = 9117.448121380965,
                    DurationInSeconds = 8919.884785917657, RecordId = 128
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770378240000000), DistanceInMeters = 8360.099993406808,
                    DurationInSeconds = 3511.5288306059674, RecordId = 129
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770412800000000), DistanceInMeters = 796.4275412424704,
                    DurationInSeconds = 7912.3001432996325, RecordId = 130
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770447360000000), DistanceInMeters = 5118.010582842426,
                    DurationInSeconds = 2328.8306524949994, RecordId = 131
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770481920000000), DistanceInMeters = 4669.835986531424,
                    DurationInSeconds = 1196.9036722998524, RecordId = 132
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770516480000000), DistanceInMeters = 5092.80223168547,
                    DurationInSeconds = 2390.009035836063, RecordId = 133
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770551040000000), DistanceInMeters = 1375.7845353128641,
                    DurationInSeconds = 13686.147593027175, RecordId = 134
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770585600000000), DistanceInMeters = 4740.483223663667,
                    DurationInSeconds = 5442.83084387613, RecordId = 135
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770620160000000), DistanceInMeters = 9350.371986509848,
                    DurationInSeconds = 16997.45557133101, RecordId = 136
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770654720000000), DistanceInMeters = 1405.9282657679942,
                    DurationInSeconds = 17839.886833055083, RecordId = 137
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770689280000000), DistanceInMeters = 9757.883880543452,
                    DurationInSeconds = 16463.544904685274, RecordId = 138
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770723840000000), DistanceInMeters = 9804.207206818774,
                    DurationInSeconds = 12804.96091250998, RecordId = 139
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770758400000000), DistanceInMeters = 7828.830361077731,
                    DurationInSeconds = 10110.857587631657, RecordId = 140
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770792960000000), DistanceInMeters = 2763.669172660573,
                    DurationInSeconds = 10408.98806912165, RecordId = 141
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770827520000000), DistanceInMeters = 5652.805356916578,
                    DurationInSeconds = 8469.971809331351, RecordId = 142
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770862080000000), DistanceInMeters = 2608.0592397261116,
                    DurationInSeconds = 7519.351659172122, RecordId = 143
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770896640000000), DistanceInMeters = 256.7409104931632,
                    DurationInSeconds = 148.8255949620239, RecordId = 144
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770931200000000), DistanceInMeters = 585.5508560365256,
                    DurationInSeconds = 1254.212980204955, RecordId = 145
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637770965760000000), DistanceInMeters = 5204.004034101264,
                    DurationInSeconds = 19704.66992117695, RecordId = 146
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771000320000000), DistanceInMeters = 5058.302551314073,
                    DurationInSeconds = 16206.351621693228, RecordId = 147
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771034880000000), DistanceInMeters = 4885.327117940708,
                    DurationInSeconds = 15590.021496508927, RecordId = 148
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771069440000000), DistanceInMeters = 1648.1441962285483,
                    DurationInSeconds = 10778.992755451258, RecordId = 149
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771104000000000), DistanceInMeters = 4077.5759313432977,
                    DurationInSeconds = 1599.418167335887, RecordId = 150
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771138560000000), DistanceInMeters = 1610.536396052547,
                    DurationInSeconds = 4113.928020405845, RecordId = 151
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771173120000000), DistanceInMeters = 1029.8780150523507,
                    DurationInSeconds = 10414.220379880162, RecordId = 152
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771207680000000), DistanceInMeters = 3696.086863493475,
                    DurationInSeconds = 3378.8231520695913, RecordId = 153
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771242240000000), DistanceInMeters = 558.9419206542661,
                    DurationInSeconds = 2661.8513212314647, RecordId = 154
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771276800000000), DistanceInMeters = 3292.6280260860794,
                    DurationInSeconds = 18093.433563567727, RecordId = 155
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771311360000000), DistanceInMeters = 1626.4929623202397,
                    DurationInSeconds = 5854.487835468201, RecordId = 156
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771345920000000), DistanceInMeters = 3749.856257233761,
                    DurationInSeconds = 15782.300430706851, RecordId = 157
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771380480000000), DistanceInMeters = 2323.1639079706133,
                    DurationInSeconds = 19336.7328042067, RecordId = 158
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771415040000000), DistanceInMeters = 3636.1571144727636,
                    DurationInSeconds = 3967.0987438089064, RecordId = 159
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771449600000000), DistanceInMeters = 6821.010317738383,
                    DurationInSeconds = 18780.725934138944, RecordId = 160
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771484160000000), DistanceInMeters = 3560.6113156662427,
                    DurationInSeconds = 16141.459797489064, RecordId = 161
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771518720000000), DistanceInMeters = 525.8353230295093,
                    DurationInSeconds = 6103.870796234706, RecordId = 162
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771553280000000), DistanceInMeters = 4048.3028124724183,
                    DurationInSeconds = 10663.426601251838, RecordId = 163
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771587840000000), DistanceInMeters = 1383.3500167608697,
                    DurationInSeconds = 16059.367878928544, RecordId = 164
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771622400000000), DistanceInMeters = 1225.3448482154624,
                    DurationInSeconds = 12636.019558963348, RecordId = 165
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771656960000000), DistanceInMeters = 7173.794581922203,
                    DurationInSeconds = 19888.890214911946, RecordId = 166
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771691520000000), DistanceInMeters = 4121.741334389222,
                    DurationInSeconds = 13611.498502440149, RecordId = 167
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771726080000000), DistanceInMeters = 4251.446480813105,
                    DurationInSeconds = 11350.633646345292, RecordId = 168
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771760640000000), DistanceInMeters = 3942.2478875563947,
                    DurationInSeconds = 18146.984133851194, RecordId = 169
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771795200000000), DistanceInMeters = 8495.550443960836,
                    DurationInSeconds = 11320.555911947444, RecordId = 170
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771829760000000), DistanceInMeters = 2462.1311532274453,
                    DurationInSeconds = 1064.218146271081, RecordId = 171
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771864320000000), DistanceInMeters = 985.9786935043662,
                    DurationInSeconds = 15224.88286277573, RecordId = 172
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771898880000000), DistanceInMeters = 8353.268683024135,
                    DurationInSeconds = 16943.183961066796, RecordId = 173
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771933440000000), DistanceInMeters = 4059.4305276593172,
                    DurationInSeconds = 17227.0737813261, RecordId = 174
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637771968000000000), DistanceInMeters = 4043.3127312808115,
                    DurationInSeconds = 14339.583837685957, RecordId = 175
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772002560000000), DistanceInMeters = 4224.596413301808,
                    DurationInSeconds = 14892.306968617677, RecordId = 176
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772037120000000), DistanceInMeters = 5474.334837107337,
                    DurationInSeconds = 12507.854223287546, RecordId = 177
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772071680000000), DistanceInMeters = 6465.702602867536,
                    DurationInSeconds = 902.0132874370328, RecordId = 178
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772106240000000), DistanceInMeters = 7658.22809573044,
                    DurationInSeconds = 5584.979138769599, RecordId = 179
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772140800000000), DistanceInMeters = 1948.4358603784062,
                    DurationInSeconds = 426.7449168939936, RecordId = 180
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772175360000000), DistanceInMeters = 963.7878071218599,
                    DurationInSeconds = 919.1854403500473, RecordId = 181
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772209920000000), DistanceInMeters = 2446.3699537784833,
                    DurationInSeconds = 4520.839552353742, RecordId = 182
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772244480000000), DistanceInMeters = 464.75688542555383,
                    DurationInSeconds = 7752.78103806581, RecordId = 183
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772279040000000), DistanceInMeters = 8809.257686148634,
                    DurationInSeconds = 19869.59626974384, RecordId = 184
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772313600000000), DistanceInMeters = 7263.407130370036,
                    DurationInSeconds = 7233.550824712002, RecordId = 185
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772348160000000), DistanceInMeters = 4277.6405685165555,
                    DurationInSeconds = 17420.025816575624, RecordId = 186
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772382720000000), DistanceInMeters = 5960.888472485293,
                    DurationInSeconds = 17365.44025296475, RecordId = 187
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772417280000000), DistanceInMeters = 9127.455186981115,
                    DurationInSeconds = 529.3189567865983, RecordId = 188
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772451840000000), DistanceInMeters = 1999.9360941514788,
                    DurationInSeconds = 11243.818642253671, RecordId = 189
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772486400000000), DistanceInMeters = 507.3799878705639,
                    DurationInSeconds = 10913.136960880773, RecordId = 190
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772520960000000), DistanceInMeters = 8822.26152577371,
                    DurationInSeconds = 17968.944250137734, RecordId = 191
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772555520000000), DistanceInMeters = 4991.633442953719,
                    DurationInSeconds = 10561.554967854161, RecordId = 192
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772590080000000), DistanceInMeters = 535.0025407714146,
                    DurationInSeconds = 15508.732041107858, RecordId = 193
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772624640000000), DistanceInMeters = 6826.620833793248,
                    DurationInSeconds = 7457.82516992383, RecordId = 194
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772659200000000), DistanceInMeters = 7660.593515035636,
                    DurationInSeconds = 11324.253285981455, RecordId = 195
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772693760000000), DistanceInMeters = 2773.2198635252885,
                    DurationInSeconds = 11630.531420616138, RecordId = 196
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772728320000000), DistanceInMeters = 9755.062692450361,
                    DurationInSeconds = 7209.357261268563, RecordId = 197
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772762880000000), DistanceInMeters = 1894.111408795734,
                    DurationInSeconds = 12758.859208008158, RecordId = 198
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772797440000000), DistanceInMeters = 8678.066574569984,
                    DurationInSeconds = 9961.352278555372, RecordId = 199
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772832000000000), DistanceInMeters = 8775.355996692138,
                    DurationInSeconds = 10562.548730816281, RecordId = 200
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772866560000000), DistanceInMeters = 9127.103389785014,
                    DurationInSeconds = 12784.335542067736, RecordId = 201
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772901120000000), DistanceInMeters = 4421.111729043805,
                    DurationInSeconds = 3655.512552558751, RecordId = 202
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772935680000000), DistanceInMeters = 3411.387857126031,
                    DurationInSeconds = 3807.0958228618606, RecordId = 203
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637772970240000000), DistanceInMeters = 5537.579428343884,
                    DurationInSeconds = 10178.215823096147, RecordId = 204
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773004800000000), DistanceInMeters = 3394.4770942960613,
                    DurationInSeconds = 7291.355388758867, RecordId = 205
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773039360000000), DistanceInMeters = 2225.7777872634424,
                    DurationInSeconds = 9291.72383783934, RecordId = 206
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773073920000000), DistanceInMeters = 1488.664854083657,
                    DurationInSeconds = 19821.12469103819, RecordId = 207
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773108480000000), DistanceInMeters = 4038.7934617614565,
                    DurationInSeconds = 16642.83737317782, RecordId = 208
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773143040000000), DistanceInMeters = 9020.54019360997,
                    DurationInSeconds = 15130.973149158526, RecordId = 209
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773177600000000), DistanceInMeters = 1897.0650485749034,
                    DurationInSeconds = 4623.6405419687135, RecordId = 210
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773212160000000), DistanceInMeters = 6218.023677940499,
                    DurationInSeconds = 13439.202959538063, RecordId = 211
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773246720000000), DistanceInMeters = 4346.382960528864,
                    DurationInSeconds = 5670.999233423438, RecordId = 212
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773281280000000), DistanceInMeters = 7973.22801775275,
                    DurationInSeconds = 8797.286982785174, RecordId = 213
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773315840000000), DistanceInMeters = 3157.9622860368686,
                    DurationInSeconds = 5155.978203041914, RecordId = 214
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773350400000000), DistanceInMeters = 633.8434901876591,
                    DurationInSeconds = 17992.214588540337, RecordId = 215
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773384960000000), DistanceInMeters = 5500.557448724386,
                    DurationInSeconds = 5492.046235716315, RecordId = 216
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773419520000000), DistanceInMeters = 6257.772863244636,
                    DurationInSeconds = 2397.738696058291, RecordId = 217
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773454080000000), DistanceInMeters = 5801.180877136494,
                    DurationInSeconds = 3160.8323016350732, RecordId = 218
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773488640000000), DistanceInMeters = 3694.4752474488846,
                    DurationInSeconds = 4846.302956157469, RecordId = 219
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773523200000000), DistanceInMeters = 6021.739628875143,
                    DurationInSeconds = 17052.21076969916, RecordId = 220
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773557760000000), DistanceInMeters = 7233.456070998434,
                    DurationInSeconds = 6515.087445939562, RecordId = 221
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773592320000000), DistanceInMeters = 6450.297925280189,
                    DurationInSeconds = 9080.226490671494, RecordId = 222
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773626880000000), DistanceInMeters = 4207.529750338941,
                    DurationInSeconds = 1627.9634821400784, RecordId = 223
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773661440000000), DistanceInMeters = 5615.288890112187,
                    DurationInSeconds = 19654.951297180603, RecordId = 224
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773696000000000), DistanceInMeters = 1213.6148163489001,
                    DurationInSeconds = 18731.28399771147, RecordId = 225
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773730560000000), DistanceInMeters = 7681.51964255183,
                    DurationInSeconds = 13900.314522557177, RecordId = 226
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773765120000000), DistanceInMeters = 5349.733957370123,
                    DurationInSeconds = 7413.219135444025, RecordId = 227
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773799680000000), DistanceInMeters = 5751.24367025651,
                    DurationInSeconds = 7739.154908445517, RecordId = 228
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773834240000000), DistanceInMeters = 4140.302403595972,
                    DurationInSeconds = 15737.243957329323, RecordId = 229
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773868800000000), DistanceInMeters = 4373.708297050817,
                    DurationInSeconds = 5662.735527990328, RecordId = 230
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773903360000000), DistanceInMeters = 4926.117594455054,
                    DurationInSeconds = 11602.945829432698, RecordId = 231
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773937920000000), DistanceInMeters = 9449.50034942516,
                    DurationInSeconds = 16605.81925221745, RecordId = 232
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637773972480000000), DistanceInMeters = 9271.182647436646,
                    DurationInSeconds = 4333.267210168242, RecordId = 233
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774007040000000), DistanceInMeters = 8154.127653889434,
                    DurationInSeconds = 1754.4347686362855, RecordId = 234
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774041600000000), DistanceInMeters = 5926.8687775199705,
                    DurationInSeconds = 15944.476025216785, RecordId = 235
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774076160000000), DistanceInMeters = 3148.946425790532,
                    DurationInSeconds = 2301.5551767513116, RecordId = 236
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774110720000000), DistanceInMeters = 1381.0377645965104,
                    DurationInSeconds = 3726.8709222292946, RecordId = 237
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774145280000000), DistanceInMeters = 7013.646745388427,
                    DurationInSeconds = 18663.484338692815, RecordId = 238
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774179840000000), DistanceInMeters = 7897.996032077808,
                    DurationInSeconds = 5605.06239779378, RecordId = 239
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774214400000000), DistanceInMeters = 3376.1000078679594,
                    DurationInSeconds = 9048.656138900113, RecordId = 240
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774248960000000), DistanceInMeters = 508.71199105077585,
                    DurationInSeconds = 7354.845156212782, RecordId = 241
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774283520000000), DistanceInMeters = 6416.916785554657,
                    DurationInSeconds = 10683.743677930599, RecordId = 242
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774318080000000), DistanceInMeters = 5769.61617625173,
                    DurationInSeconds = 13295.291822869201, RecordId = 243
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774352640000000), DistanceInMeters = 1810.8267253178403,
                    DurationInSeconds = 9529.736844844081, RecordId = 244
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774387200000000), DistanceInMeters = 4468.513105823834,
                    DurationInSeconds = 18882.25187332433, RecordId = 245
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774421760000000), DistanceInMeters = 961.7071760569328,
                    DurationInSeconds = 1780.3534860102825, RecordId = 246
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774456320000000), DistanceInMeters = 6503.478738193816,
                    DurationInSeconds = 1207.6938215826717, RecordId = 247
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774490880000000), DistanceInMeters = 5121.393790086479,
                    DurationInSeconds = 3395.4536467752223, RecordId = 248
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774525440000000), DistanceInMeters = 4655.143118321225,
                    DurationInSeconds = 13714.319306252692, RecordId = 249
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774560000000000), DistanceInMeters = 4918.15862687823,
                    DurationInSeconds = 5165.5733724394095, RecordId = 250
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774594560000000), DistanceInMeters = 671.9319378347805,
                    DurationInSeconds = 11915.474580267864, RecordId = 251
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774629120000000), DistanceInMeters = 9649.44765305371,
                    DurationInSeconds = 4293.447755576579, RecordId = 252
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774663680000000), DistanceInMeters = 6239.882608163233,
                    DurationInSeconds = 18374.057823460815, RecordId = 253
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774698240000000), DistanceInMeters = 9887.92685107202,
                    DurationInSeconds = 2342.5161118979167, RecordId = 254
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774732800000000), DistanceInMeters = 6381.418487386701,
                    DurationInSeconds = 13494.102441407224, RecordId = 255
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774767360000000), DistanceInMeters = 3184.4142572568785,
                    DurationInSeconds = 15472.934811166777, RecordId = 256
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774801920000000), DistanceInMeters = 1935.6387511266564,
                    DurationInSeconds = 15084.847141587907, RecordId = 257
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774836480000000), DistanceInMeters = 408.3127355585725,
                    DurationInSeconds = 1815.4856532495699, RecordId = 258
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774871040000000), DistanceInMeters = 2909.1435738201285,
                    DurationInSeconds = 11944.705184236365, RecordId = 259
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774905600000000), DistanceInMeters = 8466.888543785304,
                    DurationInSeconds = 10968.328289464316, RecordId = 260
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774940160000000), DistanceInMeters = 3351.5085143183614,
                    DurationInSeconds = 497.85293657725055, RecordId = 261
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637774974720000000), DistanceInMeters = 5663.967808363446,
                    DurationInSeconds = 16548.670571846516, RecordId = 262
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775009280000000), DistanceInMeters = 8032.929356995913,
                    DurationInSeconds = 9649.750167927916, RecordId = 263
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775043840000000), DistanceInMeters = 6789.419403495451,
                    DurationInSeconds = 11393.372809883293, RecordId = 264
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775078400000000), DistanceInMeters = 500.7639469008484,
                    DurationInSeconds = 11759.871979849679, RecordId = 265
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775112960000000), DistanceInMeters = 793.768763784829,
                    DurationInSeconds = 6033.7365745916495, RecordId = 266
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775147520000000), DistanceInMeters = 2199.1342721549795,
                    DurationInSeconds = 9064.342375820777, RecordId = 267
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775182080000000), DistanceInMeters = 3125.0677514734075,
                    DurationInSeconds = 12568.12239934151, RecordId = 268
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775216640000000), DistanceInMeters = 2660.8658680455237,
                    DurationInSeconds = 17388.014816956595, RecordId = 269
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775251200000000), DistanceInMeters = 9077.716564684628,
                    DurationInSeconds = 19315.308659199418, RecordId = 270
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775285760000000), DistanceInMeters = 2275.32893941756,
                    DurationInSeconds = 12215.797947876286, RecordId = 271
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775320320000000), DistanceInMeters = 588.2663922467566,
                    DurationInSeconds = 14313.452212803635, RecordId = 272
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775354880000000), DistanceInMeters = 5145.178477044021,
                    DurationInSeconds = 8653.291179695902, RecordId = 273
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775389440000000), DistanceInMeters = 2506.1792662595676,
                    DurationInSeconds = 1996.618771707309, RecordId = 274
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775424000000000), DistanceInMeters = 2786.573094661996,
                    DurationInSeconds = 5996.6756874610555, RecordId = 275
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775458560000000), DistanceInMeters = 8138.480307438633,
                    DurationInSeconds = 12598.127395983547, RecordId = 276
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775493120000000), DistanceInMeters = 1396.4720561014924,
                    DurationInSeconds = 7824.847079503512, RecordId = 277
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775527680000000), DistanceInMeters = 3850.9192136710253,
                    DurationInSeconds = 19066.052457010548, RecordId = 278
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775562240000000), DistanceInMeters = 653.09224525633,
                    DurationInSeconds = 4747.931346765405, RecordId = 279
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775596800000000), DistanceInMeters = 8607.75615152723,
                    DurationInSeconds = 17011.369964652797, RecordId = 280
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775631360000000), DistanceInMeters = 5664.2725911270445,
                    DurationInSeconds = 14411.119974796884, RecordId = 281
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775665920000000), DistanceInMeters = 7283.069876202015,
                    DurationInSeconds = 8131.333210342687, RecordId = 282
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775700480000000), DistanceInMeters = 5550.80212316714,
                    DurationInSeconds = 8802.340178495158, RecordId = 283
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775735040000000), DistanceInMeters = 1789.4087116131345,
                    DurationInSeconds = 13533.696301450198, RecordId = 284
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775769600000000), DistanceInMeters = 784.2344208715205,
                    DurationInSeconds = 8043.125297588058, RecordId = 285
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775804160000000), DistanceInMeters = 5986.13172933827,
                    DurationInSeconds = 5709.160463977487, RecordId = 286
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775838720000000), DistanceInMeters = 2730.323964462392,
                    DurationInSeconds = 5439.120592238802, RecordId = 287
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775873280000000), DistanceInMeters = 5382.903249041411,
                    DurationInSeconds = 8382.588711972543, RecordId = 288
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775907840000000), DistanceInMeters = 8999.492685121684,
                    DurationInSeconds = 5312.767208357595, RecordId = 289
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775942400000000), DistanceInMeters = 1914.770102280193,
                    DurationInSeconds = 7484.830851766875, RecordId = 290
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637775976960000000), DistanceInMeters = 9536.487342859531,
                    DurationInSeconds = 11531.807055613064, RecordId = 291
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776011520000000), DistanceInMeters = 2641.1816562847957,
                    DurationInSeconds = 3810.969208706189, RecordId = 292
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776046080000000), DistanceInMeters = 9116.602979199513,
                    DurationInSeconds = 13634.813321557698, RecordId = 293
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776080640000000), DistanceInMeters = 984.0494744217384,
                    DurationInSeconds = 16581.974637892523, RecordId = 294
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776115200000000), DistanceInMeters = 1050.8960696104268,
                    DurationInSeconds = 19471.78207490748, RecordId = 295
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776149760000000), DistanceInMeters = 2833.6673485234896,
                    DurationInSeconds = 15849.654064364344, RecordId = 296
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776184320000000), DistanceInMeters = 8586.92569828347,
                    DurationInSeconds = 8410.120576243728, RecordId = 297
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776218880000000), DistanceInMeters = 2516.72193057735,
                    DurationInSeconds = 15101.302149124991, RecordId = 298
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776253440000000), DistanceInMeters = 415.6728521424421,
                    DurationInSeconds = 5192.486900823175, RecordId = 299
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776288000000000), DistanceInMeters = 6304.2455776763045,
                    DurationInSeconds = 4516.846030385518, RecordId = 300
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776322560000000), DistanceInMeters = 3308.2841090430143,
                    DurationInSeconds = 10284.146358734972, RecordId = 301
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776357120000000), DistanceInMeters = 6145.995516804257,
                    DurationInSeconds = 6091.450330534044, RecordId = 302
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776391680000000), DistanceInMeters = 7461.3407238585505,
                    DurationInSeconds = 16464.546798730014, RecordId = 303
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776426240000000), DistanceInMeters = 3711.0120171095127,
                    DurationInSeconds = 16904.463162489476, RecordId = 304
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776460800000000), DistanceInMeters = 4794.377386754514,
                    DurationInSeconds = 2522.182654409266, RecordId = 305
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776495360000000), DistanceInMeters = 9605.455457334325,
                    DurationInSeconds = 4941.970805129709, RecordId = 306
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776529920000000), DistanceInMeters = 5149.683614414733,
                    DurationInSeconds = 9476.499854732761, RecordId = 307
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776564480000000), DistanceInMeters = 385.41189860070585,
                    DurationInSeconds = 7506.376783886716, RecordId = 308
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776599040000000), DistanceInMeters = 3300.5992970674447,
                    DurationInSeconds = 14210.188925767925, RecordId = 309
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776633600000000), DistanceInMeters = 7802.230199467407,
                    DurationInSeconds = 5440.62302424838, RecordId = 310
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776668160000000), DistanceInMeters = 7196.824643237211,
                    DurationInSeconds = 5448.521138943843, RecordId = 311
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776702720000000), DistanceInMeters = 5515.578015912812,
                    DurationInSeconds = 2614.6607947456337, RecordId = 312
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776737280000000), DistanceInMeters = 355.05418730205815,
                    DurationInSeconds = 1374.7371944602355, RecordId = 313
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776771840000000), DistanceInMeters = 1286.3682913166776,
                    DurationInSeconds = 19486.854979095777, RecordId = 314
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776806400000000), DistanceInMeters = 9791.582646681833,
                    DurationInSeconds = 16118.89667810569, RecordId = 315
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776840960000000), DistanceInMeters = 5671.936332023621,
                    DurationInSeconds = 19167.43732640208, RecordId = 316
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776875520000000), DistanceInMeters = 3808.578672981796,
                    DurationInSeconds = 3031.2696425960607, RecordId = 317
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776910080000000), DistanceInMeters = 2856.3496756398,
                    DurationInSeconds = 6485.947373465909, RecordId = 318
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776944640000000), DistanceInMeters = 5301.459381649027,
                    DurationInSeconds = 8814.911222338305, RecordId = 319
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637776979200000000), DistanceInMeters = 5550.482537625438,
                    DurationInSeconds = 7809.063613313314, RecordId = 320
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777013760000000), DistanceInMeters = 2363.1924673046647,
                    DurationInSeconds = 8444.185754820874, RecordId = 321
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777048320000000), DistanceInMeters = 7365.370261225666,
                    DurationInSeconds = 12213.926353555813, RecordId = 322
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777082880000000), DistanceInMeters = 635.2059508895346,
                    DurationInSeconds = 7374.560524075466, RecordId = 323
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777117440000000), DistanceInMeters = 7945.751563283963,
                    DurationInSeconds = 4463.969662747314, RecordId = 324
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777152000000000), DistanceInMeters = 9776.351186644326,
                    DurationInSeconds = 19229.38619619624, RecordId = 325
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777186560000000), DistanceInMeters = 2920.541731593764,
                    DurationInSeconds = 4736.445973823982, RecordId = 326
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777221120000000), DistanceInMeters = 2514.5285876449043,
                    DurationInSeconds = 14231.559711913289, RecordId = 327
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777255680000000), DistanceInMeters = 4042.164414464912,
                    DurationInSeconds = 10252.027422187246, RecordId = 328
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777290240000000), DistanceInMeters = 5805.095906048263,
                    DurationInSeconds = 17498.631029276254, RecordId = 329
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777324800000000), DistanceInMeters = 6788.587135322788,
                    DurationInSeconds = 14362.60846698324, RecordId = 330
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777359360000000), DistanceInMeters = 8157.350139648769,
                    DurationInSeconds = 7118.355412321055, RecordId = 331
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777393920000000), DistanceInMeters = 3859.927371199851,
                    DurationInSeconds = 19305.46885267784, RecordId = 332
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777428480000000), DistanceInMeters = 9210.414477704,
                    DurationInSeconds = 9912.660795813039, RecordId = 333
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777463040000000), DistanceInMeters = 669.0277032629813,
                    DurationInSeconds = 8027.463730080658, RecordId = 334
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777497600000000), DistanceInMeters = 6586.778074351586,
                    DurationInSeconds = 15990.026284549756, RecordId = 335
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777532160000000), DistanceInMeters = 7146.221931583483,
                    DurationInSeconds = 17086.814065776372, RecordId = 336
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777566720000000), DistanceInMeters = 4509.04215183948,
                    DurationInSeconds = 8350.988526519654, RecordId = 337
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777601280000000), DistanceInMeters = 2967.039686631185,
                    DurationInSeconds = 3176.2176936495334, RecordId = 338
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777635840000000), DistanceInMeters = 4290.328681568547,
                    DurationInSeconds = 18046.492314753432, RecordId = 339
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777670400000000), DistanceInMeters = 3107.32842710215,
                    DurationInSeconds = 18276.12526653301, RecordId = 340
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777704960000000), DistanceInMeters = 1701.5737854530691,
                    DurationInSeconds = 11441.98423924475, RecordId = 341
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777739520000000), DistanceInMeters = 5592.374600871869,
                    DurationInSeconds = 12748.030217421347, RecordId = 342
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777774080000000), DistanceInMeters = 3770.452167674137,
                    DurationInSeconds = 11466.754092837298, RecordId = 343
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777808640000000), DistanceInMeters = 9793.829489376967,
                    DurationInSeconds = 5835.0218235288485, RecordId = 344
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777843200000000), DistanceInMeters = 3367.167064345606,
                    DurationInSeconds = 974.4824055519703, RecordId = 345
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777877760000000), DistanceInMeters = 5929.360445928169,
                    DurationInSeconds = 10341.162432172017, RecordId = 346
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777912320000000), DistanceInMeters = 3757.270253655887,
                    DurationInSeconds = 19447.715868481377, RecordId = 347
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777946880000000), DistanceInMeters = 5358.115595561422,
                    DurationInSeconds = 10166.610083801086, RecordId = 348
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637777981440000000), DistanceInMeters = 7892.1021658164755,
                    DurationInSeconds = 17791.88294729524, RecordId = 349
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778016000000000), DistanceInMeters = 3473.398254036081,
                    DurationInSeconds = 3006.6118749656825, RecordId = 350
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778050560000000), DistanceInMeters = 1258.050419475712,
                    DurationInSeconds = 19302.62410337411, RecordId = 351
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778085120000000), DistanceInMeters = 1998.5613851735777,
                    DurationInSeconds = 8516.094174988279, RecordId = 352
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778119680000000), DistanceInMeters = 7371.566004620012,
                    DurationInSeconds = 236.28109764559008, RecordId = 353
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778154240000000), DistanceInMeters = 3984.2145100925763,
                    DurationInSeconds = 2765.7366119430576, RecordId = 354
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778188800000000), DistanceInMeters = 5930.66835266134,
                    DurationInSeconds = 14687.694350613814, RecordId = 355
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778223360000000), DistanceInMeters = 6961.144251857745,
                    DurationInSeconds = 5467.11938108147, RecordId = 356
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778257920000000), DistanceInMeters = 9476.681728459156,
                    DurationInSeconds = 14724.740149704272, RecordId = 357
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778292480000000), DistanceInMeters = 4607.714980525799,
                    DurationInSeconds = 3190.6620634005176, RecordId = 358
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778327040000000), DistanceInMeters = 8252.607781525934,
                    DurationInSeconds = 9903.487638078414, RecordId = 359
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778361600000000), DistanceInMeters = 4463.947333365454,
                    DurationInSeconds = 6903.904120860925, RecordId = 360
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778396160000000), DistanceInMeters = 833.3957589356908,
                    DurationInSeconds = 13186.135211962812, RecordId = 361
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778430720000000), DistanceInMeters = 1753.2185576520012,
                    DurationInSeconds = 3708.432174434783, RecordId = 362
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778465280000000), DistanceInMeters = 9036.565521849172,
                    DurationInSeconds = 18358.449056107627, RecordId = 363
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778499840000000), DistanceInMeters = 5236.550816923604,
                    DurationInSeconds = 13285.619853832364, RecordId = 364
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778534400000000), DistanceInMeters = 1812.8026794802606,
                    DurationInSeconds = 16670.59175849716, RecordId = 365
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778568960000000), DistanceInMeters = 7834.991977600341,
                    DurationInSeconds = 2735.3956685638277, RecordId = 366
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778603520000000), DistanceInMeters = 7384.871896772282,
                    DurationInSeconds = 7087.546669017376, RecordId = 367
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778638080000000), DistanceInMeters = 3731.253550659188,
                    DurationInSeconds = 17177.280580806168, RecordId = 368
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778672640000000), DistanceInMeters = 2327.7024465823115,
                    DurationInSeconds = 9349.836230335188, RecordId = 369
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778707200000000), DistanceInMeters = 5584.176752308502,
                    DurationInSeconds = 16439.85680400891, RecordId = 370
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778741760000000), DistanceInMeters = 7903.954342046652,
                    DurationInSeconds = 3623.84225379881, RecordId = 371
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778776320000000), DistanceInMeters = 3193.820884393553,
                    DurationInSeconds = 12673.6146212009, RecordId = 372
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778810880000000), DistanceInMeters = 4996.278979099446,
                    DurationInSeconds = 18327.621935300107, RecordId = 373
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778845440000000), DistanceInMeters = 1224.1182762462122,
                    DurationInSeconds = 4804.507329841499, RecordId = 374
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778880000000000), DistanceInMeters = 9836.070006748087,
                    DurationInSeconds = 3750.8376053408256, RecordId = 375
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778914560000000), DistanceInMeters = 7700.686630939132,
                    DurationInSeconds = 756.9442978346677, RecordId = 376
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778949120000000), DistanceInMeters = 6882.854573391349,
                    DurationInSeconds = 12606.308536906936, RecordId = 377
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637778983680000000), DistanceInMeters = 209.79438570612535,
                    DurationInSeconds = 17879.553096961274, RecordId = 378
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779018240000000), DistanceInMeters = 4559.921015667573,
                    DurationInSeconds = 16387.587543821737, RecordId = 379
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779052800000000), DistanceInMeters = 6680.734762335031,
                    DurationInSeconds = 19620.149834932818, RecordId = 380
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779087360000000), DistanceInMeters = 6894.68643973902,
                    DurationInSeconds = 1606.01487872828, RecordId = 381
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779121920000000), DistanceInMeters = 4448.11710535953,
                    DurationInSeconds = 6837.94267669066, RecordId = 382
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779156480000000), DistanceInMeters = 5698.133385708207,
                    DurationInSeconds = 16881.290027450443, RecordId = 383
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779191040000000), DistanceInMeters = 5100.146664340128,
                    DurationInSeconds = 17364.10283382693, RecordId = 384
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779225600000000), DistanceInMeters = 4318.326471995072,
                    DurationInSeconds = 13945.439930541186, RecordId = 385
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779260160000000), DistanceInMeters = 7325.614028118748,
                    DurationInSeconds = 12952.486114995294, RecordId = 386
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779294720000000), DistanceInMeters = 4036.283643939464,
                    DurationInSeconds = 18703.930876743067, RecordId = 387
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779329280000000), DistanceInMeters = 6675.8373892898235,
                    DurationInSeconds = 18047.924399755513, RecordId = 388
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779363840000000), DistanceInMeters = 8997.127946428742,
                    DurationInSeconds = 12102.069001339662, RecordId = 389
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779398400000000), DistanceInMeters = 8076.8089658705485,
                    DurationInSeconds = 1413.188022976459, RecordId = 390
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779432960000000), DistanceInMeters = 8234.432117296968,
                    DurationInSeconds = 4107.226051092262, RecordId = 391
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779467520000000), DistanceInMeters = 9896.465186256253,
                    DurationInSeconds = 9005.298399710811, RecordId = 392
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779502080000000), DistanceInMeters = 9502.630202862385,
                    DurationInSeconds = 6954.653314219152, RecordId = 393
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779536640000000), DistanceInMeters = 1718.0097146124053,
                    DurationInSeconds = 14115.879855709054, RecordId = 394
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779571200000000), DistanceInMeters = 6965.289891248513,
                    DurationInSeconds = 16898.80038064014, RecordId = 395
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779605760000000), DistanceInMeters = 8506.228267971352,
                    DurationInSeconds = 15943.32175478257, RecordId = 396
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779640320000000), DistanceInMeters = 7811.0893191077475,
                    DurationInSeconds = 10749.47160461984, RecordId = 397
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779674880000000), DistanceInMeters = 3738.8845466753583,
                    DurationInSeconds = 6275.647786084455, RecordId = 398
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779709440000000), DistanceInMeters = 504.6606919181678,
                    DurationInSeconds = 8676.43081287426, RecordId = 399
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779744000000000), DistanceInMeters = 6484.957054546578,
                    DurationInSeconds = 5029.331507642704, RecordId = 400
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779778560000000), DistanceInMeters = 9786.1609933557,
                    DurationInSeconds = 3353.1207817607533, RecordId = 401
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779813120000000), DistanceInMeters = 8696.766124109508,
                    DurationInSeconds = 17520.899481593115, RecordId = 402
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779847680000000), DistanceInMeters = 3527.316339243293,
                    DurationInSeconds = 4179.777102695685, RecordId = 403
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779882240000000), DistanceInMeters = 1289.2569912819529,
                    DurationInSeconds = 19661.243186823125, RecordId = 404
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779916800000000), DistanceInMeters = 5936.492899658911,
                    DurationInSeconds = 18695.713755672037, RecordId = 405
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779951360000000), DistanceInMeters = 4770.745050724283,
                    DurationInSeconds = 18382.223191791487, RecordId = 406
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637779985920000000), DistanceInMeters = 4723.938762483145,
                    DurationInSeconds = 19127.699199182603, RecordId = 407
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780020480000000), DistanceInMeters = 8586.970895715029,
                    DurationInSeconds = 3895.55107733245, RecordId = 408
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780055040000000), DistanceInMeters = 836.4014423831077,
                    DurationInSeconds = 11629.21655523071, RecordId = 409
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780089600000000), DistanceInMeters = 2362.824031062293,
                    DurationInSeconds = 5245.123443624268, RecordId = 410
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780124160000000), DistanceInMeters = 7509.969391282469,
                    DurationInSeconds = 8969.933776198744, RecordId = 411
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780158720000000), DistanceInMeters = 1889.6703525058665,
                    DurationInSeconds = 4082.0883376771544, RecordId = 412
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780193280000000), DistanceInMeters = 7055.710944726745,
                    DurationInSeconds = 776.0146480419189, RecordId = 413
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780227840000000), DistanceInMeters = 9156.899959612174,
                    DurationInSeconds = 18306.125221316233, RecordId = 414
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780262400000000), DistanceInMeters = 692.0354465085641,
                    DurationInSeconds = 9447.085767352615, RecordId = 415
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780296960000000), DistanceInMeters = 9286.565389920284,
                    DurationInSeconds = 12509.021427966285, RecordId = 416
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780331520000000), DistanceInMeters = 5578.911227110842,
                    DurationInSeconds = 7353.533892196373, RecordId = 417
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780366080000000), DistanceInMeters = 6664.312241900258,
                    DurationInSeconds = 2768.8495944140386, RecordId = 418
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780400640000000), DistanceInMeters = 1208.9086102166516,
                    DurationInSeconds = 4113.469851097892, RecordId = 419
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780435200000000), DistanceInMeters = 201.44427316174972,
                    DurationInSeconds = 16638.07209943034, RecordId = 420
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780469760000000), DistanceInMeters = 6018.12362994388,
                    DurationInSeconds = 10101.450724729866, RecordId = 421
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780504320000000), DistanceInMeters = 7893.418530735232,
                    DurationInSeconds = 9407.934165059436, RecordId = 422
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780538880000000), DistanceInMeters = 6508.561268340727,
                    DurationInSeconds = 16602.60171090925, RecordId = 423
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780573440000000), DistanceInMeters = 2794.068166270894,
                    DurationInSeconds = 14664.207345008524, RecordId = 424
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780608000000000), DistanceInMeters = 7068.03099383237,
                    DurationInSeconds = 15714.770492930895, RecordId = 425
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780642560000000), DistanceInMeters = 1017.1320835260351,
                    DurationInSeconds = 15479.956599908652, RecordId = 426
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780677120000000), DistanceInMeters = 9684.809084873314,
                    DurationInSeconds = 7039.024812414474, RecordId = 427
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780711680000000), DistanceInMeters = 4407.21441936523,
                    DurationInSeconds = 2050.0217318781447, RecordId = 428
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780746240000000), DistanceInMeters = 6919.361341485006,
                    DurationInSeconds = 17555.60930368973, RecordId = 429
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780780800000000), DistanceInMeters = 5090.237705135673,
                    DurationInSeconds = 10896.440219464197, RecordId = 430
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780815360000000), DistanceInMeters = 6858.296641398395,
                    DurationInSeconds = 12179.054173365175, RecordId = 431
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780849920000000), DistanceInMeters = 5567.028380170262,
                    DurationInSeconds = 5635.99428976398, RecordId = 432
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780884480000000), DistanceInMeters = 8302.39531931233,
                    DurationInSeconds = 7586.814563861599, RecordId = 433
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780919040000000), DistanceInMeters = 3272.168127786814,
                    DurationInSeconds = 9569.002331018068, RecordId = 434
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780953600000000), DistanceInMeters = 5840.5295216513405,
                    DurationInSeconds = 16038.20969665114, RecordId = 435
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637780988160000000), DistanceInMeters = 9790.793099331591,
                    DurationInSeconds = 11088.254163478287, RecordId = 436
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781022720000000), DistanceInMeters = 8142.152561282954,
                    DurationInSeconds = 11715.486338970912, RecordId = 437
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781057280000000), DistanceInMeters = 4077.2272941903116,
                    DurationInSeconds = 10084.218258990779, RecordId = 438
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781091840000000), DistanceInMeters = 3941.059698140966,
                    DurationInSeconds = 17582.247098170526, RecordId = 439
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781126400000000), DistanceInMeters = 875.6598934370411,
                    DurationInSeconds = 9105.804733115794, RecordId = 440
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781160960000000), DistanceInMeters = 6589.020362824309,
                    DurationInSeconds = 18179.072410824367, RecordId = 441
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781195520000000), DistanceInMeters = 2988.8483418871247,
                    DurationInSeconds = 12515.036578510062, RecordId = 442
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781230080000000), DistanceInMeters = 6768.02479387536,
                    DurationInSeconds = 14877.75291703663, RecordId = 443
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781264640000000), DistanceInMeters = 7773.179634475627,
                    DurationInSeconds = 11226.727140400064, RecordId = 444
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781299200000000), DistanceInMeters = 6888.364264968823,
                    DurationInSeconds = 18256.747340524027, RecordId = 445
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781333760000000), DistanceInMeters = 6795.090079623902,
                    DurationInSeconds = 9938.80077163077, RecordId = 446
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781368320000000), DistanceInMeters = 5060.8529269794635,
                    DurationInSeconds = 11422.823090541067, RecordId = 447
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781402880000000), DistanceInMeters = 7491.609711175456,
                    DurationInSeconds = 16205.901482552445, RecordId = 448
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781437440000000), DistanceInMeters = 5196.580527900733,
                    DurationInSeconds = 6149.618921775831, RecordId = 449
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781472000000000), DistanceInMeters = 7672.710799191464,
                    DurationInSeconds = 5783.84332681308, RecordId = 450
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781506560000000), DistanceInMeters = 8052.3240675981215,
                    DurationInSeconds = 15305.934733193591, RecordId = 451
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781541120000000), DistanceInMeters = 2386.3352746496394,
                    DurationInSeconds = 17944.25728156343, RecordId = 452
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781575680000000), DistanceInMeters = 829.8736574337264,
                    DurationInSeconds = 19558.456248637995, RecordId = 453
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781610240000000), DistanceInMeters = 473.98533190340163,
                    DurationInSeconds = 11718.55972380463, RecordId = 454
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781644800000000), DistanceInMeters = 6942.97239802564,
                    DurationInSeconds = 785.1344775283012, RecordId = 455
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781679360000000), DistanceInMeters = 4598.054993238712,
                    DurationInSeconds = 15698.815703783199, RecordId = 456
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781713920000000), DistanceInMeters = 6505.402893586947,
                    DurationInSeconds = 17429.449389256784, RecordId = 457
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781748480000000), DistanceInMeters = 2059.013541384039,
                    DurationInSeconds = 2129.8321286832256, RecordId = 458
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781783040000000), DistanceInMeters = 7791.2751053242855,
                    DurationInSeconds = 12282.629717047637, RecordId = 459
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781817600000000), DistanceInMeters = 4443.568019610973,
                    DurationInSeconds = 469.131778404625, RecordId = 460
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781852160000000), DistanceInMeters = 3412.448818044209,
                    DurationInSeconds = 16690.599982169057, RecordId = 461
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781886720000000), DistanceInMeters = 390.35405582858124,
                    DurationInSeconds = 7853.788578618695, RecordId = 462
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781921280000000), DistanceInMeters = 9286.287047848233,
                    DurationInSeconds = 10771.337434404171, RecordId = 463
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781955840000000), DistanceInMeters = 6013.787755611133,
                    DurationInSeconds = 2245.4093993645433, RecordId = 464
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637781990400000000), DistanceInMeters = 7861.563994576432,
                    DurationInSeconds = 15717.985547262831, RecordId = 465
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782024960000000), DistanceInMeters = 5088.453489672556,
                    DurationInSeconds = 6613.496544140081, RecordId = 466
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782059520000000), DistanceInMeters = 9137.64608045365,
                    DurationInSeconds = 6181.264339080667, RecordId = 467
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782094080000000), DistanceInMeters = 6579.80079687776,
                    DurationInSeconds = 17706.593059153336, RecordId = 468
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782128640000000), DistanceInMeters = 5563.705528415956,
                    DurationInSeconds = 6733.272520167616, RecordId = 469
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782163200000000), DistanceInMeters = 2797.959192798298,
                    DurationInSeconds = 14025.252716899959, RecordId = 470
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782197760000000), DistanceInMeters = 768.7976066768034,
                    DurationInSeconds = 6252.472193045451, RecordId = 471
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782232320000000), DistanceInMeters = 817.707576922562,
                    DurationInSeconds = 6673.507118516137, RecordId = 472
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782266880000000), DistanceInMeters = 9835.075095932303,
                    DurationInSeconds = 7918.952939850217, RecordId = 473
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782301440000000), DistanceInMeters = 1177.8065964381103,
                    DurationInSeconds = 5314.875011960486, RecordId = 474
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782336000000000), DistanceInMeters = 7008.496914760133,
                    DurationInSeconds = 12110.271176451255, RecordId = 475
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782370560000000), DistanceInMeters = 4437.4718215573575,
                    DurationInSeconds = 17801.648632626613, RecordId = 476
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782405120000000), DistanceInMeters = 1324.547885860989,
                    DurationInSeconds = 9341.635581521083, RecordId = 477
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782439680000000), DistanceInMeters = 8181.364269855518,
                    DurationInSeconds = 13398.247194563028, RecordId = 478
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782474240000000), DistanceInMeters = 2384.0915418686163,
                    DurationInSeconds = 15745.025505734653, RecordId = 479
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782508800000000), DistanceInMeters = 5559.039515017081,
                    DurationInSeconds = 5717.523096766951, RecordId = 480
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782543360000000), DistanceInMeters = 5809.350615034387,
                    DurationInSeconds = 11701.406229197622, RecordId = 481
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782577920000000), DistanceInMeters = 3005.1214537734736,
                    DurationInSeconds = 4353.345132526817, RecordId = 482
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782612480000000), DistanceInMeters = 5296.118835685273,
                    DurationInSeconds = 6236.290896467703, RecordId = 483
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782647040000000), DistanceInMeters = 3636.7999002836395,
                    DurationInSeconds = 461.4936551795942, RecordId = 484
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782681600000000), DistanceInMeters = 3032.0148802942335,
                    DurationInSeconds = 19034.967575612398, RecordId = 485
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782716160000000), DistanceInMeters = 1899.1777782996583,
                    DurationInSeconds = 18386.01693238065, RecordId = 486
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782750720000000), DistanceInMeters = 8743.893509356507,
                    DurationInSeconds = 1810.7986096248333, RecordId = 487
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782785280000000), DistanceInMeters = 8415.166956310948,
                    DurationInSeconds = 4505.84140259931, RecordId = 488
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782819840000000), DistanceInMeters = 8066.4201936120435,
                    DurationInSeconds = 16087.009577932693, RecordId = 489
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782854400000000), DistanceInMeters = 212.95079715928068,
                    DurationInSeconds = 14835.349263914632, RecordId = 490
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782888960000000), DistanceInMeters = 7447.8926493301315,
                    DurationInSeconds = 11126.328194310792, RecordId = 491
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782923520000000), DistanceInMeters = 4839.212862436709,
                    DurationInSeconds = 8813.61518372404, RecordId = 492
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782958080000000), DistanceInMeters = 8719.334613975416,
                    DurationInSeconds = 4133.5511953875575, RecordId = 493
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637782992640000000), DistanceInMeters = 5016.423204827156,
                    DurationInSeconds = 15277.965474814217, RecordId = 494
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783027200000000), DistanceInMeters = 5744.839697930296,
                    DurationInSeconds = 18754.396504986285, RecordId = 495
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783061760000000), DistanceInMeters = 5828.288806400541,
                    DurationInSeconds = 16140.000763302482, RecordId = 496
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783096320000000), DistanceInMeters = 9692.764824918371,
                    DurationInSeconds = 7334.78168252075, RecordId = 497
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783130880000000), DistanceInMeters = 2634.718139835334,
                    DurationInSeconds = 6484.917164745328, RecordId = 498
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783165440000000), DistanceInMeters = 5998.333500340156,
                    DurationInSeconds = 12706.5872833838, RecordId = 499
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783200000000000), DistanceInMeters = 5230.344360408537,
                    DurationInSeconds = 19113.755594954844, RecordId = 500
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783234560000000), DistanceInMeters = 4922.276553159394,
                    DurationInSeconds = 16510.162253398237, RecordId = 501
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783269120000000), DistanceInMeters = 5871.842218658974,
                    DurationInSeconds = 8800.255528715601, RecordId = 502
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783303680000000), DistanceInMeters = 928.2427549115728,
                    DurationInSeconds = 6523.217920967618, RecordId = 503
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783338240000000), DistanceInMeters = 7464.2425806500705,
                    DurationInSeconds = 14289.121393436913, RecordId = 504
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783372800000000), DistanceInMeters = 7388.555348251859,
                    DurationInSeconds = 6134.131430803852, RecordId = 505
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783407360000000), DistanceInMeters = 8014.042079536342,
                    DurationInSeconds = 2030.4046650315704, RecordId = 506
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783441920000000), DistanceInMeters = 7161.329642590884,
                    DurationInSeconds = 4882.998452610208, RecordId = 507
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783476480000000), DistanceInMeters = 6765.132544017886,
                    DurationInSeconds = 12326.638189214449, RecordId = 508
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783511040000000), DistanceInMeters = 9949.789532019062,
                    DurationInSeconds = 9754.734687221491, RecordId = 509
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783545600000000), DistanceInMeters = 6072.276293958514,
                    DurationInSeconds = 13426.89148081103, RecordId = 510
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783580160000000), DistanceInMeters = 2932.7712347138076,
                    DurationInSeconds = 11137.327209549749, RecordId = 511
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783614720000000), DistanceInMeters = 2877.315845700568,
                    DurationInSeconds = 14406.306645445595, RecordId = 512
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783649280000000), DistanceInMeters = 7037.619743194383,
                    DurationInSeconds = 8072.610975114157, RecordId = 513
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783683840000000), DistanceInMeters = 601.175181657708,
                    DurationInSeconds = 9091.135612789718, RecordId = 514
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783718400000000), DistanceInMeters = 8024.044904808134,
                    DurationInSeconds = 2847.8557639343894, RecordId = 515
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783752960000000), DistanceInMeters = 5623.85367674593,
                    DurationInSeconds = 13945.025459699333, RecordId = 516
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783787520000000), DistanceInMeters = 2110.349302437882,
                    DurationInSeconds = 1263.3141175694066, RecordId = 517
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783822080000000), DistanceInMeters = 2385.7225286308794,
                    DurationInSeconds = 7066.159484831904, RecordId = 518
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783856640000000), DistanceInMeters = 9372.321294736597,
                    DurationInSeconds = 8925.470702866125, RecordId = 519
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783891200000000), DistanceInMeters = 8389.196904457218,
                    DurationInSeconds = 14913.13299618533, RecordId = 520
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783925760000000), DistanceInMeters = 3639.66438101313,
                    DurationInSeconds = 16291.317642131033, RecordId = 521
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783960320000000), DistanceInMeters = 1100.522166514735,
                    DurationInSeconds = 19072.396932605527, RecordId = 522
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637783994880000000), DistanceInMeters = 7857.114877035424,
                    DurationInSeconds = 120.36057043123682, RecordId = 523
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784029440000000), DistanceInMeters = 4269.94669791196,
                    DurationInSeconds = 279.61373665342023, RecordId = 524
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784064000000000), DistanceInMeters = 840.8395441976958,
                    DurationInSeconds = 7605.954821021593, RecordId = 525
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784098560000000), DistanceInMeters = 6258.815263168314,
                    DurationInSeconds = 194.37007987634263, RecordId = 526
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784133120000000), DistanceInMeters = 3312.0250271356813,
                    DurationInSeconds = 224.7619694326421, RecordId = 527
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784167680000000), DistanceInMeters = 6215.967375456395,
                    DurationInSeconds = 9544.16825965423, RecordId = 528
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784202240000000), DistanceInMeters = 6495.102989996714,
                    DurationInSeconds = 121.9638669681564, RecordId = 529
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784236800000000), DistanceInMeters = 3853.6061021264627,
                    DurationInSeconds = 3592.7040330645723, RecordId = 530
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784271360000000), DistanceInMeters = 9441.613026043276,
                    DurationInSeconds = 5776.956201846046, RecordId = 531
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784305920000000), DistanceInMeters = 2631.3127093138,
                    DurationInSeconds = 16599.96632069572, RecordId = 532
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784340480000000), DistanceInMeters = 585.2676226795451,
                    DurationInSeconds = 16702.037674145162, RecordId = 533
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784375040000000), DistanceInMeters = 7679.1277962456115,
                    DurationInSeconds = 5417.645887054378, RecordId = 534
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784409600000000), DistanceInMeters = 8670.012260465328,
                    DurationInSeconds = 12335.128456223969, RecordId = 535
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784444160000000), DistanceInMeters = 710.3080009108191,
                    DurationInSeconds = 1893.9114628270324, RecordId = 536
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784478720000000), DistanceInMeters = 6499.238443770848,
                    DurationInSeconds = 16422.753236501107, RecordId = 537
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784513280000000), DistanceInMeters = 5245.896702129688,
                    DurationInSeconds = 14353.512766157888, RecordId = 538
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784547840000000), DistanceInMeters = 8302.278257321464,
                    DurationInSeconds = 4267.808230495244, RecordId = 539
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784582400000000), DistanceInMeters = 5775.959090591526,
                    DurationInSeconds = 10077.873026010251, RecordId = 540
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784616960000000), DistanceInMeters = 6124.143045014018,
                    DurationInSeconds = 6898.487877506017, RecordId = 541
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784651520000000), DistanceInMeters = 1673.9281983692372,
                    DurationInSeconds = 13647.184409052488, RecordId = 542
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784686080000000), DistanceInMeters = 5971.793836066193,
                    DurationInSeconds = 17829.318009019244, RecordId = 543
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784720640000000), DistanceInMeters = 7987.217089924108,
                    DurationInSeconds = 1998.0752186610612, RecordId = 544
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784755200000000), DistanceInMeters = 1346.6697762752394,
                    DurationInSeconds = 18067.5585610449, RecordId = 545
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784789760000000), DistanceInMeters = 4449.496347817873,
                    DurationInSeconds = 5981.163254387528, RecordId = 546
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784824320000000), DistanceInMeters = 5719.6558978533285,
                    DurationInSeconds = 483.408980285533, RecordId = 547
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784858880000000), DistanceInMeters = 2175.666146845102,
                    DurationInSeconds = 7074.257550414762, RecordId = 548
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784893440000000), DistanceInMeters = 520.7811400954993,
                    DurationInSeconds = 10980.477592100322, RecordId = 549
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784928000000000), DistanceInMeters = 7034.666510705203,
                    DurationInSeconds = 10505.641852267609, RecordId = 550
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784962560000000), DistanceInMeters = 1023.5071659955144,
                    DurationInSeconds = 14667.74795956366, RecordId = 551
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637784997120000000), DistanceInMeters = 2308.5789784677454,
                    DurationInSeconds = 4624.897085316427, RecordId = 552
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785031680000000), DistanceInMeters = 2379.4222041779226,
                    DurationInSeconds = 19147.781961277436, RecordId = 553
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785066240000000), DistanceInMeters = 413.3608636302753,
                    DurationInSeconds = 1080.3427376545258, RecordId = 554
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785100800000000), DistanceInMeters = 6535.322313964249,
                    DurationInSeconds = 11167.469717711574, RecordId = 555
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785135360000000), DistanceInMeters = 671.2434792871504,
                    DurationInSeconds = 6172.087599104247, RecordId = 556
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785169920000000), DistanceInMeters = 8820.68690921564,
                    DurationInSeconds = 15953.005141867883, RecordId = 557
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785204480000000), DistanceInMeters = 4858.74567244953,
                    DurationInSeconds = 9907.703382508942, RecordId = 558
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785239040000000), DistanceInMeters = 3727.2066305533654,
                    DurationInSeconds = 9079.269829597128, RecordId = 559
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785273600000000), DistanceInMeters = 8537.851898206227,
                    DurationInSeconds = 317.28292002683645, RecordId = 560
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785308160000000), DistanceInMeters = 8462.407065690537,
                    DurationInSeconds = 9885.516972173544, RecordId = 561
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785342720000000), DistanceInMeters = 1188.802669310707,
                    DurationInSeconds = 10725.094402314757, RecordId = 562
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785377280000000), DistanceInMeters = 573.3655085154245,
                    DurationInSeconds = 1251.4671840657127, RecordId = 563
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785411840000000), DistanceInMeters = 9626.00713429012,
                    DurationInSeconds = 14763.563778961243, RecordId = 564
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785446400000000), DistanceInMeters = 5612.712101128386,
                    DurationInSeconds = 8543.253194541181, RecordId = 565
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785480960000000), DistanceInMeters = 4685.13336422967,
                    DurationInSeconds = 12125.571405123226, RecordId = 566
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785515520000000), DistanceInMeters = 1659.116642791503,
                    DurationInSeconds = 9865.58470393602, RecordId = 567
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785550080000000), DistanceInMeters = 1271.763476405538,
                    DurationInSeconds = 19485.273957702662, RecordId = 568
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785584640000000), DistanceInMeters = 9627.75027742996,
                    DurationInSeconds = 5495.602882552383, RecordId = 569
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785619200000000), DistanceInMeters = 5512.624246538031,
                    DurationInSeconds = 15106.505782552083, RecordId = 570
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785653760000000), DistanceInMeters = 8749.741129959153,
                    DurationInSeconds = 12464.174596333662, RecordId = 571
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785688320000000), DistanceInMeters = 8705.80304997039,
                    DurationInSeconds = 2654.812044142957, RecordId = 572
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785722880000000), DistanceInMeters = 9004.700892218421,
                    DurationInSeconds = 8723.465932267527, RecordId = 573
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785757440000000), DistanceInMeters = 9786.818117006162,
                    DurationInSeconds = 1004.3013138175547, RecordId = 574
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785792000000000), DistanceInMeters = 370.02622326734,
                    DurationInSeconds = 15891.592043368479, RecordId = 575
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785826560000000), DistanceInMeters = 9412.8675758401,
                    DurationInSeconds = 18306.468978339224, RecordId = 576
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785861120000000), DistanceInMeters = 4059.8058060961353,
                    DurationInSeconds = 2614.7495423257465, RecordId = 577
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785895680000000), DistanceInMeters = 2027.4412248314118,
                    DurationInSeconds = 7677.669888679336, RecordId = 578
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785930240000000), DistanceInMeters = 8736.632573761352,
                    DurationInSeconds = 10713.046656480954, RecordId = 579
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785964800000000), DistanceInMeters = 5594.56685028191,
                    DurationInSeconds = 17136.35484928879, RecordId = 580
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637785999360000000), DistanceInMeters = 6483.013590785423,
                    DurationInSeconds = 18166.590423555084, RecordId = 581
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786033920000000), DistanceInMeters = 2996.8022303611383,
                    DurationInSeconds = 1369.8901774273852, RecordId = 582
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786068480000000), DistanceInMeters = 5254.225305136918,
                    DurationInSeconds = 8884.401875899004, RecordId = 583
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786103040000000), DistanceInMeters = 2650.7964284814816,
                    DurationInSeconds = 10349.765878484777, RecordId = 584
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786137600000000), DistanceInMeters = 5461.7807388314895,
                    DurationInSeconds = 11643.062311699445, RecordId = 585
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786172160000000), DistanceInMeters = 2179.224464796741,
                    DurationInSeconds = 8871.29747554419, RecordId = 586
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786206720000000), DistanceInMeters = 3714.651254277042,
                    DurationInSeconds = 18747.326525817974, RecordId = 587
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786241280000000), DistanceInMeters = 2400.6590023591866,
                    DurationInSeconds = 2878.378673527635, RecordId = 588
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786275840000000), DistanceInMeters = 999.4826323806963,
                    DurationInSeconds = 701.6240600540298, RecordId = 589
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786310400000000), DistanceInMeters = 3204.1681165989976,
                    DurationInSeconds = 15327.575522307327, RecordId = 590
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786344960000000), DistanceInMeters = 2594.941652506585,
                    DurationInSeconds = 17861.413035241465, RecordId = 591
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786379520000000), DistanceInMeters = 4051.8639699398827,
                    DurationInSeconds = 4984.643034594713, RecordId = 592
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786414080000000), DistanceInMeters = 6162.019387712674,
                    DurationInSeconds = 14483.351432434563, RecordId = 593
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786448640000000), DistanceInMeters = 6522.637075113031,
                    DurationInSeconds = 477.24645122169875, RecordId = 594
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786483200000000), DistanceInMeters = 5992.312998268604,
                    DurationInSeconds = 5043.660146856274, RecordId = 595
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786517760000000), DistanceInMeters = 2424.016480231181,
                    DurationInSeconds = 17130.005593905775, RecordId = 596
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786552320000000), DistanceInMeters = 6818.127246474194,
                    DurationInSeconds = 10459.624895527215, RecordId = 597
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786586880000000), DistanceInMeters = 1704.575068769742,
                    DurationInSeconds = 4583.253172075442, RecordId = 598
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786621440000000), DistanceInMeters = 8134.254382886999,
                    DurationInSeconds = 9235.921416535988, RecordId = 599
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786656000000000), DistanceInMeters = 8811.964506864679,
                    DurationInSeconds = 11163.632559182357, RecordId = 600
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786690560000000), DistanceInMeters = 6117.414585988924,
                    DurationInSeconds = 11611.313319202569, RecordId = 601
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786725120000000), DistanceInMeters = 3039.3296189226303,
                    DurationInSeconds = 11018.707553288996, RecordId = 602
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786759680000000), DistanceInMeters = 9283.090587366478,
                    DurationInSeconds = 6780.287217466974, RecordId = 603
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786794240000000), DistanceInMeters = 7517.0092622295415,
                    DurationInSeconds = 15919.461675521943, RecordId = 604
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786828800000000), DistanceInMeters = 1368.4716061595914,
                    DurationInSeconds = 14973.870257584082, RecordId = 605
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786863360000000), DistanceInMeters = 9597.024455483115,
                    DurationInSeconds = 2505.0497495238124, RecordId = 606
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786897920000000), DistanceInMeters = 6163.296068146315,
                    DurationInSeconds = 11533.874806321843, RecordId = 607
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786932480000000), DistanceInMeters = 1333.078330697835,
                    DurationInSeconds = 17084.34789322431, RecordId = 608
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637786967040000000), DistanceInMeters = 3479.8682932956594,
                    DurationInSeconds = 19500.482124632177, RecordId = 609
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787001600000000), DistanceInMeters = 3710.0498273326575,
                    DurationInSeconds = 10550.170512899042, RecordId = 610
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787036160000000), DistanceInMeters = 2748.233867295914,
                    DurationInSeconds = 8536.768943392655, RecordId = 611
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787070720000000), DistanceInMeters = 8069.713911493779,
                    DurationInSeconds = 19535.447701811492, RecordId = 612
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787105280000000), DistanceInMeters = 7849.153063641886,
                    DurationInSeconds = 19227.33392945536, RecordId = 613
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787139840000000), DistanceInMeters = 6057.232325938762,
                    DurationInSeconds = 19667.704386440677, RecordId = 614
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787174400000000), DistanceInMeters = 685.9026877953241,
                    DurationInSeconds = 16927.146624501005, RecordId = 615
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787208960000000), DistanceInMeters = 6553.321198833787,
                    DurationInSeconds = 19274.59462315026, RecordId = 616
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787243520000000), DistanceInMeters = 4116.846949459199,
                    DurationInSeconds = 13074.62896529815, RecordId = 617
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787278080000000), DistanceInMeters = 845.9104941191835,
                    DurationInSeconds = 15296.355714304418, RecordId = 618
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787312640000000), DistanceInMeters = 4454.022088764229,
                    DurationInSeconds = 1106.9530446733743, RecordId = 619
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787347200000000), DistanceInMeters = 8117.05410397077,
                    DurationInSeconds = 3991.6903615660503, RecordId = 620
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787381760000000), DistanceInMeters = 1268.4104356258713,
                    DurationInSeconds = 17949.041019699787, RecordId = 621
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787416320000000), DistanceInMeters = 1165.7064756571594,
                    DurationInSeconds = 11896.542775520073, RecordId = 622
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787450880000000), DistanceInMeters = 4869.406373146024,
                    DurationInSeconds = 15849.58306705636, RecordId = 623
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787485440000000), DistanceInMeters = 2883.225505976875,
                    DurationInSeconds = 11471.863824613958, RecordId = 624
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787520000000000), DistanceInMeters = 2413.9064956220313,
                    DurationInSeconds = 17566.307848425917, RecordId = 625
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787554560000000), DistanceInMeters = 391.8724941202913,
                    DurationInSeconds = 19930.564170029687, RecordId = 626
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787589120000000), DistanceInMeters = 4687.627525983796,
                    DurationInSeconds = 10749.154417540909, RecordId = 627
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787623680000000), DistanceInMeters = 4570.262766160348,
                    DurationInSeconds = 3740.540739895959, RecordId = 628
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787658240000000), DistanceInMeters = 7096.403734326638,
                    DurationInSeconds = 13456.642767352829, RecordId = 629
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787692800000000), DistanceInMeters = 7321.92353388445,
                    DurationInSeconds = 16919.182626581034, RecordId = 630
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787727360000000), DistanceInMeters = 9056.709401303584,
                    DurationInSeconds = 4156.100039456445, RecordId = 631
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787761920000000), DistanceInMeters = 620.9709774906514,
                    DurationInSeconds = 13086.47429417999, RecordId = 632
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787796480000000), DistanceInMeters = 3595.1947574996248,
                    DurationInSeconds = 9641.861277127058, RecordId = 633
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787831040000000), DistanceInMeters = 8885.508828994049,
                    DurationInSeconds = 2924.337841186507, RecordId = 634
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787865600000000), DistanceInMeters = 8882.280919849272,
                    DurationInSeconds = 17102.518322703054, RecordId = 635
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787900160000000), DistanceInMeters = 9848.53814084068,
                    DurationInSeconds = 11757.1870388931, RecordId = 636
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787934720000000), DistanceInMeters = 3937.7870955955827,
                    DurationInSeconds = 8541.18956685073, RecordId = 637
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637787969280000000), DistanceInMeters = 9308.00157203077,
                    DurationInSeconds = 7595.627780919037, RecordId = 638
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788003840000000), DistanceInMeters = 6613.253012471776,
                    DurationInSeconds = 14144.13075393251, RecordId = 639
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788038400000000), DistanceInMeters = 9866.317468532172,
                    DurationInSeconds = 11104.896332789394, RecordId = 640
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788072960000000), DistanceInMeters = 7044.8110295968045,
                    DurationInSeconds = 12311.456469111088, RecordId = 641
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788107520000000), DistanceInMeters = 4815.549348131071,
                    DurationInSeconds = 7310.889860027963, RecordId = 642
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788142080000000), DistanceInMeters = 6393.900598451488,
                    DurationInSeconds = 17401.989550263348, RecordId = 643
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788176640000000), DistanceInMeters = 1948.215589781186,
                    DurationInSeconds = 18985.584927571006, RecordId = 644
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788211200000000), DistanceInMeters = 722.7618994172146,
                    DurationInSeconds = 10037.793977363586, RecordId = 645
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788245760000000), DistanceInMeters = 4107.116605411798,
                    DurationInSeconds = 17311.731979724093, RecordId = 646
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788280320000000), DistanceInMeters = 6229.215440953069,
                    DurationInSeconds = 897.7379589353648, RecordId = 647
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788314880000000), DistanceInMeters = 4475.494315098661,
                    DurationInSeconds = 9909.102684497204, RecordId = 648
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788349440000000), DistanceInMeters = 6954.721738090241,
                    DurationInSeconds = 18195.396643725187, RecordId = 649
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788384000000000), DistanceInMeters = 8924.902589877165,
                    DurationInSeconds = 2510.87822399282, RecordId = 650
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788418560000000), DistanceInMeters = 9872.17751737382,
                    DurationInSeconds = 13290.785688458707, RecordId = 651
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788453120000000), DistanceInMeters = 5132.415261036054,
                    DurationInSeconds = 12310.813058640082, RecordId = 652
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788487680000000), DistanceInMeters = 7441.264106654995,
                    DurationInSeconds = 1421.779679296663, RecordId = 653
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788522240000000), DistanceInMeters = 6161.5179397643615,
                    DurationInSeconds = 17869.154486039457, RecordId = 654
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788556800000000), DistanceInMeters = 6813.267330048751,
                    DurationInSeconds = 6066.930726523685, RecordId = 655
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788591360000000), DistanceInMeters = 8369.758164597373,
                    DurationInSeconds = 17512.202149631183, RecordId = 656
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788625920000000), DistanceInMeters = 1679.796245523574,
                    DurationInSeconds = 12382.76812061556, RecordId = 657
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788660480000000), DistanceInMeters = 9150.54856545804,
                    DurationInSeconds = 8011.162325101943, RecordId = 658
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788695040000000), DistanceInMeters = 3332.76310302041,
                    DurationInSeconds = 6645.790310939574, RecordId = 659
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788729600000000), DistanceInMeters = 6653.257234781493,
                    DurationInSeconds = 14453.790444455839, RecordId = 660
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788764160000000), DistanceInMeters = 1819.8317816515603,
                    DurationInSeconds = 179.101948381226, RecordId = 661
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788798720000000), DistanceInMeters = 1914.8240601629752,
                    DurationInSeconds = 10166.490681596966, RecordId = 662
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788833280000000), DistanceInMeters = 388.41747302180704,
                    DurationInSeconds = 12783.54337201544, RecordId = 663
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788867840000000), DistanceInMeters = 2935.2725428849667,
                    DurationInSeconds = 10613.468058623, RecordId = 664
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788902400000000), DistanceInMeters = 1965.2606313121169,
                    DurationInSeconds = 8434.542396445697, RecordId = 665
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788936960000000), DistanceInMeters = 8472.966980703013,
                    DurationInSeconds = 2842.7045841093336, RecordId = 666
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637788971520000000), DistanceInMeters = 8366.338802281933,
                    DurationInSeconds = 17473.732620497838, RecordId = 667
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789006080000000), DistanceInMeters = 3365.055647829982,
                    DurationInSeconds = 7153.291382021392, RecordId = 668
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789040640000000), DistanceInMeters = 3270.135464335382,
                    DurationInSeconds = 14288.686160533129, RecordId = 669
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789075200000000), DistanceInMeters = 8772.09700826011,
                    DurationInSeconds = 18552.06159637072, RecordId = 670
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789109760000000), DistanceInMeters = 7725.000825158742,
                    DurationInSeconds = 13514.522315176382, RecordId = 671
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789144320000000), DistanceInMeters = 677.7077799603899,
                    DurationInSeconds = 10487.987606501209, RecordId = 672
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789178880000000), DistanceInMeters = 2700.6391306264313,
                    DurationInSeconds = 4746.9966905008805, RecordId = 673
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789213440000000), DistanceInMeters = 205.56232155612156,
                    DurationInSeconds = 19869.324965620668, RecordId = 674
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789248000000000), DistanceInMeters = 8158.974280271347,
                    DurationInSeconds = 14385.349261284706, RecordId = 675
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789282560000000), DistanceInMeters = 6418.640409826064,
                    DurationInSeconds = 1972.7971032656542, RecordId = 676
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789317120000000), DistanceInMeters = 1376.3808815578702,
                    DurationInSeconds = 17658.34571557268, RecordId = 677
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789351680000000), DistanceInMeters = 8882.17018422651,
                    DurationInSeconds = 588.7625521591895, RecordId = 678
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789386240000000), DistanceInMeters = 9377.791752098481,
                    DurationInSeconds = 824.0645228978882, RecordId = 679
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789420800000000), DistanceInMeters = 2843.671129904286,
                    DurationInSeconds = 15480.056562957603, RecordId = 680
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789455360000000), DistanceInMeters = 2206.2995713428913,
                    DurationInSeconds = 1525.5333875689507, RecordId = 681
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789489920000000), DistanceInMeters = 9356.896970992728,
                    DurationInSeconds = 2370.0031878991613, RecordId = 682
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789524480000000), DistanceInMeters = 7930.480457132465,
                    DurationInSeconds = 2978.739153105504, RecordId = 683
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789559040000000), DistanceInMeters = 1182.7995852925233,
                    DurationInSeconds = 7735.364917751592, RecordId = 684
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789593600000000), DistanceInMeters = 8304.614422403221,
                    DurationInSeconds = 13110.207719535876, RecordId = 685
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789628160000000), DistanceInMeters = 9278.796107601462,
                    DurationInSeconds = 4562.618112002316, RecordId = 686
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789662720000000), DistanceInMeters = 9434.671165728321,
                    DurationInSeconds = 10057.66547681837, RecordId = 687
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789697280000000), DistanceInMeters = 5686.447991763601,
                    DurationInSeconds = 9321.693306681218, RecordId = 688
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789731840000000), DistanceInMeters = 4820.8851089581,
                    DurationInSeconds = 3129.3447927391826, RecordId = 689
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789766400000000), DistanceInMeters = 1932.7756404450663,
                    DurationInSeconds = 14728.843613972636, RecordId = 690
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789800960000000), DistanceInMeters = 1935.8681327160602,
                    DurationInSeconds = 11252.6372939651, RecordId = 691
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789835520000000), DistanceInMeters = 4464.477685118413,
                    DurationInSeconds = 5614.795288694905, RecordId = 692
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789870080000000), DistanceInMeters = 5908.075913843798,
                    DurationInSeconds = 6488.906837808524, RecordId = 693
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789904640000000), DistanceInMeters = 909.5492539196724,
                    DurationInSeconds = 11149.299877278096, RecordId = 694
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789939200000000), DistanceInMeters = 2721.099224316473,
                    DurationInSeconds = 19953.14089533408, RecordId = 695
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637789973760000000), DistanceInMeters = 2377.8748350648257,
                    DurationInSeconds = 15264.798842255848, RecordId = 696
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790008320000000), DistanceInMeters = 2224.2480193536694,
                    DurationInSeconds = 15732.765058629888, RecordId = 697
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790042880000000), DistanceInMeters = 698.2607293869223,
                    DurationInSeconds = 11084.861555051091, RecordId = 698
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790077440000000), DistanceInMeters = 6761.086735170322,
                    DurationInSeconds = 6309.482422314108, RecordId = 699
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790112000000000), DistanceInMeters = 6619.961144240693,
                    DurationInSeconds = 13089.295448779581, RecordId = 700
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790146560000000), DistanceInMeters = 5797.323177781553,
                    DurationInSeconds = 7411.701225591761, RecordId = 701
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790181120000000), DistanceInMeters = 9511.72488265546,
                    DurationInSeconds = 9334.692701053973, RecordId = 702
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790215680000000), DistanceInMeters = 6426.7279863928625,
                    DurationInSeconds = 12901.626081142364, RecordId = 703
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790250240000000), DistanceInMeters = 6412.982620007447,
                    DurationInSeconds = 11177.696908550091, RecordId = 704
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790284800000000), DistanceInMeters = 3251.112349318142,
                    DurationInSeconds = 12234.931539200965, RecordId = 705
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790319360000000), DistanceInMeters = 6096.951548267483,
                    DurationInSeconds = 10407.113572222574, RecordId = 706
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790353920000000), DistanceInMeters = 459.9257678489783,
                    DurationInSeconds = 13912.628400248183, RecordId = 707
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790388480000000), DistanceInMeters = 3302.3881878708503,
                    DurationInSeconds = 6501.218922395558, RecordId = 708
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790423040000000), DistanceInMeters = 7637.312713862551,
                    DurationInSeconds = 6419.465055201746, RecordId = 709
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790457600000000), DistanceInMeters = 9980.696277864788,
                    DurationInSeconds = 19014.427093908005, RecordId = 710
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790492160000000), DistanceInMeters = 8237.502654700416,
                    DurationInSeconds = 1861.7621632074295, RecordId = 711
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790526720000000), DistanceInMeters = 4626.686414576761,
                    DurationInSeconds = 6167.222008372267, RecordId = 712
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790561280000000), DistanceInMeters = 4769.9539986736145,
                    DurationInSeconds = 19582.869216487667, RecordId = 713
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790595840000000), DistanceInMeters = 2285.9392734665025,
                    DurationInSeconds = 1254.7948010793907, RecordId = 714
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790630400000000), DistanceInMeters = 5886.381187424727,
                    DurationInSeconds = 10742.214956564807, RecordId = 715
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790664960000000), DistanceInMeters = 7185.990621677822,
                    DurationInSeconds = 7138.00350921075, RecordId = 716
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790699520000000), DistanceInMeters = 9935.407107920828,
                    DurationInSeconds = 10240.1348053558, RecordId = 717
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790734080000000), DistanceInMeters = 4309.403023625728,
                    DurationInSeconds = 14916.66359104986, RecordId = 718
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790768640000000), DistanceInMeters = 8673.140842999494,
                    DurationInSeconds = 17886.737698556477, RecordId = 719
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790803200000000), DistanceInMeters = 7706.446175444087,
                    DurationInSeconds = 3691.2784666785874, RecordId = 720
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790837760000000), DistanceInMeters = 1587.9079894380457,
                    DurationInSeconds = 5447.714404215156, RecordId = 721
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790872320000000), DistanceInMeters = 9938.707701526086,
                    DurationInSeconds = 19794.565107582355, RecordId = 722
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790906880000000), DistanceInMeters = 2310.852279821295,
                    DurationInSeconds = 11681.259098773213, RecordId = 723
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790941440000000), DistanceInMeters = 1491.3739552304178,
                    DurationInSeconds = 18702.871470503305, RecordId = 724
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637790976000000000), DistanceInMeters = 7875.707098677612,
                    DurationInSeconds = 2300.000154251625, RecordId = 725
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791010560000000), DistanceInMeters = 7048.102063696797,
                    DurationInSeconds = 11013.635774219514, RecordId = 726
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791045120000000), DistanceInMeters = 7576.580799435384,
                    DurationInSeconds = 3347.4111533881605, RecordId = 727
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791079680000000), DistanceInMeters = 8462.253789186549,
                    DurationInSeconds = 159.68104410184856, RecordId = 728
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791114240000000), DistanceInMeters = 5363.881461347205,
                    DurationInSeconds = 4541.706465860895, RecordId = 729
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791148800000000), DistanceInMeters = 9819.376380382062,
                    DurationInSeconds = 16775.065384485202, RecordId = 730
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791183360000000), DistanceInMeters = 7585.554729191854,
                    DurationInSeconds = 10040.196947379161, RecordId = 731
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791217920000000), DistanceInMeters = 3670.7325559779474,
                    DurationInSeconds = 10948.685913879148, RecordId = 732
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791252480000000), DistanceInMeters = 3243.367072602818,
                    DurationInSeconds = 4531.283925709195, RecordId = 733
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791287040000000), DistanceInMeters = 5457.4207579368485,
                    DurationInSeconds = 19494.318178144626, RecordId = 734
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791321600000000), DistanceInMeters = 7404.181975921166,
                    DurationInSeconds = 7948.437358678888, RecordId = 735
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791356160000000), DistanceInMeters = 3251.792902807481,
                    DurationInSeconds = 17961.68261228148, RecordId = 736
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791390720000000), DistanceInMeters = 4084.3272172892976,
                    DurationInSeconds = 3812.9699635485163, RecordId = 737
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791425280000000), DistanceInMeters = 1714.4590769532122,
                    DurationInSeconds = 2223.0188190362464, RecordId = 738
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791459840000000), DistanceInMeters = 4361.581294367551,
                    DurationInSeconds = 15647.768864665606, RecordId = 739
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791494400000000), DistanceInMeters = 3533.245810333752,
                    DurationInSeconds = 11853.295125319059, RecordId = 740
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791528960000000), DistanceInMeters = 1938.366274661421,
                    DurationInSeconds = 11835.382602252419, RecordId = 741
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791563520000000), DistanceInMeters = 5538.856164999382,
                    DurationInSeconds = 4416.428109591784, RecordId = 742
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791598080000000), DistanceInMeters = 1926.2042463474268,
                    DurationInSeconds = 14558.725895306074, RecordId = 743
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791632640000000), DistanceInMeters = 5720.499899886154,
                    DurationInSeconds = 2208.755340665478, RecordId = 744
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791667200000000), DistanceInMeters = 5328.904654924418,
                    DurationInSeconds = 13186.312934153048, RecordId = 745
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791701760000000), DistanceInMeters = 6814.712518764223,
                    DurationInSeconds = 14853.034557655465, RecordId = 746
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791736320000000), DistanceInMeters = 1210.2281278819066,
                    DurationInSeconds = 14451.050188318382, RecordId = 747
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791770880000000), DistanceInMeters = 251.75560529626463,
                    DurationInSeconds = 8402.854515049406, RecordId = 748
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791805440000000), DistanceInMeters = 3268.9382953589943,
                    DurationInSeconds = 8570.690615424686, RecordId = 749
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791840000000000), DistanceInMeters = 9772.57238649932,
                    DurationInSeconds = 2942.2623919762705, RecordId = 750
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791874560000000), DistanceInMeters = 6593.741960725297,
                    DurationInSeconds = 2815.9119851758387, RecordId = 751
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791909120000000), DistanceInMeters = 1439.4469355175845,
                    DurationInSeconds = 8320.018520557907, RecordId = 752
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791943680000000), DistanceInMeters = 5090.064369290581,
                    DurationInSeconds = 7060.797344064583, RecordId = 753
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637791978240000000), DistanceInMeters = 8017.471648141793,
                    DurationInSeconds = 9264.313277437937, RecordId = 754
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792012800000000), DistanceInMeters = 9574.55757548077,
                    DurationInSeconds = 386.2734606692487, RecordId = 755
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792047360000000), DistanceInMeters = 3568.17580105504,
                    DurationInSeconds = 18758.660941120772, RecordId = 756
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792081920000000), DistanceInMeters = 3331.380790183325,
                    DurationInSeconds = 4206.455488842694, RecordId = 757
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792116480000000), DistanceInMeters = 969.1280733800797,
                    DurationInSeconds = 5919.820676511078, RecordId = 758
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792151040000000), DistanceInMeters = 5055.966996629294,
                    DurationInSeconds = 18110.713483388914, RecordId = 759
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792185600000000), DistanceInMeters = 8317.811813472705,
                    DurationInSeconds = 1086.8321503188872, RecordId = 760
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792220160000000), DistanceInMeters = 1897.0743459192706,
                    DurationInSeconds = 11083.800886546423, RecordId = 761
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792254720000000), DistanceInMeters = 9863.23380218275,
                    DurationInSeconds = 10724.699883571617, RecordId = 762
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792289280000000), DistanceInMeters = 4731.41756511335,
                    DurationInSeconds = 13586.371342773911, RecordId = 763
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792323840000000), DistanceInMeters = 5730.781595108246,
                    DurationInSeconds = 16589.19864904655, RecordId = 764
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792358400000000), DistanceInMeters = 7165.758530264161,
                    DurationInSeconds = 17743.991459620654, RecordId = 765
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792392960000000), DistanceInMeters = 9408.466772224387,
                    DurationInSeconds = 17926.282402413923, RecordId = 766
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792427520000000), DistanceInMeters = 5311.852422300035,
                    DurationInSeconds = 151.88711737414246, RecordId = 767
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792462080000000), DistanceInMeters = 8867.88640321803,
                    DurationInSeconds = 3099.2496997993544, RecordId = 768
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792496640000000), DistanceInMeters = 1467.762118610159,
                    DurationInSeconds = 8599.021196546655, RecordId = 769
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792531200000000), DistanceInMeters = 2562.484343369677,
                    DurationInSeconds = 19455.21395527322, RecordId = 770
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792565760000000), DistanceInMeters = 2566.6948455789116,
                    DurationInSeconds = 17496.425424302815, RecordId = 771
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792600320000000), DistanceInMeters = 7122.032983297377,
                    DurationInSeconds = 16686.401065997834, RecordId = 772
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792634880000000), DistanceInMeters = 2868.3366662903227,
                    DurationInSeconds = 11767.03181945225, RecordId = 773
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792669440000000), DistanceInMeters = 5470.554575920632,
                    DurationInSeconds = 13704.087035088023, RecordId = 774
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792704000000000), DistanceInMeters = 2124.1573242930685,
                    DurationInSeconds = 5923.344537525202, RecordId = 775
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792738560000000), DistanceInMeters = 5689.402393270296,
                    DurationInSeconds = 14665.742087441504, RecordId = 776
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792773120000000), DistanceInMeters = 8161.221187319198,
                    DurationInSeconds = 8544.563327583019, RecordId = 777
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792807680000000), DistanceInMeters = 6172.9886452306855,
                    DurationInSeconds = 5604.501866666213, RecordId = 778
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792842240000000), DistanceInMeters = 8562.694395062254,
                    DurationInSeconds = 13569.38993844566, RecordId = 779
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792876800000000), DistanceInMeters = 7366.362195312601,
                    DurationInSeconds = 10579.42570619992, RecordId = 780
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792911360000000), DistanceInMeters = 5201.696550199147,
                    DurationInSeconds = 11441.627015604154, RecordId = 781
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792945920000000), DistanceInMeters = 6834.689106660925,
                    DurationInSeconds = 2516.153773067601, RecordId = 782
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637792980480000000), DistanceInMeters = 5383.06373370189,
                    DurationInSeconds = 6100.034317785633, RecordId = 783
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793015040000000), DistanceInMeters = 5498.465258318174,
                    DurationInSeconds = 13942.314002947409, RecordId = 784
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793049600000000), DistanceInMeters = 908.4577173052876,
                    DurationInSeconds = 10299.054871127184, RecordId = 785
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793084160000000), DistanceInMeters = 6633.355161423269,
                    DurationInSeconds = 10039.328579657073, RecordId = 786
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793118720000000), DistanceInMeters = 3855.444443450623,
                    DurationInSeconds = 13271.41718018085, RecordId = 787
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793153280000000), DistanceInMeters = 4791.723443538333,
                    DurationInSeconds = 18796.424157247016, RecordId = 788
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793187840000000), DistanceInMeters = 9894.70911276721,
                    DurationInSeconds = 5933.793676526119, RecordId = 789
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793222400000000), DistanceInMeters = 6559.599911654972,
                    DurationInSeconds = 11984.386666689245, RecordId = 790
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793256960000000), DistanceInMeters = 5060.633571885993,
                    DurationInSeconds = 17576.915889900676, RecordId = 791
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793291520000000), DistanceInMeters = 8336.620643446466,
                    DurationInSeconds = 2016.018492540518, RecordId = 792
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793326080000000), DistanceInMeters = 847.0806674977615,
                    DurationInSeconds = 10210.985444565573, RecordId = 793
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793360640000000), DistanceInMeters = 9068.085795899191,
                    DurationInSeconds = 6366.957152955454, RecordId = 794
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793395200000000), DistanceInMeters = 8138.5742103221355,
                    DurationInSeconds = 8911.621075307967, RecordId = 795
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793429760000000), DistanceInMeters = 9205.021567392481,
                    DurationInSeconds = 13800.794002410294, RecordId = 796
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793464320000000), DistanceInMeters = 1576.8764011446372,
                    DurationInSeconds = 2260.862933544205, RecordId = 797
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793498880000000), DistanceInMeters = 6490.187370639309,
                    DurationInSeconds = 11597.78060663528, RecordId = 798
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793533440000000), DistanceInMeters = 5550.384728990965,
                    DurationInSeconds = 12717.771357732858, RecordId = 799
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793568000000000), DistanceInMeters = 1538.5959502318876,
                    DurationInSeconds = 8715.25469007983, RecordId = 800
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793602560000000), DistanceInMeters = 6952.479239611294,
                    DurationInSeconds = 19814.39464456426, RecordId = 801
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793637120000000), DistanceInMeters = 2811.935334110503,
                    DurationInSeconds = 6244.554348990599, RecordId = 802
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793671680000000), DistanceInMeters = 3881.002821112134,
                    DurationInSeconds = 12525.197443519713, RecordId = 803
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793706240000000), DistanceInMeters = 4437.63995820281,
                    DurationInSeconds = 11957.737961352579, RecordId = 804
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793740800000000), DistanceInMeters = 748.907679419887,
                    DurationInSeconds = 4994.992805110278, RecordId = 805
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793775360000000), DistanceInMeters = 9022.78714160969,
                    DurationInSeconds = 14224.262003977892, RecordId = 806
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793809920000000), DistanceInMeters = 7392.247446466014,
                    DurationInSeconds = 9294.801421552613, RecordId = 807
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793844480000000), DistanceInMeters = 7221.6247643680135,
                    DurationInSeconds = 16170.87615918186, RecordId = 808
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793879040000000), DistanceInMeters = 4977.165133399811,
                    DurationInSeconds = 2344.571975617686, RecordId = 809
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793913600000000), DistanceInMeters = 7427.372482884286,
                    DurationInSeconds = 16283.580889038938, RecordId = 810
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793948160000000), DistanceInMeters = 6920.07289431733,
                    DurationInSeconds = 18011.70820922952, RecordId = 811
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637793982720000000), DistanceInMeters = 2766.508583090457,
                    DurationInSeconds = 4181.881949113972, RecordId = 812
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794017280000000), DistanceInMeters = 4858.252520325988,
                    DurationInSeconds = 15718.218678189389, RecordId = 813
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794051840000000), DistanceInMeters = 9317.759393036418,
                    DurationInSeconds = 9841.60030183872, RecordId = 814
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794086400000000), DistanceInMeters = 8097.172460056503,
                    DurationInSeconds = 4606.391300895287, RecordId = 815
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794120960000000), DistanceInMeters = 8996.018351725543,
                    DurationInSeconds = 5780.980017902876, RecordId = 816
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794155520000000), DistanceInMeters = 7820.034321878325,
                    DurationInSeconds = 2650.3522770919462, RecordId = 817
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794190080000000), DistanceInMeters = 2434.9658753971626,
                    DurationInSeconds = 17661.0304028528, RecordId = 818
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794224640000000), DistanceInMeters = 6369.1213692600295,
                    DurationInSeconds = 6236.510889147475, RecordId = 819
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794259200000000), DistanceInMeters = 3764.4743757942283,
                    DurationInSeconds = 18591.275447894706, RecordId = 820
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794293760000000), DistanceInMeters = 3067.80958132124,
                    DurationInSeconds = 1255.9365086873802, RecordId = 821
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794328320000000), DistanceInMeters = 8917.857096844173,
                    DurationInSeconds = 11575.92026787909, RecordId = 822
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794362880000000), DistanceInMeters = 4618.9897246133905,
                    DurationInSeconds = 14717.754338390494, RecordId = 823
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794397440000000), DistanceInMeters = 3129.8321098392153,
                    DurationInSeconds = 3021.289929063297, RecordId = 824
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794432000000000), DistanceInMeters = 6337.940749121108,
                    DurationInSeconds = 12729.68324706626, RecordId = 825
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794466560000000), DistanceInMeters = 3240.7952946711052,
                    DurationInSeconds = 10296.074577551411, RecordId = 826
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794501120000000), DistanceInMeters = 7940.964525675802,
                    DurationInSeconds = 13056.201960013294, RecordId = 827
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794535680000000), DistanceInMeters = 3516.3058487738313,
                    DurationInSeconds = 15598.005460699947, RecordId = 828
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794570240000000), DistanceInMeters = 9423.467066134053,
                    DurationInSeconds = 13336.059049877065, RecordId = 829
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794604800000000), DistanceInMeters = 3290.295150917348,
                    DurationInSeconds = 19254.527417359055, RecordId = 830
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794639360000000), DistanceInMeters = 8393.351297397348,
                    DurationInSeconds = 4922.67900384901, RecordId = 831
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794673920000000), DistanceInMeters = 9773.898527627773,
                    DurationInSeconds = 11426.18413096881, RecordId = 832
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794708480000000), DistanceInMeters = 1331.6239870965326,
                    DurationInSeconds = 8654.999099718763, RecordId = 833
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794743040000000), DistanceInMeters = 6189.103957646719,
                    DurationInSeconds = 15615.798616695698, RecordId = 834
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794777600000000), DistanceInMeters = 4652.859015263858,
                    DurationInSeconds = 5173.019424512133, RecordId = 835
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794812160000000), DistanceInMeters = 3663.0518717305004,
                    DurationInSeconds = 3839.444987015942, RecordId = 836
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794846720000000), DistanceInMeters = 9958.762555997087,
                    DurationInSeconds = 3007.0011498792505, RecordId = 837
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794881280000000), DistanceInMeters = 3783.792314010175,
                    DurationInSeconds = 7403.864710027346, RecordId = 838
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794915840000000), DistanceInMeters = 4125.461411623274,
                    DurationInSeconds = 4648.921995383773, RecordId = 839
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794950400000000), DistanceInMeters = 6705.133250391899,
                    DurationInSeconds = 1247.9770502156389, RecordId = 840
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637794984960000000), DistanceInMeters = 383.7059941522073,
                    DurationInSeconds = 9754.382780076938, RecordId = 841
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795019520000000), DistanceInMeters = 9162.534704703974,
                    DurationInSeconds = 14346.751463977047, RecordId = 842
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795054080000000), DistanceInMeters = 4193.519484710839,
                    DurationInSeconds = 4401.831509347412, RecordId = 843
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795088640000000), DistanceInMeters = 2686.3289356892105,
                    DurationInSeconds = 9341.377253010676, RecordId = 844
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795123200000000), DistanceInMeters = 6545.145493090633,
                    DurationInSeconds = 19977.856878546747, RecordId = 845
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795157760000000), DistanceInMeters = 7657.551391219295,
                    DurationInSeconds = 925.55731864902, RecordId = 846
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795192320000000), DistanceInMeters = 5812.242693934241,
                    DurationInSeconds = 10721.21567202906, RecordId = 847
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795226880000000), DistanceInMeters = 4010.447974072609,
                    DurationInSeconds = 1996.2771144790436, RecordId = 848
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795261440000000), DistanceInMeters = 1650.8138874886886,
                    DurationInSeconds = 18308.825550637597, RecordId = 849
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795296000000000), DistanceInMeters = 3099.48733468368,
                    DurationInSeconds = 9849.36794368467, RecordId = 850
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795330560000000), DistanceInMeters = 5309.128829795593,
                    DurationInSeconds = 15940.994744359647, RecordId = 851
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795365120000000), DistanceInMeters = 2162.960905883967,
                    DurationInSeconds = 1891.312695338422, RecordId = 852
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795399680000000), DistanceInMeters = 8552.48148624441,
                    DurationInSeconds = 324.27245989291356, RecordId = 853
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795434240000000), DistanceInMeters = 2299.062642465877,
                    DurationInSeconds = 12403.087299925019, RecordId = 854
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795468800000000), DistanceInMeters = 8387.940082378766,
                    DurationInSeconds = 14766.357848162605, RecordId = 855
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795503360000000), DistanceInMeters = 4155.200904221414,
                    DurationInSeconds = 12996.005120815953, RecordId = 856
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795537920000000), DistanceInMeters = 2169.0669317204697,
                    DurationInSeconds = 13809.084803718022, RecordId = 857
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795572480000000), DistanceInMeters = 2037.7160945131172,
                    DurationInSeconds = 2239.6105693202135, RecordId = 858
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795607040000000), DistanceInMeters = 7492.087990134635,
                    DurationInSeconds = 11494.482681514326, RecordId = 859
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795641600000000), DistanceInMeters = 1778.494808410719,
                    DurationInSeconds = 13368.276550733184, RecordId = 860
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795676160000000), DistanceInMeters = 3487.1708311833195,
                    DurationInSeconds = 2442.7342770967875, RecordId = 861
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795710720000000), DistanceInMeters = 7326.629042574634,
                    DurationInSeconds = 5443.830459715704, RecordId = 862
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795745280000000), DistanceInMeters = 428.7740464198049,
                    DurationInSeconds = 15787.978108442221, RecordId = 863
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795779840000000), DistanceInMeters = 4609.92359179354,
                    DurationInSeconds = 7158.791336774328, RecordId = 864
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795814400000000), DistanceInMeters = 3469.763219054424,
                    DurationInSeconds = 11137.766655960273, RecordId = 865
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795848960000000), DistanceInMeters = 8324.854798259908,
                    DurationInSeconds = 15489.349868163828, RecordId = 866
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795883520000000), DistanceInMeters = 4010.858094304058,
                    DurationInSeconds = 8688.24026607793, RecordId = 867
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795918080000000), DistanceInMeters = 422.15049461576893,
                    DurationInSeconds = 4338.51625280384, RecordId = 868
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795952640000000), DistanceInMeters = 4333.223409572205,
                    DurationInSeconds = 11780.105415236809, RecordId = 869
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637795987200000000), DistanceInMeters = 3786.6263337079317,
                    DurationInSeconds = 8192.701728773842, RecordId = 870
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637796021760000000), DistanceInMeters = 6182.488383938986,
                    DurationInSeconds = 15164.8526927538, RecordId = 871
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637796056320000000), DistanceInMeters = 7268.173232768484,
                    DurationInSeconds = 8737.250650817572, RecordId = 872
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637796090880000000), DistanceInMeters = 9283.180881472445,
                    DurationInSeconds = 8344.013571175254, RecordId = 873
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637796125440000000), DistanceInMeters = 3459.971174529068,
                    DurationInSeconds = 11618.588718534966, RecordId = 874
                },
                new JoggingRecord()
                {
                    Date = new DateTime(637796160000000000), DistanceInMeters = 972.7639969424063,
                    DurationInSeconds = 9677.61615497008, RecordId = 875
                }
            };
        }
    }
}