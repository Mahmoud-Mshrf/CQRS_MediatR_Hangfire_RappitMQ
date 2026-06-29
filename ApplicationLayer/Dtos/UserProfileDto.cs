using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Dtos
{
    public class UserProfileDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
