using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Constants;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Concrete
{
    public class WarehouseManager : IWarehouseService
    {
        private IWarehouseDao _warehouseDao;
        private ILocationDao _locationDao;
        public WarehouseManager(IWarehouseDao warehouseDao, ILocationDao locationDao)
        {
            _warehouseDao = warehouseDao;
            _locationDao = locationDao;
        }
        public IDataResult<IList<Warehouse>> GetList()
        {
            return new SuccessDataResult<IList<Warehouse>>(_warehouseDao.GetList());
        }

        public async Task<IDataResult<IList<Warehouse>>> GetListAsync()
        {
            var warehouses = await _warehouseDao.GetListAsync();
            return new SuccessDataResult<IList<Warehouse>>(warehouses);
        }

        public IDataResult<Warehouse> GetById(int id)
        {
            return new SuccessDataResult<Warehouse>(_warehouseDao.Get(w => w.Id == id));
        }

        public async Task<IDataResult<Warehouse>> GetByIdAsync(int id)
        {
            var warehouse = await _warehouseDao.GetAsync(w => w.Id == id);
            return new SuccessDataResult<Warehouse>(warehouse);
        }

        public IResult Add(Warehouse warehouse)
        {
            _warehouseDao.Add(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseAdded);
        }

        public async Task<IResult> AddAsync(Warehouse warehouse)
        {
            await _warehouseDao.AddAsync(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseAdded);
        }

        public IResult Update(Warehouse warehouse)
        {
            _warehouseDao.Update(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseUpdated);
        }

        public async Task<IResult> UpdateAsync(Warehouse warehouse)
        {
            await _warehouseDao.UpdateAsync(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseUpdated);
        }

        public IResult Delete(Warehouse warehouse)
        {
            _warehouseDao.Delete(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseDeleted);
        }

        public async Task<IResult> DeleteAsync(Warehouse warehouse)
        {
            await _warehouseDao.DeleteAsync(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseDeleted);
        }

        public IDataResult<WarehouseDetailsDto> GetWarehouseDetailsDtoById(int warehouseId)
        {
            var warehouse = _warehouseDao.Get(p => p.Id == warehouseId);
            var whLocation = _warehouseDao.Get(l => l.Id == warehouse.LocationId);
            var warehouseDetailsDto = new WarehouseDetailsDto
            {
                WarehouseId = warehouse.Id,
                WarehouseName = warehouse.Name,
                WarehouseCode = warehouse.WarehouseCode,
                HasLimitedStockCount = warehouse.HasLimitedStockCount,
                RouteListId = warehouse.RouteListId,
                StockLimit = warehouse.StockLimit,
                UsedForManufacture = warehouse.UsedForManufacture
            };

            if (whLocation != null)
            {
                warehouseDetailsDto.LocationId = whLocation.Id;
                warehouseDetailsDto.LocationName = whLocation.Name;
            }

            return new SuccessDataResult<WarehouseDetailsDto>(warehouseDetailsDto);
        }

        public async Task<IDataResult<WarehouseDetailsDto>> GetWarehouseDetailsDtoByIdAsync(int warehouseId)
        {
            var warehouse = await _warehouseDao.GetAsync(p => p.Id == warehouseId);
            var whLocation = await _locationDao.GetAsync(l => l.Id == warehouse.LocationId);
            var warehouseDetailsDto = new WarehouseDetailsDto
            {
                WarehouseId = warehouse.Id,
                WarehouseName = warehouse.Name,
                WarehouseCode = warehouse.WarehouseCode,
                HasLimitedStockCount = warehouse.HasLimitedStockCount,
                RouteListId = warehouse.RouteListId,
                StockLimit = warehouse.StockLimit,
                UsedForManufacture = warehouse.UsedForManufacture
            };

            if (whLocation != null)
            {
                warehouseDetailsDto.LocationId = whLocation.Id;
                warehouseDetailsDto.LocationName = whLocation.Name;
            }

            return new SuccessDataResult<WarehouseDetailsDto>(warehouseDetailsDto);
        }

        public IDataResult<IList<WarehouseListDto>> GetWarehouseListDto()
        {
            var warehouses = _warehouseDao.GetList();
            IList<WarehouseListDto> warehouseListDtos = new List<WarehouseListDto>();
            foreach (Warehouse w in warehouses)
            {
                var whLocation = _warehouseDao.Get(l => l.Id == w.LocationId);
                var warehouseListDto = new WarehouseListDto
                {
                    WarehouseId = w.Id,
                    WarehouseName = w.Name,
                    WarehouseCode = w.WarehouseCode
                };

                if (whLocation != null)
                {
                    warehouseListDto.LocationId = whLocation.Id;
                    warehouseListDto.LocationName = whLocation.Name;
                }
                warehouseListDtos.Add(warehouseListDto);
            }

            return new SuccessDataResult<IList<WarehouseListDto>>(warehouseListDtos);
        }

        public async Task<IDataResult<IList<WarehouseListDto>>> GetWarehouseListDtoAsync()
        {
            var warehouses = await _warehouseDao.GetListAsync();
            IList<WarehouseListDto> warehouseListDtos = new List<WarehouseListDto>();
            foreach(Warehouse w in warehouses)
            {
                var whLocation = await _warehouseDao.GetAsync(l => l.Id == w.LocationId);
                var warehouseListDto = new WarehouseListDto
                {
                    WarehouseId = w.Id,
                    WarehouseName = w.Name,
                    WarehouseCode = w.WarehouseCode
                };

                if (whLocation != null)
                {
                    warehouseListDto.LocationId = whLocation.Id;
                    warehouseListDto.LocationName = whLocation.Name;
                }
                warehouseListDtos.Add(warehouseListDto);
            }

            return new SuccessDataResult<IList<WarehouseListDto>>(warehouseListDtos);
        }
    }
}
