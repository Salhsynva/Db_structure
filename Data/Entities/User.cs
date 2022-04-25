using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Entities
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
