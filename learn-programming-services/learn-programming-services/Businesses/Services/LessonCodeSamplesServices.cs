using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class LessonCodeSamplesServices : ILessonCodeSamplesServices
    {
        private readonly ILessonCodeSamplesRepository _lessonCodeSamplesRepository;

        public LessonCodeSamplesServices(ILessonCodeSamplesRepository lessonCodeSamplesRepository)
        {
            _lessonCodeSamplesRepository = lessonCodeSamplesRepository;
        }

        public async Task CreateNewLessonCodeSample(LessonCodeSamples lessonCodeSample)
        {
            await _lessonCodeSamplesRepository.createNewLessonCodeSample(lessonCodeSample);
        }

        public async Task<IEnumerable<LessonCodeSamples>> FindLessonCodeSamplesByLessonId(int lessonId)
        {
            return await _lessonCodeSamplesRepository.findLessonCodeSamplesByLessonId(lessonId);
        }

        public async Task UpdateLessonCodeSample (LessonCodeSamples lessonCodeSample)
        {
            await _lessonCodeSamplesRepository.updateLessonCodeSample(lessonCodeSample);
        }
    }
}
