using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proiect.Models.Case
{
    public class CaseViewData
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public int TotalSum { get; set; }
        public int CollectedSum { get; set; }
        public string Currency { get; set; }
        public string ImagePath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateAdded { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
    }
}