using RestaurantManagement.Core.ViewModels;

namespace RestaurantManagement.Services.Tables
{
    public interface ITableService
    {
        IEnumerable<TableViewModel> GetAllTables();

        public IEnumerable<TableViewModel> GetTableOptions();

        TableViewModel GetTableById(int id);

        void CreateTable(TableViewModel model);

        void UpdateTable(TableViewModel model);

        void DeleteTable(int id);
        Task<IEnumerable<TableViewModel>> GetTables();
    }
}