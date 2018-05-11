
namespace RedTeam.Common.Token.Interfaces
{
    public interface ITokenFactory
    {
        ITokenValidator CreateTokenValidator();

        ITokenCreator CreateTokenCreator();
    }
}
