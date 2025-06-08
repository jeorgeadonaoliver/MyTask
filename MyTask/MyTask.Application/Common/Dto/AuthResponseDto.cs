using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Common.Dto
{
    public class AuthResponseDto
    {
        public string fullName { get; set; } = string.Empty; 

        public string token { get; set; } = string.Empty;

        public string role { get; set; } = string.Empty;
    }
}
