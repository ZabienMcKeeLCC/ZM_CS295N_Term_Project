using CS295_TermProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CS295_TermProject.Controllers
{
    public class ForumController : Controller
    {
        private PostContext postContext { get; set; }
        private ReplyContext replyContext { get; set; }

        public ForumController(PostContext postCtx, ReplyContext replyCtx)
        {
            postContext = postCtx;
            replyContext = replyCtx;
        }

        [HttpGet]
        public IActionResult Browser()
        {
            //List<ForumPostModel> comments = ForumDB.GetMessages();
            ViewBag.replies = replyContext.replies.ToList();
            ViewBag.comments = postContext.posts.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Browser(ForumPostModel model)
        {

            ViewBag.replies = replyContext.replies.ToList();
            ViewBag.comments = postContext.posts.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult WritePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WritePost(ForumPostModel model)
        {
            DateTime clock = DateTime.Now;
            if (ModelState.IsValid)
            {
                model.Date = clock.ToString();

                postContext.posts.Add(model);
                postContext.SaveChanges();
            }
                
                return RedirectToAction("Browser");
        }
        //Page that displays actual post
        [HttpGet]
        public IActionResult ForumPost(int postId)
        {
            List<ForumReplyModel> allReplies = replyContext.replies.ToList();
            List<ForumReplyModel> linkedReplies = new List<ForumReplyModel>();
            ViewBag.Id = postId;
            ViewBag.Post = postContext.posts.Find(postId);
            
            foreach(ForumReplyModel reply in allReplies)
            {
                if(reply.PostId == postId) { linkedReplies.Add(reply); }
                    
                
            }

            ViewBag.replies = linkedReplies;
            return View();
        }
        [HttpGet]
        public IActionResult WriteReply(ForumPostModel postModel)
        {
            ViewBag.Post = postModel;
            return View();
        }

        [HttpPost]
        public IActionResult WriteReply(ForumReplyModel postModel, int postId)
        {
            ViewBag.Post = postModel;
            DateTime clock = DateTime.Now;
            if (ModelState.IsValid)
            {
                postModel.Date = clock.ToString();
                postModel.PostId = postId;
                replyContext.replies.Add(postModel);
                replyContext.SaveChanges();
            }

            return RedirectToAction("Browser");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult DeletePost(int postId)
        {
            var post = postContext.posts.Find(postId);
            return View(post);
        }

        [HttpPost]
        public IActionResult DeletePost(ForumPostModel post)
        {
            DeleteReplyByPostId(post.PostId);
            postContext.posts.Remove(post);
            postContext.SaveChanges();
            return RedirectToAction("Browser");
        }
        [HttpGet]
        public IActionResult DeleteReply(int replyId)
        {
            var post = postContext.posts.Find(replyId);
            return View(post);
        }

        [HttpPost]
        public IActionResult DeleteReply(ForumReplyModel reply)
        {
            replyContext.replies.Remove(reply);
            replyContext.SaveChanges();
            return RedirectToAction("Browser");
        }

        public IActionResult DeleteReplyByPostId(int postId)
        {
            foreach(ForumReplyModel reply in replyContext.replies.ToList())
            {
                if(reply.PostId == postId)
                {
                    DeleteReply(reply);
                }
            }
            return View();
        }
    }
}
