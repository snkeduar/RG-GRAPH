using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace RG_Graph.Services;

public class GraphClientService : IGraphClientService
{
    private readonly GraphServiceClient _graphClient;

    public GraphClientService(ITokenAcquisition tokenAcquisition, IConfiguration configuration)
    {
        var scopes = configuration["DownstreamApi:Scopes"]?.Split(' ');
        
        _graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(async (request) => 
        {
            var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(scopes);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }))
        {
            BaseUrl = configuration["DownstreamApi:BaseUrl"]
        };
    }

    public GraphServiceClient GetAuthenticatedClient() => _graphClient;
}