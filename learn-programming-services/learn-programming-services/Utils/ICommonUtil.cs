using learn_programming_services.Database.Entity;

namespace learn_programming_services.Utils
{
    public interface ICommonUtil
    {
        Task<int> totalPages(int pageSize, int totalList);
    }
}
