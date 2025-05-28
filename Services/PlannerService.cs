using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG_Graph.Services;

public class PlannerService : IPlannerService
{
    private readonly IGraphClientService _graphClientService;

    public PlannerService(IGraphClientService graphClientService)
    {
        _graphClientService = graphClientService;
    }

    public async Task<IEnumerable<PlannerPlan>> GetAllPlans()
    {
        var graphClient = _graphClientService.GetAuthenticatedClient();
        var plans = await graphClient.Planner.Plans
            .Request()
            .GetAsync();
        return plans.CurrentPage;
    }

    public async Task<IEnumerable<PlannerPlan>> GetGroupPlans(string groupId)
    {
        var graphClient = _graphClientService.GetAuthenticatedClient();
        var plans = await graphClient.Groups[groupId].Planner.Plans
            .Request()
            .GetAsync();
        return plans.CurrentPage;
    }

    public async Task<IEnumerable<PlannerTask>> GetPlanTasks(string planId)
    {
        var graphClient = _graphClientService.GetAuthenticatedClient();
        var tasks = await graphClient.Planner.Plans[planId].Tasks
            .Request()
            .GetAsync();
        return tasks.CurrentPage;
    }

    public async Task<PlannerTaskDetails> GetTaskDetails(string taskId)
    {
        var graphClient = _graphClientService.GetAuthenticatedClient();
        return await graphClient.Planner.Tasks[taskId].Details
            .Request()
            .GetAsync();
    }
}