using FluentValidation;
using SquadManager.Models;

namespace SquadManager.Validator
{
  public class UserValidator : AbstractValidator<UserViewModel>
  {
    public UserValidator()
    {
      RuleFor(user => user.Email)
      .NotNull().WithMessage("Email é obrigatório")
      .EmailAddress().WithMessage("Email inválido");
      RuleFor(user => user.Password).NotNull().WithMessage("Senha é obrigatória");
    }
  }
}