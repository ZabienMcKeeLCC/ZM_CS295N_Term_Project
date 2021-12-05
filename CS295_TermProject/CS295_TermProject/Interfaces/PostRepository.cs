using CS295_TermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_TermProject.Interfaces
{
    public class PostRepository : IPostRepository
    {

        private PostContext ctx { get; set; }
        public PostRepository(PostContext inputContext)
        {
            ctx = inputContext;
        }
        public void Delete(ForumPostModel obj)
        {
            ctx.posts.Remove(obj);
        }

        public void Insert(ForumPostModel obj)
        {
            ctx.posts.Add(obj);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public IEnumerable<ForumPostModel> SelectAll()
        {
            return ctx.posts.ToList();
        }

        public ForumPostModel SelectById(int id)
        {
            return ctx.posts.Find(id);
        }
    }
}
