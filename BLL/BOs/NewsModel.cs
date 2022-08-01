using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public System.DateTime Date { get; set; }
        public int User_Id { get; set; }
        public int Category_Id { get; set; }
    }
}
