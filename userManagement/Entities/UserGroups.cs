using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace userManagement.Entities
{
    [Keyless]
    public class UserGroups
    {
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("Groups")]
        public int GroupId { get; set; }
        public virtual Users Users { get; set; }
        public virtual Groups Groups { get; set; }
    }
}
