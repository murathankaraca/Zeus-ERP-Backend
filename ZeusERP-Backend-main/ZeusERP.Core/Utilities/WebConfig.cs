using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ZeusERP.Core.Utilities
{
    public static class WebConfig
    {
        public static async Task<string> GetConfigItem(string item)
        {
            string ConnectionString = string.Empty;
            try
            {
                var appSettings = await File.ReadAllTextAsync($"{Directory.GetCurrentDirectory()}/appsettings.json", Encoding.UTF8);
                var json = JsonConvert.DeserializeObject<JObject>(appSettings);
                ConnectionString = json.GetValue("ConnectionStrings").Value<dynamic>(item);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return ConnectionString;
        }
    }
}
