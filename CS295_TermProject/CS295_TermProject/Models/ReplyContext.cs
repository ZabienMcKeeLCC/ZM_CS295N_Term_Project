using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_TermProject.Models
{
    public class ReplyContext : DbContext
    {
        public ReplyContext(DbContextOptions<ReplyContext> options) :base(options) { }

        public DbSet<ForumReplyModel> replies { get; set; }

    }
}
