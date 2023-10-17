using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ILessonCodeSamplesRepository
    {
        Task createNewLessonCodeSample(LessonCodeSamples lessonCodeSample);

        Task<IEnumerable<LessonCodeSamples>> findLessonCodeSamplesByLessonId(int lessonId);

        Task updateLessonCodeSample(LessonCodeSamples lessonCodeSample);
    }
}
