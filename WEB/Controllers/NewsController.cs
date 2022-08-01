using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.BOs;
using BLL.Services;

namespace WEB.Controllers
{
    public class NewsController : ApiController
    {
        [Route("api/news/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, NewsServices.GetAll());
        }

        [Route("api/news/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = NewsServices.GetById(id);
            if(data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            
        }

        [Route("api/news/create")]
        [HttpPost]
        public HttpResponseMessage Create(NewsModel n)
        {
            var res = NewsServices.Create(n);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/news/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(NewsModel n)
        {
            var res = NewsServices.Update(n);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
