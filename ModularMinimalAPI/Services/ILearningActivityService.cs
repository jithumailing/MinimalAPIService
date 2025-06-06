public interface ILearningActivityService
{
    List<LearningActivity> GetAll();
    LearningActivity? GetById(int id);
    LearningActivity Add(LearningActivity activity);
}