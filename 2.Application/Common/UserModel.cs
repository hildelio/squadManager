﻿namespace Common
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string? Type { get; set; }

        public string? ResetHash { get; set;}

        public int PersonId { get; set; }

        public PersonModel Person { get; set; }
    }

    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserForgotPasswordModel
    {
        public string Email { get; set; }
    }

    public class UserResetPasswordModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Id { get; set; }

    }

    public class UserDBModel
    {
        public string Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
