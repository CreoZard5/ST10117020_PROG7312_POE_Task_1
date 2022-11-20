using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10117020.Objects
{
    public class DeweyDecimal_FindCallNo_QuizQuestion
    {


        public DeweyDecimal_FindCallNo_QuizQuestion()
        {

        }

        public DeweyDecimal_FindCallNo_QuizQuestion(DeweyDecimal_FindCallNo answerTier1, DeweyDecimal_FindCallNo answerTier2, DeweyDecimal_FindCallNo question)
        {
            AnswerTier1 = answerTier1;
            AnswerTier2 = answerTier2;
            Question = question;
        }

        public DeweyDecimal_FindCallNo AnswerTier1 { get; set; }
        public DeweyDecimal_FindCallNo AnswerTier2 { get; set; }
        public DeweyDecimal_FindCallNo Question { get; set; }
    }
}
