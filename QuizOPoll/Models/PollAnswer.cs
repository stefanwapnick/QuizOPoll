using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizOPoll.Models
{
    public class PollAnswer
    {
        public int Id { get; set; }
        public int PollId { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}