using NUnit.Framework;
using CS295_TermProject.Models;
using CS295_TermProject.Interfaces;
using System.Linq;

namespace CS295_TermProject_Tests
{
    [TestFixture]
    public class PostTests
    {
        public PostContext ctx { get; set; }
        
        public PostTests(PostContext inputContext)
        {
            ctx = inputContext;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetById()
        {
            
            ForumPostModel model = new ForumPostModel();
            model.Title = "Test";
            model.Username = "Mr. Testerson";
            model.Message = "This is a Test Message";

            ctx.posts.Add(model);

            var list = ctx.posts.OrderByDescending(m => m.PostId).ToList();
            model = list[0];
            Assert.AreEqual("This is a Test Message", model.Message);
        }

        [Test]
        public void DeleteById()
        {
            ForumPostModel model = new ForumPostModel();
            model.Title = "Test";
            model.Username = "Mr. Testerson";
            model.Message = "This is a Test Message";

            ctx.posts.Add(model);

            var list = ctx.posts.OrderByDescending(m => m.PostId).ToList();
            model = list[0];
            Assert.AreEqual("This is a Test Message", model.Message);

            ctx.posts.Remove(model);
            ctx.SaveChanges();

            Assert.IsNull(ctx.posts.OrderByDescending(m => m.PostId).ToList());
        }
    }
}