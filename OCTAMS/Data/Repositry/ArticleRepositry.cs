using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public class ArticleRepositry : IArticleRepositry
    {
        private readonly DBContext _context;

        public ArticleRepositry(DBContext context)
        {
            _context = context;
        }
        public bool AddArticle(Articles newArticle)
        {
            try
            {
                _context.Articles.Add(newArticle);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool DeleteArticle(int id)
        {
            try
            {
                Articles article = _context.Articles.FirstOrDefault(at => at.Id == id);
                if (article != null)
                {
                    _context.Articles.Remove(article);
                    _context.SaveChanges();
                }
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public Articles getArticle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articles> getArticles(string uid)
        {
            try
            {

                return _context.Articles.Where(st => st.Uid == uid).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine("err" + ex);
                return null;
            }
        }

        public IEnumerable<Articles> getArticles()
        {
            try
            {

                return _context.Articles.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine("err" + ex);
                return null;
            }
        }
    }
}
