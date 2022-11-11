using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusERP.Core.Utilities.Conversion
{
    public static class JSONConverter
    {
        public static string ConvertToJSON(dynamic value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public static dynamic ConvertFromJSON(string json)
        {
            return -1;
        }
    }
}
