using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserDataAPI.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class UserDataModel
    {
        [Required]
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }
    }
}
