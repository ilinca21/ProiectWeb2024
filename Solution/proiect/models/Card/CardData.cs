using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proiect.Models.Card
{
    public class CardData
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int CVV { get; set; }
        public int Sum { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
    }
}