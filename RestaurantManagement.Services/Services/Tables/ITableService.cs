using RestaurantManagement.Core.ViewModels;

namespace RestaurantManagement.Services.Tables
{
    public interface ITableService
    {
        IEnumerable<TableViewModel> GetAllTables();


        TableViewModel GetTableById(int id);

        void CreateTable(TableViewModel model);

        void UpdateTable(TableViewModel model);

        void DeleteTable(int id);

    }
}