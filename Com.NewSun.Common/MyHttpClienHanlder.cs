using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net.Http;

namespace Com.NewSun.Common
{
    public class MyHttpClienHanlder : HttpClientHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var rsponse = await base.SendAsync(request, cancellationToken);
            var contentType = rsponse.Content.Headers.ContentType;
            if (string.IsNullOrEmpty(contentType.CharSet))
            {
                contentType.CharSet = "GBK";
            }
            return rsponse;
        }
    }
}
