using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Background.Models
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        [ForeignKey("PostId")] 
        public Post Post { get; set; }
        public string Content { get; set; }
        public bool IsLike { get; set; }
        public User User { get; set; }
    }
}