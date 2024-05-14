using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities.Card
{
    public class UCardData
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
