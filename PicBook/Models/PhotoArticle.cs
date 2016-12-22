using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PicBook.Models
{
    public class PhotoArticle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Image
        {
            get; set;
        }
        public string descprition { get; set; }
        public ApplicationUser Author { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }
    }
}