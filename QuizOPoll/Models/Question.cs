using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizOPoll.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }

        [Required]
        [StringLength(256)]
        public string Content { get; set; }

        public virtual Answer Answers { get; set; }

    }
}