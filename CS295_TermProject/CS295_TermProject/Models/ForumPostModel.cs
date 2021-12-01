using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS295_TermProject.Models
{

    public class ForumPostModel
    {
        public ForumPostModel() { }

        [Key]
        public int PostId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        public string Date { get; set; }
    }
}
