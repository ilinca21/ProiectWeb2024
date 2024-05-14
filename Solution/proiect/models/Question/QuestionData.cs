using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proiect.Models.Question
{
    public class QuestionData
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
    }
}