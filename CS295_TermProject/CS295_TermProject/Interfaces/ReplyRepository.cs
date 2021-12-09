using CS295_TermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_TermProject.Interfaces
{
    public class ReplyRepository : IReplyRepository
    {

        private ReplyContext ctx { get; set; }
        public ReplyRepository(ReplyContext inputContext)
        {
            ctx = inputContext;
        }
        public void Delete(ForumReplyModel obj)
        {
            ctx.replies.Remove(obj);
        }

        public void Insert(ForumReplyModel obj)
        {
            ctx.replies.Add(obj);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public IEnumerable<ForumReplyModel> SelectAll()
        {
            
            return ctx.replies.ToList();
        }

        public ForumReplyModel SelectById(int id)
        {
            return ctx.replies.Find(id);
        }
    }
}
