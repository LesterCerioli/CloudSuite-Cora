using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Common.ValueObjects
{
	public class Method : ValueObject
	{
        public bool? PIX { get; set; }

        // Payment by Bar-Code
		public bool? BankSlip { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
		{
			throw new NotImplementedException();
		}
	}
}
