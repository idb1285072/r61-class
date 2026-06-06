using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Principal;
using static System.Collections.Specialized.BitVector32;

namespace MauiApp1.Shared.Models
{
    public class QuestionPaper
    {
        public int Id { get; set; }
        public string Institute {  get; set; }
        public string Program {  get; set; }
        public string Department { get; set; }
        public string Subject { get; set; }
        public string SubjectCode { get; set; }
        public string ExamName { get; set; }

        public string Semester {  get; set; }
        public int Year { get; set; }
        public string FullMarks { get; set; }
        public string Duration { get; set; }
        public string SectionA {  get; set; }
        public string Question_A1 { get; set; }
        public string Question_A2 { get; set; }
        public string Question_A3 { get; set; }
        public string Question_A4 { get; set; }
        public double MarksA { get; set; }

        public string SectionB { get; set; }
        public string Question_B1 { get; set; }
        public string Question_B2 { get; set; }
        public double MarksB { get; set; }


        public string SectionC { get; set; }
        public string Question_C1 { get; set; }
        public string Question_C2 { get; set; }
        public double MarksC { get; set; }

        public string Note { get; set; }



        //public List<Question> Questions { get; set; } = new List<Question>();

    }
}
