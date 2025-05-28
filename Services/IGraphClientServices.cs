using Microsoft.Graph;

namespace RG_Graph.Services;

public interface IGraphClientService
{
    GraphServiceClient GetAuthenticatedClient();
}