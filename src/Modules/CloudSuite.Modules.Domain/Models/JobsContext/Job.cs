﻿using CloudSuite.Modules.Domain.Shared.Enums.JobsContext;
using NetDevPack.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.JobsContext
{

    [Serializable]
    internal class JobResultWrapper
    {
<<<<<<< HEAD
        [JsonProperty(PropertyName = "Result")]
        public dynamic Result { get; private set; } = null;
    }

    [Serializable]
    public class Job
    {
        [JsonProperty(PropertyName = "type_id")]
        public Guid TypeId { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public JobType Type { get; private set; }

        [JsonProperty(PropertyName = "type_name")]
        public string TypeName { get; private set; }

        [JsonProperty(PropertyName = "complete_class_name")]
        public string CompleteClassName { get; private set; }

        [JsonProperty(PropertyName = "attributes")]
        public dynamic Attributes { get; private set; }

        [JsonProperty(PropertyName = "result")]
        public dynamic Result { get; private set; }

        [JsonProperty(PropertyName = "status")]

        public JobStatus Status { get; private set; }

        [JsonProperty(PropertyName = "priority")]
        public JobPriority Priority { get; private set; }

        [JsonProperty(PropertyName = "started_on")]
        public DateTime? StartOn { get; private set; }

        [JsonProperty(PropertyName = "finished_on")]
        public DateTime? FinishedOn { get; private set; }

        [JsonProperty(PropertyName = "aborted_by")]
        public Guid? AbortedBy { get; private set; }

        [JsonProperty(PropertyName = "canceled_by")]
        public Guid? CanceledBy { get; private set; }

        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; private set; }

        [JsonProperty(PropertyName = "schedule_plan_id")]
        public Guid? SchedulePlanId { get; private set; }

        [JsonProperty(PropertyName = "created_on")]
        public DateTime CreatedOn { get; private set; }

        [JsonProperty(PropertyName = "created_by")]
        public Guid? CreatedBy { get; private set; }

        [JsonProperty(PropertyName = "last_modified_on")]
        public DateTime LastModifiedOn { get; private set; }

        [JsonProperty(PropertyName = "last_modified_by")]
        public Guid? LastModifiedBy { get; private set; }
=======
        [Required(ErrorMessage = "The {0} field is required.")]

        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Conde3 { get; set;}

        public bool IsBillingEnabled { get; set; }

        public bool IsShippingEnabled { get; set; }

        public bool IsCityEnabled { get; set; }

        public bool IsZipCodeEnabled { get; set; }

        public bool IsDistrictEnabled { get; set; }

>>>>>>> c21005c5fb1fb2c6728965dc0ce26fc938c49834
    }
}
