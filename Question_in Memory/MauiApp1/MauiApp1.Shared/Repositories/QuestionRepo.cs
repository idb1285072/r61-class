using MauiApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Shared.Repositories
{
   public static class QuestionRepo
    {
        private static List<QuestionPaper> _papers = new List<QuestionPaper>();

        public static QuestionPaper? Get(int id) => _papers.FirstOrDefault(p => p.Id == id);

        public static List<QuestionPaper> GetAll() => _papers;


        public static QuestionPaper? newQuestion = null;

        public static QuestionPaper? GetById(int id) => _papers.FirstOrDefault(x => x.Id == id);
        public static QuestionPaper Get()
        {
            return newQuestion;
        }
        public static void Add(QuestionPaper paper)
        {
            //paper.Id = _papers.Any() ? _papers.Max(x => x.Id) + 1 : 1;
            //_papers.Add(paper);
            newQuestion = new QuestionPaper();
            newQuestion.Institute = paper.Institute;
            newQuestion.Program = paper.Program;
            newQuestion.Department = paper.Department;
            newQuestion.Subject = paper.Subject;
            newQuestion.SubjectCode = paper.SubjectCode;
            newQuestion.ExamName = paper.ExamName;
            newQuestion.Semester = paper.Semester;
            newQuestion.Year = paper.Year;
            newQuestion.FullMarks = paper.FullMarks;
            newQuestion.Duration = paper.Duration;
            newQuestion.SectionA = paper.SectionA;
            newQuestion.SectionB = paper.SectionB;
            newQuestion.SectionC = paper.SectionC;
            newQuestion.Question_A1 = paper.Question_A1;
            newQuestion.Question_A2 = paper.Question_A2;
            newQuestion.Question_A3 = paper.Question_A3;
            newQuestion.Question_A4 = paper.Question_A4;
            newQuestion.Question_B1 = paper.Question_B1;
            newQuestion.Question_B2 = paper.Question_B2;
            newQuestion.Question_C1 = paper.Question_C1;
            newQuestion.Question_C2 = paper.Question_C2;
            newQuestion.MarksA = paper.MarksA;
            newQuestion.MarksB = paper.MarksB;
            newQuestion.MarksC = paper.MarksC;
            newQuestion.Note = paper.Note;
        }

        public static void update(QuestionPaper paper)
        {
            var existing = GetById(paper.Id);
            if (existing == null) return;

            existing.Institute = paper.Institute;
            existing.Program = paper.Program;
            existing.Department = paper.Department;
            existing.Subject = paper.Subject;
            existing.SubjectCode = paper.SubjectCode;
            existing.ExamName = paper.ExamName;
            existing.Semester = paper.Semester;
            existing.Year = paper.Year;
            existing.FullMarks = paper.FullMarks;
            existing.Duration = paper.Duration;
            existing.SectionA = paper.SectionA;
            existing.SectionB = paper.SectionB;
            existing.SectionC = paper.SectionC;
            existing.Question_A1 = paper.Question_A1;
            existing.Question_A2 = paper.Question_A2;
            existing.Question_A3 = paper.Question_A3;
            existing.Question_A4 = paper.Question_A4;
            existing.Question_B1 = paper.Question_B1;
            existing.Question_B2 = paper.Question_B2;
            existing.Question_C1 = paper.Question_C1;
            existing.Question_C2 = paper.Question_C2;
            existing.MarksA = paper.MarksA;
            existing.MarksB = paper.MarksB;
            existing.MarksC = paper.MarksC;
            existing.Note = paper.Note;


            
        }

    }
}
