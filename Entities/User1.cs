//using System.ComponentModel.DataAnnotations;

//namespace Entities
//{
//    public class User
//    {
//        static int UserCounter = 0;
//        public User(string FirstName, string LastName, string Password, string Email)
//        {
//            this.UserId = ++UserCounter;
//            this.FirstName = FirstName;
//            this.LastName = LastName;
//            this.Password = Password;
//            this.Email = Email; 
//        }
//        public int UserId { get; set; }
//        //[StringLength(20,ErrorMessage="FirstName length must be between 2-20" ,MinimumLength =2)]
//        public string? FirstName { get; set; }
//        //[StringLength(20, ErrorMessage = "LastName length must be between 2-20", MinimumLength = 2)]
//        public string? LastName { get; set; }
//        [Required]
//        public string Password { get; set; }
//        [Required]
//        [EmailAddress]
//        public string Email { get; set; }

//    }
//}
