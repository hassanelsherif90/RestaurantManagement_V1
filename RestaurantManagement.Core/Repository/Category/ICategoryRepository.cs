using RestaurantManagement.Core.Models.Data;

namespace RestaurantManagement.Core.Repository.CategoryRe
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<IEnumerable<Category>> GetActiveCategories();
        Task<Category> GetCategoryWithMenuItems(int categoryId);
    }
}
