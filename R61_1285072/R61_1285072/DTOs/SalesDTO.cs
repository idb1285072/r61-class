using R61_1285072.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R61_1285072.DTOs
{
    public class SalesDTO
    {
        public Sales Sales { get; set; }
        public HttpPostedFileBase PicFile { get; set; }
    }
}