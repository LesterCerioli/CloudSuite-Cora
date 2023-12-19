using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses
{
	public class CheckExtractExistsByStartDateResponse : Response
	{
		public Guid RequestId {  get; private set; }
		public bool Exists {  get; set; }

        public CheckExtractExistsByStartDateResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach(var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckExtractExistsByStartDateResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}
