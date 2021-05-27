using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public interface IQuestionRepositry
    {
        public bool AddQuestion(Questions newQuestion);
        public Questions getQuestion(int id);
        public IEnumerable<Questions> getQuestions(string uid);
        public IEnumerable<Questions> getQuestions();
        public bool UpdateAnswer(Questions newQuestion);
    }
}
