using userManagement.DatabaseContext;
using userManagement.Entities;

namespace userManagement
{
    public class CreateDB
    {
        public static void DBCreate()
        {
            var context = new UserManagementDBContext();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            List<Users> users = new List<Users>()
            {
                new Users{Name="Tshepo Mahloko", Email="tshepo@test.com"},
                new Users{Name="John Smith", Email="john@test.com"},
                new Users{Name="Tom Zulu", Email="tom@test.com"},
            };

            context.Users.AddRange(users);

            List<Permissions> permissions = new List<Permissions>()
            {
                new Permissions{Name="Level 1"},
                new Permissions{Name="Level 2"},
                new Permissions{Name="Level 3"},
            };

            context.Permissions.AddRange(permissions);

            List<Groups> groups = new List<Groups>()
            {
                new Groups{Name="Group A"},
                new Groups{Name="Group B"},
                new Groups{Name="Group C"},
            };

            context.Groups.AddRange(groups);
            context.SaveChanges();
        }
    }
}
