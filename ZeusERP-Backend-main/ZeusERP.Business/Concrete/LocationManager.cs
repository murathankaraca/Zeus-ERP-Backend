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
    public class LocationManager : ILocationService
    {
        private ILocationDao _locationDao;
        private IAddressDao _addressDao;
        public LocationManager(ILocationDao locationDao, IAddressDao addressDao)
        {
            _locationDao = locationDao;
            _addressDao = addressDao;
        }
        public IDataResult<IList<Location>> GetList()
        {
            return new SuccessDataResult<IList<Location>>(_locationDao.GetList());
        }
        public async Task<IDataResult<IList<Location>>> GetListAsync()
        {
            var locations = await _locationDao.GetListAsync();
            return new SuccessDataResult<IList<Location>>(locations);
        }

        public IDataResult<Location> GetById(int id)
        {
            return new SuccessDataResult<Location>(_locationDao.Get(l => l.Id == id));
        }

        public async Task<IDataResult<Location>> GetByIdAsync(int id)
        {
            var location = await _locationDao.GetAsync(l => l.Id == id);
            return new SuccessDataResult<Location>(location);
        }

        public IResult Add(Location location)
        {
            _locationDao.Add(location);
            return new SuccessResult(true, ResultMessages.LocationAdded);
        }

        public async Task<IResult> AddAsync(Location location)
        {
            await _locationDao.AddAsync(location);
            return new SuccessResult(true, ResultMessages.LocationAdded);
        }

        public IResult Update(Location location)
        {
            _locationDao.Update(location);
            return new SuccessResult(true, ResultMessages.LocationUpdated);
        }

        public async Task<IResult> UpdateAsync(Location location)
        {
            await _locationDao.UpdateAsync(location);
            return new SuccessResult(true, ResultMessages.LocationUpdated);
        }

        public IResult Delete(Location location)
        {
            _locationDao.Delete(location);
            return new SuccessResult(true, ResultMessages.LocationDeleted);
        }

        public async Task<IResult> DeleteAsync(Location location)
        {
            await _locationDao.DeleteAsync(location);
            return new SuccessResult(true, ResultMessages.LocationDeleted);
        }

        public IDataResult<LocationDetailsDto> GetLocationDetailsDtoById(int locationId)
        {
            var location = _locationDao.Get(l => l.Id == locationId);
            var locAddress = _addressDao.Get(a => a.Id == location.AddressId);

            var locationDetailsDto = new LocationDetailsDto
            {
                LocationId = location.Id,
                LocationCode = location.Code,
                LocationName = location.Name,
                LocationTypeId = location.LocationTypeId,
                LocationTypeName = location.LocationTypeId.ToString(),
                IsInternalLocation = location.IsInternalLocation,
                IsReturnLocation = location.IsReturnLocation,
                IsScrapLocation = location.IsScrapLocation,
                AddressId = locAddress.Id,
                AddressTitle = locAddress.Title
            };

            return new SuccessDataResult<LocationDetailsDto>(locationDetailsDto);
        }

        public async Task<IDataResult<LocationDetailsDto>> GetLocationDetailsDtoByIdAsync(int locationId)
        {
            var location = await _locationDao.GetAsync(l => l.Id == locationId);
            var locAddress = await _addressDao.GetAsync(a => a.Id == location.AddressId);

            var locationDetailsDto = new LocationDetailsDto
            {
                LocationId = location.Id,
                LocationCode = location.Code,
                LocationName = location.Name,
                LocationTypeId = location.LocationTypeId,
                LocationTypeName = location.LocationTypeId.ToString(),
                IsInternalLocation = location.IsInternalLocation,
                IsReturnLocation = location.IsReturnLocation,
                IsScrapLocation = location.IsScrapLocation,
                AddressId = locAddress.Id,
                AddressTitle = locAddress.Title
            };

            return new SuccessDataResult<LocationDetailsDto>(locationDetailsDto);
        }

        public IDataResult<IList<LocationListDto>> GetLocationListDto()
        {
            var locations = _locationDao.GetList();
            IList<LocationListDto> locationListDtos = new List<LocationListDto>();

            foreach (Location location in locations)
            {
                //var locAddress = _addressDao.Get(a => a.Id == location.AddressId);
                var locationListDto = new LocationListDto
                {
                    LocationId = location.Id,
                    LocationCode = location.Code,
                    LocationName = location.Name,
                };
                locationListDtos.Add(locationListDto);
            }

            return new SuccessDataResult<IList<LocationListDto>>(locationListDtos);
        }

        public async Task<IDataResult<IList<LocationListDto>>> GetLocationListDtoAsync()
        {
            var locations = await _locationDao.GetListAsync();
            IList<LocationListDto> locationListDtos = new List<LocationListDto>();

            foreach (Location location in locations)
            {
                //var locAddress = await _addressDao.GetAsync(a => a.Id == location.AddressId);
                var locationListDto = new LocationListDto
                {
                    LocationId = location.Id,
                    LocationCode = location.Code,
                    LocationName = location.Name,
                };
                locationListDtos.Add(locationListDto);
            }

            return new SuccessDataResult<IList<LocationListDto>>(locationListDtos);
        }
    }
}
