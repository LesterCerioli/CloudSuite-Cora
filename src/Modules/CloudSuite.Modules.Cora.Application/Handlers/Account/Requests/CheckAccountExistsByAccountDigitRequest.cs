using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account.Requests
{
    public class CheckAccountExistsByAccountDigitRequest : IRequest<CheckAccountExistsByAccountDigitResponse>
    {
        public Guid Id {  get; private set; }
        public string Digit { get; set; }

        public CheckAccountExistsByAccountDigitRequest(string digit)
        {
            Id = Guid.NewGuid();
            Digit = digit;
        }
    }
}
