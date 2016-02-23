using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTest.Models
{
    public class Enquete
    {
        public int EnqueteId { get; set; }
        public int ContentId { get; set; }
        public string Param { get; set; }
    }
}