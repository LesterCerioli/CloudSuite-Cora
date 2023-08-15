using CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Addresses
{
  public class CheckAddressExistsByAddressLineRequestValidation : AbstractValidator<CheckAddressExistsByAddressLineRequest>
  {
    public CheckAddressExistsByAddressLineRequestValidation()
    {
      RuleFor(command => command.AddressLine1)
      .NotEmpty()
      .MaximumLength(50)
      .WithMessage("AddressLine1 deve ser preenchida");
    }
  }
  
}