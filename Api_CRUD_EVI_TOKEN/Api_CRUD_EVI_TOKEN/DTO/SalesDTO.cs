using Api_CRUD_EVI_TOKEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_CRUD_EVI_TOKEN.DTO
{
    public class SalesDTO
    {
        public Sales Sales { get; set; }
        public HttpPostedFileBase PicFile { get; set; }
    }
}