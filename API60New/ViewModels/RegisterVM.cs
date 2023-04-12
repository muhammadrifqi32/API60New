using API60New.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API60New.ViewModels
{
    public class RegisterVM
    {
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        //format yyyy-mm-dd
        public int Salary { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public int Department_Id { get; set; }
        public string Password { get; set; }
    }
}
