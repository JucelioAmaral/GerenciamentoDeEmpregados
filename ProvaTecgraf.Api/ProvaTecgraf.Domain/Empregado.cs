using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaTecgraf.Domain
{
    public class Empregado
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool CurrentlyEmployed { get; set; }
    }
}
