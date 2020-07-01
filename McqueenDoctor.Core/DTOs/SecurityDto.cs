using McqueenDoctor.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace McqueenDoctor.Core.DTOs
{
    public class SecurityDto
    {
        public string User { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role? Role { get; set; }
    }
}
