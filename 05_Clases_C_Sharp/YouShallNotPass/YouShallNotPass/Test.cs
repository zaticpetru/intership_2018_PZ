using System;

namespace YouShallNotPass
{
    interface ITest
    {
        void TakeTest();
        int CountPoints(string[] ans);
        void ResetScore();
        int GetLastScore();
    }

    abstract class Test
    {
        protected string[] questions;
        protected string[] answers;
        protected int score;

        public void ResetScore()
        {
            score = 0;
        }

        public int GetLastScore()
        {
            return score;
        }

        public void SetQuest_Answ(string[] quest, string[] ans)
        {
            questions = quest;
            answers = ans;
        }
        public int CountPoints(string[] ans)
        {
            Array.Sort(ans, StringComparer.InvariantCulture);
            Array.Sort(answers, StringComparer.InvariantCulture);

            int i = 0;
            while (i < ans.Length && i < answers.Length)
            {
                if (ans[i] == answers[i]) score++;
                i++;
            }

            return score;
        }
    }

    class MathTest : Test, ITest
    {
        public void TakeTest()
        {
            throw new NotImplementedException();
        }
    }
}
