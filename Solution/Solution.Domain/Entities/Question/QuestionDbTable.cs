using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities.Question
{
    public class QuestionDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        [DataType(DataType.Date)] public DateTime DateAdded { get; set; }
    }
}
