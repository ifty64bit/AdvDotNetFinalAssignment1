using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = UserServices.GetAll();
            foreach(var d in data)
            {
                Console.WriteLine(d.Username);
                Console.WriteLine(d.Password);
            }
        }
    }
}
