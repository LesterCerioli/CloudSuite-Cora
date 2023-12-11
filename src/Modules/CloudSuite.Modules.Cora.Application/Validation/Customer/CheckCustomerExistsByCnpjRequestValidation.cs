using CloudSuite.Modules.Cora.Application.Handlers.Customer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Customer
{
    public class CheckCustomerExistsByCnpjRequestValidation : AbstractValidator<CheckCustomerExistsByCnpjRequest>
    {
    }
}
