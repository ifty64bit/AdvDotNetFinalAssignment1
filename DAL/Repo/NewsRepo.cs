using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interface;

namespace DAL.Repo
{
    internal class NewsRepo: IRepo<News,int>
    {
        readonly newsEntities db;
        public NewsRepo(newsEntities db)
        {
            this.db = db;
        }

        public List<News> GetAll()
        {
            return db.News.ToList();
        }

        public News Get(int id)
        {
            return db.News.Where(x => x.Id == id).SingleOrDefault();
        }

        public bool Create(News news)
        {
            db.News.Add(news);
            var result = db.SaveChanges();
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                db.News.Remove((from n in db.News where n.Id==id select n).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Update(News news)
        {
            News old = db.News.Where(x => x.Id == news.Id).SingleOrDefault();
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(news);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
