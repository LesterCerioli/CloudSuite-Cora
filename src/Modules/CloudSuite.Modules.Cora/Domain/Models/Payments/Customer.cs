using CloudSuite.Modules.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Models.Payments
{
	public class Customer
	{
        public Cnpj Cnpj { get; private set; }

        public string? SocialReason { get; private set; }

        public string? ResponsibeContact { get; private set; }

        public Telephone Telephone { get; private set; }
    }
}
