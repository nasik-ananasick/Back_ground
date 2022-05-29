using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Background.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int LikesCount { get; set; }
        public Guid? MediaId { get; set; }
        [ForeignKey("MediaId")]
        public virtual Media Media { get; set; }
        //public string ImagePath { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}