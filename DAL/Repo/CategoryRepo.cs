using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CategoryRepo : IRepo<Category, int>
    {
        readonly newsEntities db;
        public CategoryRepo(newsEntities db)
        {
            this.db = db;
        }

        public bool Create(Category obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            db.Categories.Remove(obj);
            return db.SaveChanges() > 0;
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public bool Update(Category obj)
        {
            Category old = db.Categories.Where(x => x.Id == obj.Id).SingleOrDefault();
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false; ;
        }
    }
}
