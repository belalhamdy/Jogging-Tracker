using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jogging_Tracker.Models
{
    [Microsoft.EntityFrameworkCore.Index(nameof(UserId), IsUnique = true)]
    public class ApplicationUser : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public virtual ICollection<JoggingRecord> UserJoggingRecords{ get; set; }
    }
}
