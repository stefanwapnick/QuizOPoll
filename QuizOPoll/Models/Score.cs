using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace QuizOPoll.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int QuizId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public double ScoreValue { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}