using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using M8_evd_Master_Token.Models;

namespace M8_evd_Master_Token.DTO
{
    public class SalesDTO
    {
  
        public Sales Sales { get; set; }
        public HttpPostedFileBase PicFile { get; set; }
    }
}