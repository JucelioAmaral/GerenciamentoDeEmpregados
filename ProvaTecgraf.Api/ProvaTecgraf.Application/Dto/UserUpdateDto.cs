using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecgraf.Application.Dto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }        
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string lastNome { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsEmployee { get; set; }        
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
