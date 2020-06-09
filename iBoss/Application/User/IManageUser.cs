using iBoss.Models.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Application.User
{
    public interface IManageUser
    {
        public USER Login(USER User);
       
    }
}
