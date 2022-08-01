using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interface;
using DAL.Repo;

namespace DAL
{
    public class DataFactory
    {
        static readonly newsEntities db = new newsEntities();

        public static IRepo<News, int> NewsRepo()
        {
            return new NewsRepo(db);
        }

        public static IRepo<Category, int> CategoryRepo()
        {
            return new CategoryRepo(db);
        }

        public static IRepo<User, int> UserRepo()
        {
            return new UserRepo(db);
        }
    }
}
