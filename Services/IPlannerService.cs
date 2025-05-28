using Microsoft.Graph;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG_Graph.Services;

public interface IPlannerService
{
    Task<IEnumerable<PlannerPlan>> GetAllPlans();
    Task<IEnumerable<PlannerPlan>> GetGroupPlans(string groupId);
    Task<IEnumerable<PlannerTask>> GetPlanTasks(string planId);
    Task<PlannerTaskDetails> GetTaskDetails(string taskId);
}