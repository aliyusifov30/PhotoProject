using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.DTOs.JwtDTOs
{
    public class JwtDto
    {

        public string AudienceValue { get; set; }
        public string IssuerValue { get; set; }
        public string SecurityKey { get; set; }
        public int TokenSecond { get; set; }

    }
}
