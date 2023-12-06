﻿using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses
{
    public class CheckTransferExistsByCodeResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists {  get; set; }

        public CheckTransferExistsByCodeResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach(var item in result.Errors)
            {
                this.AddError(item.ErrorMessage)
            }
        }

        public CheckTransferExistsByCodeResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}