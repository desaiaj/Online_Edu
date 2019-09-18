using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class ExamDataContext : DbContext
    {
        public ExamDataContext()
            : base("name=ConString")
        { }

        public List<ExamModel> GetExamList()
        {
            return new ExamDataContext().Database.SqlQuery<ExamModel>("GetExamList").ToList();
        }

        public List<ExamModel> GenerateExamPaper(decimal id)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("ExamTypeID", id.handleDBNull()));
            return new ExamDataContext().Database.SqlQuery<ExamModel>("GenerateExam".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).ToList();
        }
        public string InsertQuestion(ExamModel loExam)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("Question", loExam.Question.handleDBNull()));
            ProcParam.Add(new SqlParameter("Answer", loExam.Answer.handleDBNull()));
            ProcParam.Add(new SqlParameter("option1", loExam.option1.handleDBNull()));
            ProcParam.Add(new SqlParameter("option2", loExam.option2.handleDBNull()));
            ProcParam.Add(new SqlParameter("option3", loExam.option3.handleDBNull()));
            ProcParam.Add(new SqlParameter("ExamTypeID", loExam.ExamTypeID = 1));
            ProcParam.Add(new SqlParameter("TutorialsID", loExam.TutorialsID = 1));
            if (Convert.ToBoolean(new ExamDataContext().Database.ExecuteSqlCommand("EXEC InsertQuestions @Question,@Answer,@option1,@option2,@option3,@ExamTypeID,@TutorialsID", ProcParam.ToArray())))
                return "Inserted";
            else
                return "not Inserted";
        }

        public int GenerateResult(ResultModel loResult)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("UserID", loResult.UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("ExamTypeID", loResult.ExamTypeID.handleDBNull()));
            ProcParam.Add(new SqlParameter("Result", loResult.Result.handleDBNull()));
            ProcParam.Add(new SqlParameter("Time", loResult.TimeTaken.handleDBNull()));
            ProcParam.Add(new SqlParameter("Marks", loResult.ObtainedMarks.handleDBNull()));
            ProcParam.Add(new SqlParameter("Grade", loResult.Grade.handleDBNull()));
            ProcParam.Add(new SqlParameter("Rank", loResult.Rank.handleDBNull()));
            ProcParam.Add(new SqlParameter("CreatedOn", loResult.CreatedOn.handleDBNull()));
            return new ExamDataContext().Database.ExecuteSqlCommand("EXEC GenerateResult @UserID,@ExamTypeID,@Result,@Time,@Marks,@grade,@Rank,@CreatedOn", ProcParam.ToArray());
        }

        public List<ResultModel> GetResult(decimal UserID)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            return new ExamDataContext().Database.SqlQuery<ResultModel>("GetResult".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).ToList();
        }
    }
}