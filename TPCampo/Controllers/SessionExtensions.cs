using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

using System.Text;

using System.Data;

using Newtonsoft.Json;
using TPCampo.Models;

namespace TPCampo.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object? value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static UsuarioModel GetObject<UsuarioModel>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(UsuarioModel) : JsonConvert.DeserializeObject<UsuarioModel>(value);
        }
    }



}

