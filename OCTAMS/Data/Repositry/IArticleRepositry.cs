using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public interface IArticleRepositry
    {
        public bool DeleteArticle(int id);
        public bool AddArticle(Articles newArticle);
        public Articles getArticle(int id);
        public IEnumerable<Articles> getArticles(string uid);
        public IEnumerable<Articles> getArticles();
    }
}
