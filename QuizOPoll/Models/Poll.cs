using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizOPoll.Models
{
    public class Poll
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<PollAnswer> PollAnswers { get; set; }
        public virtual ICollection<PollCategory> Categories { get; set; }
        public virtual ICollection<Score> Scores { get; set; }

    }
}