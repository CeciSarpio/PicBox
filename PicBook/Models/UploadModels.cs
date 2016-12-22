using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace PicBook.Models
{
    public class UploadModels
    {
        [Required]
        [Display(Name = "Photo")]
        public byte[] Photo { get; set; }

       
        
    }
}