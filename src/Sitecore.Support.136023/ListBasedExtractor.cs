using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;

namespace Sitecore.Support
{
  public class ListBasedExtractor : IIPExtractor
  {
    public string ExtractIP()
    {
      if (string.IsNullOrEmpty(HeaderName))
      {
        return null;
      }

      var configHeaderValue = HttpContext.Current.Request.ServerVariables[HeaderName];
      if (string.IsNullOrEmpty(configHeaderValue))
      {
        return null;
      }

      string[] source = configHeaderValue.Split(new char[] { ',' });
      int headerIpIndex = this.HeaderIPIndex;
      string str = (headerIpIndex < source.Length) ? source[headerIpIndex] : source.LastOrDefault<string>();
      if (string.IsNullOrEmpty(str))
      {
        return null;
      }
      return str.Trim();
    }

    public int HeaderIPIndex { get; set; }

    public string HeaderName { get; set; }
  }
}