using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mirror
{
    public class Puzzle
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }

        public Puzzle(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

        public bool TrySolve(string input)
        {
            return input.Trim() == Answer;
        }
    }
}
