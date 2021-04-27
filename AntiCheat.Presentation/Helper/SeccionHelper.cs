using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
namespace AntiCheat.Helper
{
    public class SeccionHelper
    {

        public static string GetUsername(IPrincipal User)
        {

            var username = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name);
            return username == null ? "" : username.Value;


        }

        public static string GetUserId(IPrincipal User)
        {

            var userId = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return userId == null ? "" : userId.Value;


        }
    }
}
