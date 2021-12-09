using NUnit.Framework;
using CS295_TermProject.Models;
using CS295_TermProject.Interfaces;
using System.Linq;

namespace CS295_TermProject_Tests
{
    [TestFixture]
    public class ReplyTests
    {
        public ReplyContext ctx { get; set; }
        
        public ReplyTests(ReplyContext inputContext)
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
            
            ForumReplyModel model = new ForumReplyModel();
            model.Username = "Mr. Testerson";
            model.Message = "This is a Test Message";

            ctx.replies.Add(model);

            var list = ctx.replies.OrderByDescending(m => m.ReplyId).ToList();
            model = list[0];
            Assert.AreEqual("This is a Test Message", model.Message);
        }

        [Test]
        public void DeleteById()
        {
            
            ForumReplyModel model = new ForumReplyModel();
            model.Username = "Mr. Testerson";
            model.Message = "This is a Test Message";

            ctx.replies.Add(model);

            var list = ctx.replies.OrderByDescending(m => m.PostId).ToList();
            model = list[0];
            Assert.AreEqual("This is a Test Message", model.Message);

            ctx.replies.Remove(model);
            ctx.SaveChanges();

            Assert.IsNull(ctx.replies.OrderByDescending(m => m.PostId).ToList());
        }
    }
}