using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Customer
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            RuleFor(a => a.Cnpj)
                .Must(cnpj => IsValid(cnpj))
                .WithMessage("O campo Cnpj é inválido.");

            RuleFor(a => a.SocialReason)
                .NotEmpty()
                .WithMessage("O campo SocialReason é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo SocialReason deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo SocialReason deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo SocialReason não pode ser nulo.");

            RuleFor(a => a.TelephoneNumber)
                .Must(telephone => Telephone.ValidarTelefone(telephone))
                .WithMessage("O campo Telefone é inválido.");

            RuleFor(a => a.TelephoneRegion)
                .Length(1, 3)
                .WithMessage("O campo TelephoneRegion deve ter entre 1 e 3 caracteres.");

            RuleFor(a => a.ResponsibeContact)
                .Length(1, 100)
                .WithMessage("O campo Contato deve ter entre 1 e 100 caracteres.")
                .NotNull()
                .WithMessage("O campo Contato não pode ser nulo."); ;
        }

        private bool IsValid(string cnpjNumber)
        {
            // Check if the input is null or empty
            if (string.IsNullOrWhiteSpace(cnpjNumber))
                return false;

            // Remove non-digit characters
            cnpjNumber = new string(cnpjNumber.Where(char.IsDigit).ToArray());

            // CNPJ must have 14 digits
            if (cnpjNumber.Length != 14)
                return false;

            // Check for repeated digits or invalid checksum
            if (IsRepeatedDigits(cnpjNumber) || !IsValidChecksum(cnpjNumber))
                return false;

            return true;
        }

        // Private method to check for repeated digits
        private bool IsRepeatedDigits(string cnpjNumber)
        {
            return cnpjNumber.Distinct().Count() == 1;
        }

        // Private method to validate the CNPJ checksum
        private bool IsValidChecksum(string cnpjNumber)
        {
            var sum = 0;
            var multiplier = 5;

            // Calculate the first checksum digit
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            var remainder = sum % 11;
            var digit1 = (remainder < 2) ? 0 : 11 - remainder;

            sum = 0;
            multiplier = 6;

            // Calculate the second checksum digit
            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            remainder = sum % 11;
            var digit2 = (remainder < 2) ? 0 : 11 - remainder;

            // Compare the calculated checksum digits with the provided ones
            return (int.Parse(cnpjNumber[12].ToString()) == digit1) && (int.Parse(cnpjNumber[13].ToString()) == digit2);
        }

    }
}
