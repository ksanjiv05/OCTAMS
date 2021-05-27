using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public class QuestionRepositry : IQuestionRepositry
    {
        private readonly DBContext _context;

        public QuestionRepositry(DBContext context)
        {
            _context = context;
        }
        public bool AddQuestion(Questions newQuestion)
        {
            try
            {
                _context.Questions.Add(newQuestion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateAnswer(Questions newQuestion)
        {
            try
            {
                Questions question = _context.Questions.FirstOrDefault(q => q.Id == newQuestion.Id);
                Console.WriteLine(question==null);
                if (question != null)
                {
                    Console.WriteLine("q0--- "+question.Question);
                    question.Answer = newQuestion.Answer;
                    _context.SaveChanges();
                }

                //_context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Questions getQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Questions> getQuestions()
        {
            try
            {

                return _context.Questions.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine("err" + ex);
                return null;
            }
        }

        public IEnumerable<Questions> getQuestions(string uid)
        {
            try
            {

                return _context.Questions.Where(q => q.Uid == uid).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine("err" + ex);
                return null;
            }
        }
    }
}
