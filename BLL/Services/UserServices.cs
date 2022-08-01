using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BOs;
using DAL;

namespace BLL.Services
{
    public class UserServices
    {
        public static List<UserModel> GetAll()
        {
            var data = DataFactory.UserRepo().GetAll();
            List<UserModel> list = new List<UserModel>();
            foreach(var d in data)
            {
                list.Add(new UserModel { Username = d.Username, Password = d.Password });
            }
            return list;
        }
    }
}
