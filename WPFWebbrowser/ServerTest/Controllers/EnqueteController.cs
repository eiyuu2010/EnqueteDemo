using ServerTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerTest.Controllers
{
    public class EnqueteController : ApiController
    {
        private static List<Enquete> _enquetes = new List<Enquete>()
            {
                new Enquete() { EnqueteId = 1, ContentId = 12, Param = "resourceId=1002876&q_1_435=2467" },
                new Enquete() { EnqueteId = 1, ContentId = 13, Param = "resourceId=1002876&q_1_435=2466" },
                new Enquete() { EnqueteId = 1, ContentId = 14, Param = "resourceId=1002876&q_1_435=2465" },
                new Enquete() { EnqueteId = 1, ContentId = 15, Param = "resourceId=1002876&q_1_435=2464" },
                new Enquete() { EnqueteId = 1, ContentId = 16, Param = "resourceId=1002876&q_1_435=2463" }
            };

        public EnqueteController()
        {
        }

        [HttpGet]
        public IEnumerable<Enquete> GetEnquetes()
        {
            return _enquetes;
        }

        [HttpGet]
        public Enquete GetEnquete(int id)
        {
            Enquete pro = _enquetes.Find(p => p.EnqueteId == id);

            if (pro == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return pro;
        }

        [HttpGet]
        public IEnumerable<Enquete> GetEnquetesBySearch(string search)
        {
            var enquetes = _enquetes.Where(p => p.Param.Contains(search));

            if (enquetes.ToList().Count > 0)
                return enquetes;
            else
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public Enquete PostEnquete(Enquete enq)
        {
            //if (enq == null)
            //    return -1;

            _enquetes.Add(enq);
            return enq;
        }

        [HttpDelete]
        public IEnumerable<Enquete> DeleteEnquete(int id)
        {
            Enquete pro = _enquetes.Find(p => p.EnqueteId == id);
            _enquetes.Remove(pro);

            return _enquetes;
        }

        [HttpPut]
        public HttpResponseMessage PutEnquete(Enquete enq)
        {
            Enquete pro = _enquetes.Find(pr => pr.EnqueteId == enq.EnqueteId);

            if (pro == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            pro.EnqueteId = enq.EnqueteId;
            pro.Param = enq.Param;
            pro.ContentId = enq.ContentId;

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
