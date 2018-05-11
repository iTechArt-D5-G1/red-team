using RedTeam.Common.Token.Concrete_Token_Creators;
using RedTeam.Common.Token.Concrete_Validators;
using RedTeam.Common.Token.Interfaces;

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
