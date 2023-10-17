using learn_programming_services.Businesses.Functions.Practices;

namespace learn_programming_services.Businesses.Services
{
    public interface IPracticesServices
    {
        Task<ICreateNewPracticeFunction.Response> CreateNewPractice(ICreateNewPracticeFunction.Request request);

        Task<IGetPracticesManagementFunction.Response> GetPracticesManagement(IGetPracticesManagementFunction.Request request);

        Task<IGetPracticeDetailsManagementFunction.Response> GetPracticeDetailsManagement(IGetPracticeDetailsManagementFunction.Request request);

        Task<IDeletePracticeFunction.Response> DeletePractice(IDeletePracticeFunction.Request request);

        Task<IHiddenPracticeFunction.Response> HiddenPractice(IHiddenPracticeFunction.Request request);

        Task<IUpdatePracticeFunction.Response> UpdatePractice(IUpdatePracticeFunction.Request request);

        Task<IGetPracticesFunction.Response> GetPractices(IGetPracticesFunction.Request request);

        Task<IGetPracticeDetailsFunction.Response> GetPracticeDetails(IGetPracticeDetailsFunction.Request request);

        Task<IRunCodePracticeFunction.Response> RunCodePractice(IRunCodePracticeFunction.Request request);

        Task<ISubmitCodePracticeFunction.Response> SubmitCodePractice(ISubmitCodePracticeFunction.Request request);
    }
}
