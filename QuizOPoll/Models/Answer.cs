using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizOPoll.Models
{
    public class Answer
    {
        public int Id { get; set;  }
        public int QuestionId { get; set; }
        
        [Required]
        [StringLength(256)]
        public string Content { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

    }
}