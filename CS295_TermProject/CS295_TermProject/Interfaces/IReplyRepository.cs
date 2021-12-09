using CS295_TermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_TermProject.Interfaces
{
    public interface IReplyRepository
    {
        IEnumerable<ForumReplyModel> SelectAll();
        void Insert(ForumReplyModel obj);
        ForumReplyModel SelectById(int id);
        void Delete(ForumReplyModel obj);
        void Save();
    }
}
