﻿using CloudSuite.Infrastructure.Models;
using CloudSuite.Modules.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class User : IdentityUser<long>, IEntityWithTypedId<long>, IExtendableObject
    {
        public User()
        {
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
        }

        public const string SettingsDataKey = "Settings";

        public Guid UserGuid { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string FullName { get; set; }

        public Email Email { get; set; }

        public Cpf Cpf { get; set; }

        public long? VendorId { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public DateTimeOffset? LatestUpdatedOn { get; set; }

                
        //public long? DefaultShippingAddressId { get; set; }

        
        public long? DefaultBillingAddressId { get; set; }

        [StringLength(450)]
        public string? RefreshTokenHash { get; set; }

        public IList<UserRole> Roles { get; set; } = new List<UserRole>();

        public IList<CustomerGroupUser> CustomerGroups { get; set; } = new List<CustomerGroupUser>();

        [StringLength(450)]
        public string? Culture { get; set; }

        /// <inheritdoc />
        public string? ExtensionData { get; set; }
    }
}
