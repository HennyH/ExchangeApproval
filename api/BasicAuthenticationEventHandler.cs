using ExchangeApproval.Data;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ZNetCS.AspNetCore.Authentication.Basic;
using ZNetCS.AspNetCore.Authentication.Basic.Events;
using static ExchangeApproval.Data.Queries;

namespace ExchangeApproval
{
    public class BasicAuthenticationEventHandler : BasicAuthenticationEvents
    {
        private readonly ExchangeDbContext _db;

        public BasicAuthenticationEventHandler(ExchangeDbContext db)
        {
            this._db = db;
        }

        public override Task ValidatePrincipalAsync(ValidatePrincipalContext context)
        {
            if (QueryIsValidStaffLogon(_db, context.UserName, context.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, context.UserName, context.Options.ClaimsIssuer)
                };

                var principle = new ClaimsPrincipal(new ClaimsIdentity(claims, BasicAuthenticationDefaults.AuthenticationScheme));
                context.Principal = principle;

                var ticket = new AuthenticationTicket(principle, new AuthenticationProperties(), BasicAuthenticationDefaults.AuthenticationScheme);
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return Task.FromResult(AuthenticateResult.Fail("Authentication failed."));
        }
    }
}
