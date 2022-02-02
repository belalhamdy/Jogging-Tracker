using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jogging_Tracker.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<JoggingRecord> UserJoggingRecords{ get; set; }
    }
}