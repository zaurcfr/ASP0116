using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116
{
    public static class SessionExtension
    {
        public static T GetObject<T>(this ISession session, string key)
        {
            var stringData = session.GetString(key);
            var objectData = JsonConvert.DeserializeObject<T>(stringData);
            return objectData;
        }

        public static void SetObject<T>(this ISession session, string key, T objectData)
        {
            var jsonData = JsonConvert.SerializeObject(objectData);
            session.SetString(key, jsonData);
        }
    }
}
