using System.ComponentModel.DataAnnotations;

namespace Personal.ViewModels.Login
{
    public class UserResultBase
    {
        public bool Success { get; set; }
    }
    public class UserViewModelBase
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    
    public class LoginViewModel : UserViewModelBase {}

    public class LoginResult : UserResultBase
    {
        public string Token { get; set; }
    }

    public class UpdatePassword : UserViewModelBase
    {
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }

    public class UpdatePasswordResult : UserResultBase {}
}