using System.Net;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Pipelines.HttpRequest;

namespace Sitecore.Support
{
  public class ConfigureRemoteAddress: HttpRequestProcessor
  {
    public override void Process(HttpRequestArgs args)
    {
     
      var configHeader = Settings.GetSetting("JSNLog.RemoteAddressHeader", string.Empty);
      if (!string.IsNullOrEmpty(configHeader))
      {
        var configHeaderValue = HttpContext.Current.Request.ServerVariables[configHeader];
        if (!string.IsNullOrEmpty(configHeaderValue))
        {
          IPAddress ipaddress = null;
          if (IPAddress.TryParse(configHeaderValue, out ipaddress))
          {
            HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] = ipaddress.ToString();
          }
        }
      }
    }
  }
}