using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.Serialization
{
    public static class Serializer
    {
        public static string ToJSON(object obj)
        {
            string result = JsonConvert.SerializeObject(
                obj,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
            return result;
        }

        public static T Deserialize<T>(string obj, string dateFormat = null)
        {
            if (String.IsNullOrEmpty(dateFormat))
            {
                return JsonConvert.DeserializeObject<T>(obj);
            }

            return JsonConvert.DeserializeObject<T>(obj, new IsoDateTimeConverter { DateTimeFormat = dateFormat });
        }

        public static T DeserializeFromFile<T>(string filePath, string dateFormat = null)
        {
            return Deserialize<T>(File.ReadAllText(filePath), dateFormat);
        }

    }
}
