using System.Net;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Pipelines.HttpRequest;

namespace Sitecore.Support
{
  public class ConfigureRemoteAddress : HttpRequestProcessor
  {
    public override void Process(HttpRequestArgs args)
    {
      if (IPExtractor == null)
        return;

      string ipAddress = IPExtractor.ExtractIP();

      if (string.IsNullOrWhiteSpace(ipAddress))
        return;

      HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] = ipAddress;

    }

    public IIPExtractor IPExtractor { get; set; }
  }
}