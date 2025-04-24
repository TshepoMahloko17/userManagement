using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace userManagement.Entities
{
    [Keyless]
    public class PermissionGroups
    {
        [ForeignKey("Groups")]
        public int GroupId { get; set; }
        [ForeignKey("Permissions")]
        public int PermissionId { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual Permissions Permissions { get; set; }
    }
}
