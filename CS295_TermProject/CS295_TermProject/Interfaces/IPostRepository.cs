using CS295_TermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_TermProject.Interfaces
{
    interface IPostRepository
    {

        IEnumerable<ForumPostModel> SelectAll();
        void Insert(ForumPostModel obj);
        ForumPostModel SelectById(int id);
        void Delete(ForumPostModel obj);
        void Save();

    }
}
