using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace RedTeam.SurveyMaster.WebApi.OwinMiddleware
{
    public class GlobalExceptionMiddleware : Microsoft.Owin.OwinMiddleware
    {
        public GlobalExceptionMiddleware(Microsoft.Owin.OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}