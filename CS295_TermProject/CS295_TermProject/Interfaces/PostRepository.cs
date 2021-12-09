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
            var list = ctx.posts.OrderByDescending(m => m.Date).ToList();
            if(list == null)
            {
                return new List<ForumPostModel>();
            }
            return list;
        }

        public ForumPostModel SelectById(int id)
        {
            return ctx.posts.Find(id);
        }

        public IEnumerable<ForumPostModel> SelectWithFilter(string filter)
        {
            IEnumerable<ForumPostModel> posts;
            if (!String.IsNullOrEmpty(filter))
            {
                 posts = ctx.posts.Where(s => s.Title.ToLower().Contains(filter.ToLower())).AsEnumerable();
            }
            else
            {
                posts = ctx.posts.ToList();
            }
            return posts;
        }
    }
}
