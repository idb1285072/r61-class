using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using M8_evd_Master_Token.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace M8_evd_Master_Token.Provider
{
    public class APIAUTHORIZATIONSERVERPROVIDER:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // return base.ValidateClientAuthentication(context);
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // return base.GrantResourceOwnerCredentials(context);
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new DbInvContext()));
            IdentityUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(identity);
        }
    }
}