public class LearningActivityEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/api/learning-activities", (ILearningActivityService service,
            ILogger<LearningActivityEndpoints> logger) =>
        {
            var result = service.GetAll();
            logger.LogInformation("Fetched all learning activities");
            return Results.Ok(ApiResponse<List<LearningActivity>>.Ok(result));
        });
        app.MapGet("/api/learning-activities/{id}", (int id, ILearningActivityService service) =>
        {
            var activity = service.GetById(id);

            return activity is not null ? Results.Ok(ApiResponse<LearningActivity>.Ok(activity)) : 
                    Results.NotFound(ApiResponse<LearningActivity>.Fail("Activity not found"));
        });

        app.MapPost("/api/learning-activities", (LearningActivity activity, ILearningActivityService service) =>
        {
            var added = service.Add(activity);
            return Results.Created($"/api/learning-activities/{added.Id}",
                ApiResponse<LearningActivity>.Ok(added));
        });
    }
}