using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BOs;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class NewsServices
    {
        public static List<NewsModel> GetAll()
        {
            var data = DataFactory.NewsRepo().GetAll();
            List<NewsModel> news = new List<NewsModel>();
            foreach(var d in data)
            {
                news.Add(new NewsModel { Title = d.Title, Body = d.Body, Date = d.Date, User_Id = d.User_Id, Category_Id = d.Category_Id });
            }
            return news;
        }

        public static bool Create(NewsModel news)
        {
            News n = new News { Title=news.Title, Body = news.Body, Date = DateTime.Now, User_Id= news.User_Id, Category_Id= news.Category_Id};
            return DataFactory.NewsRepo().Create(n);
        }

        public static bool Update(NewsModel news)
        {
            News n = new News { Title = news.Title, Body = news.Body, Date = news.Date, User_Id = news.User_Id, Category_Id = news.Category_Id };
            return DataFactory.NewsRepo().Update(n);
        }

        public static bool Delete(int id)
        {
            return DataFactory.NewsRepo().Delete(id);
        }

        public static NewsModel GetById(int id)
        {
            var data = DataFactory.NewsRepo().Get(id);
            if (data == null)
                return null;
            return new NewsModel
            {
                Title = data.Title,
                Body = data.Body,
                Date = data.Date,
                Category_Id = data.Category_Id,
                User_Id = data.User_Id
            };
        }
    }
}
