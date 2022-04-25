using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Entities
{
    class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(4);
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
