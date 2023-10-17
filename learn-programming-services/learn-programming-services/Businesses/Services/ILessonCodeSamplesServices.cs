using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ILessonCodeSamplesServices
    {
        Task CreateNewLessonCodeSample(LessonCodeSamples lessonCodeSample);

        Task<IEnumerable<LessonCodeSamples>> FindLessonCodeSamplesByLessonId(int lessonId);

        Task UpdateLessonCodeSample(LessonCodeSamples lessonCodeSample);
    }
}
