using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.Common.Token.Interfases
{
    public interface ITokenCreator
    {
        SecurityToken CreateSecurityToken(string userName, Role userRole);

        string SerializeToken(SecurityToken token);
    }
}
