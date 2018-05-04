
namespace RedTeam.Common.Token.Interfases
{
    public interface ITokenFactory
    {
        ITokenValidator CreateTokenValidator();

        ITokenCreator CreateTokenCreator();
    }
}
