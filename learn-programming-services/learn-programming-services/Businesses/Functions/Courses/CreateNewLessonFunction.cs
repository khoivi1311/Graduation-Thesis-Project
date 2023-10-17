using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ICreateNewLessonFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class CreateNewLessonFunction : ICreateNewLessonFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public CreateNewLessonFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> CreateNewLesson(Request request)
        {
            List<string> errors = new List<string>();

            if ((request.newLesson.lessonName != null && request.newLesson.lessonName.Trim() != "") &&
               (request.newLesson.content != null && request.newLesson.content.Trim() != "") &&
               (request.newLesson.score > 0) &&
               (request.newLesson.chapterId > 0) &&
               (request.newLesson.authorId > 0) &&
               (request.newLesson.testCases != null && request.newLesson.testCases.Count() > 0) &&
               (request.newLesson.codeSamples != null && request.newLesson.codeSamples.Count() > 0)) 
            {
                foreach (var testCase in request.newLesson.testCases)
                {
                    if((testCase.input == null || testCase.input.Trim() == "") || 
                       (testCase.expectedOutput == null || testCase.expectedOutput.Trim() == ""))
                    {
                        errors.Add("The test case have input: " + testCase.input.Trim() + " and expected output: " + testCase.expectedOutput + " invalid");
                    }
                }

                foreach (var codeSample in request.newLesson.codeSamples)
                {
                    if ((codeSample.codeSample == null || codeSample.codeSample.Trim() == "") || codeSample.codeLanguageId <= 0)
                    {
                        errors.Add("The code sample have code: " + codeSample.codeSample.Trim() + " and code language id: " + codeSample.codeLanguageId + " invalid");
                    }
                }

                if (errors.Count > 0)
                {
                    return new Response(false, errors);
                }

                var response = await _lessonsServices.CreateNewLesson(request);
                return response;
            }
            errors.Add("The fields are not allowed to be null");
            return new Response(false, errors);
        }
    }
}
