using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Protocols.Common.Utilities
{
    public class ByteArrayHelper<T>
    {
        public static byte[] SerializeToByteArray(T value)
        {
            var json = JsonConvert.SerializeObject(value);
            return Encoding.UTF8.GetBytes(json);
        }

        public static byte[] ToByteArray(string value)
        {            
            return Encoding.UTF8.GetBytes(value);
        }

        public static string FromByteArrayToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static T DeserializeToObject(byte[] data)
        {
            var json = Encoding.UTF8.GetString(data);            
            return JsonConvert.DeserializeObject<T>(json);          
        }
    }
}
