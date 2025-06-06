public class LearningActivityService : ILearningActivityService
{
    private static readonly List<LearningActivity> _activities = new()
    {
        new LearningActivity
        { Id = 1, ActivityName = "AWS Certified Developer",
            Code = "PES_07d7d673",
            Category = "Books / Self Reading",
            Status = "In progress",
            StartDate = DateTime.Parse("2020-11-11T01:56:00"),
            EndDate = DateTime.MinValue
        }
    };
    public List<LearningActivity> GetAll() => _activities;
    public LearningActivity? GetById(int id) => _activities.FirstOrDefault(a => a.Id == id);
    public LearningActivity Add(LearningActivity activity)
    {
        activity.Id = _activities.Max(a => a.Id) + 1;
        _activities.Add(activity);
        return activity;
    }
}