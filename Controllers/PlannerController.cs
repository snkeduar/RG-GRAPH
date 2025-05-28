using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using RG_Graph.Models;
using RG_Graph.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG_Graph.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PlannerController : ControllerBase
{
    private readonly IPlannerService _plannerService;

    public PlannerController(IPlannerService plannerService)
    {
        _plannerService = plannerService;
    }

    [HttpGet("plans")]
    public async Task<ActionResult<ApiResponse<IEnumerable<PlannerPlan>>>> GetAllPlans()
    {
        try
        {
            var plans = await _plannerService.GetAllPlans();
            return Ok(ApiResponse<IEnumerable<PlannerPlan>>.CreateSuccess(plans));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<IEnumerable<PlannerPlan>>.CreateError(ex.Message));
        }
    }

    [HttpGet("groups/{groupId}/plans")]
    public async Task<ActionResult<ApiResponse<IEnumerable<PlannerPlan>>>> GetGroupPlans(string groupId)
    {
        try
        {
            var plans = await _plannerService.GetGroupPlans(groupId);
            return Ok(ApiResponse<IEnumerable<PlannerPlan>>.CreateSuccess(plans));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<IEnumerable<PlannerPlan>>.CreateError(ex.Message));
        }
    }

    [HttpGet("plans/{planId}/tasks")]
    public async Task<ActionResult<ApiResponse<IEnumerable<PlannerTask>>>> GetPlanTasks(string planId)
    {
        try
        {
            var tasks = await _plannerService.GetPlanTasks(planId);
            return Ok(ApiResponse<IEnumerable<PlannerTask>>.CreateSuccess(tasks));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<IEnumerable<PlannerTask>>.CreateError(ex.Message));
        }
    }

    [HttpGet("tasks/{taskId}/details")]
    public async Task<ActionResult<ApiResponse<PlannerTaskDetails>>> GetTaskDetails(string taskId)
    {
        try
        {
            var details = await _plannerService.GetTaskDetails(taskId);
            return Ok(ApiResponse<PlannerTaskDetails>.CreateSuccess(details));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<PlannerTaskDetails>.CreateError(ex.Message));
        }
    }
}