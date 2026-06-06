using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace R61M6C5_Security.ViewModels
{
    public class ProfileVM
    {
        public string Name { get; set; }
        public string ProfilePicPath { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public HttpPostedFileBase ProfilePic { get; set; }
    }
}