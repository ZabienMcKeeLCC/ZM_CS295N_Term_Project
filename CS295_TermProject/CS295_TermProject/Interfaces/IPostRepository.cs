using CS295_TermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_TermProject.Interfaces
{
    public interface IPostRepository
    {

        IEnumerable<ForumPostModel> SelectAll();
        void Insert(ForumPostModel obj);
        ForumPostModel SelectById(int id);
        void Delete(ForumPostModel obj);
        public IEnumerable<ForumPostModel> SelectWithFilter(string filter);
        void Save();

    }
}
