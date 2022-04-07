using ProvaTecgraf.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaTecgraf.Domain
{
    public class Empregado
    {     
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool CurrentlyEmployed { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
