using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedTeam.Common.Token.Concrete_Token_Creators;
using RedTeam.Common.Token.Concrete_Validators;
using RedTeam.Common.Token.Interfases;

namespace RedTeam.Common.Token.Concrete_Factories
{
    public class JwtTokenFactory : ITokenFactory
    {
        public ITokenValidator CreateTokenValidator()
        {
            return new JwtTokenValidator();
        }

        public ITokenCreator CreateTokenCreator()
        {
            return new JwtTokenCreator();
        }
    }
}
