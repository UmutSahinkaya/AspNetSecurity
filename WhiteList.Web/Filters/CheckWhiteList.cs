using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Net;
using WhiteList.Web.MiddleWares;

namespace WhiteList.Web.Filters
{
    public class CheckWhiteList:ActionFilterAttribute
    {
        private readonly IPList _ipList;

        public CheckWhiteList(IOptions<IPList> ipList)
        {
            _ipList = ipList.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var reqIpAdress = context.HttpContext.Connection.RemoteIpAddress;

            var isWhitelist=this._ipList.WhiteList.Where(x=>IPAddress.Parse(x).Equals(reqIpAdress)).Any();

            if (!isWhitelist)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
