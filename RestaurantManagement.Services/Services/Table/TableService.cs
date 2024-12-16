using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository;
using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Services.TableSer
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TableViewModel> GetAllTables()
        {
            var tables = _unitOfWork.Tables.GetAllAsync().Result;
            var tableViewModelList = new List<TableViewModel>();
            foreach (var table in tables)
            {
                var tableViewMode = new TableViewModel
                {
                    Id = table.TableId,
                    IsOccupied = table.IsOccupied,
                    Number = table.TableNumber,
                    Seats = table.Capacity

                };
                tableViewModelList.Add(tableViewMode);
            }

            return tableViewModelList;
        }

        public TableViewModel GetTableById(int id)
        {
            var table = _unitOfWork.Tables.GetByIdAsync(id).Result;
            var tableViewMode = new TableViewModel
            {
                Id = table.TableId,
                IsOccupied = table.IsOccupied,
                Number = table.TableNumber,
                Seats = table.Reservations.Count(),

            };

            return tableViewMode;
        }

        public void CreateTable(TableViewModel model)
        {
            var table = new Table
            {
                //TableId = model.Id,
                TableNumber = model.Number,
                Capacity = model.Seats,
                IsOccupied = model.IsOccupied,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Hassan",
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Hassan",
                Status = "Avaible"
            };
            _unitOfWork.Tables.AddAsync(table).Wait();
            _unitOfWork.CompleteAsync().Wait();
        }

        public void UpdateTable(TableViewModel model)
        {
            var table = _unitOfWork.Tables.GetByIdAsync(model.Id).Result;
            // تحديث الخصائص حسب الحاجة
            table.Capacity = model.Seats;
            table.IsOccupied = model.IsOccupied;
            _unitOfWork.Tables.UpdateAsync(table);
            _unitOfWork.CompleteAsync().Wait();
        }

        public void DeleteTable(int id)
        {
            var table = _unitOfWork.Tables.GetByIdAsync(id).Result;
            _unitOfWork.Tables.RemoveAsync(table);
            _unitOfWork.CompleteAsync().Wait();
        }


        public IEnumerable<TableViewModel> GetTableOptions()
        {
            var tables = _unitOfWork.Tables.GetAllAsync().Result;
            List<TableViewModel>? TableViewList = new List<TableViewModel>();

            foreach (var table in tables)
            {
                var TableView = new TableViewModel
                {
                    Id = table.TableId,
                    IsOccupied = table.IsOccupied,
                    Number = table.TableNumber,
                    Seats = table.Capacity
                };

                TableViewList.Add(TableView);
            }

            return TableViewList.ToList();


        }

    }
}
