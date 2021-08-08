using HMS.Data;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BL
{
    public  class SecurityRep
    {
      
        public SecurityRep()
        {

            
        }

        public UserModel getLogin(LoginModel model)
        {
            var item=(dynamic)null;
            using (HMSEntities db = new HMSEntities())
            {
                item = (from u in db.Users where u.UserName.Equals(model.UserName) && u.UserPassword.Equals(model.Password) select new UserModel()
                {
                    UserName=u.UserName,UserPassword=u.UserPassword,ID=u.ID
                }).FirstOrDefault();
            }
          return item;
        }
        public string[] GetRolesForUser(string username)
        {
            using (HMSEntities db = new HMSEntities())
            {
                var userRoles = (from user in db.Users
                                 join roleMapping in db.UserRolesMappings
                                 on user.ID equals roleMapping.UserID
                                 join role in db.RoleMasters
                                 on roleMapping.RoleID equals role.ID
                                 where user.UserName == username
                                 select role.RollName).ToArray();
                return userRoles;
            }
        }

    }
}
