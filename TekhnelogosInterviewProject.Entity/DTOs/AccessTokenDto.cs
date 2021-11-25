using System;
using System.Collections.Generic;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.DTOs
{
    public class AccessTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        //public string RefreshToken { get; set; }
    }
}
