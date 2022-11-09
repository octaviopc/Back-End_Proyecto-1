using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Back_End.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType_enum
    {
        Client=1,
        Developer=2,
        Manager=3
    }
}