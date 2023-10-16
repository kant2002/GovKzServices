using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovKzServices.Tests;

internal class FileHttpHandler : DelegatingHandler
{
    private readonly string file;

    public FileHttpHandler(string file)
    {
        this.file = file;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        responseMessage.Content = new StringContent(await File.ReadAllTextAsync(file, cancellationToken));
        return responseMessage;
    }
}
