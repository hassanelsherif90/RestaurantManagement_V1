using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository.CategoryRe;

namespace RestaurantManagement.DataAccess
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }

        public async Task<IEnumerable<Category>> GetActiveCategories()
        {
            return
                await _entities
                .Where(C => !C.IsDeleted && C.IsActive)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryWithMenuItems(int categoryId)
        {
            return await _entities.Include(c => c.MenuItems)
                .FirstOrDefaultAsync(c => c.CategoryId == categoryId && !c.IsDeleted);
        }
    }
}
