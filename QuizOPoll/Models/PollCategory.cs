using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizOPoll.Models
{
    public class PollCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Tag { get; set; }

        public virtual ICollection<Poll> Polls { get; set; }

    }
}