using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Background.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsModer { get; set; }
        public Guid? MediaId { get; set; }
        [ForeignKey("MediaId")] public Media Media { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}