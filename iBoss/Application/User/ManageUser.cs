using iBoss.Models.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using iBoss.Models.EF;

namespace iBoss.Application.User
{
    public class ManageUser : IManageUser
    {
       public UserDbContext _context;
        public ManageUser(UserDbContext context)
        {
            _context = context;
        }

        public USER Login(USER User)
        {
            
            USER user = _context.USERS.Where(x => x.USERNAME == User.USERNAME && x.PASSWORD == User.PASSWORD).FirstOrDefault();

            return user;
        }
    }
}
