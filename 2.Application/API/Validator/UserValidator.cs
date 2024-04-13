using FluentValidation;
using Common;

namespace API.Validator
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username).NotEmpty().WithMessage("O nome de usuário é obrigatório.");
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Um endereço de e-mail válido é obrigatório.");
            RuleFor(user => user.Password).NotEmpty().MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");
            RuleFor(user => user.ConfirmPassword).Equal(user => user.Password).WithMessage("A senha e a confirmação de senha não correspondem.");
        }
    }
}
