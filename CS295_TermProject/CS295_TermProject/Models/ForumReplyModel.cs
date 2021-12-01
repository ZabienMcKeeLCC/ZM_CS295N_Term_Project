using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_TermProject.Models
{
    public class ForumReplyModel
    {
        public ForumReplyModel() { }

        [Key]
        public int ReplyId { get; set; }
        public int PostId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Message { get; set; }

        public string Date { get; set; }
    }
}
