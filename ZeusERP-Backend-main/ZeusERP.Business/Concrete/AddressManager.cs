using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Constants;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDao _addressDao;
        public AddressManager(IAddressDao addressDao)
        {
            _addressDao = addressDao;
        }
        public IDataResult<Address> GetById(int id)
        {
            return new SuccessDataResult<Address>(_addressDao.Get(a => a.Id == id));
        }

        public async Task<IDataResult<Address>> GetByIdAsync(int id)
        {
            var address = await _addressDao.GetAsync(a => a.Id == id);
            return new SuccessDataResult<Address>(address);
        }

        public IDataResult<IList<Address>> GetList()
        {
            return new SuccessDataResult<IList<Address>>(_addressDao.GetList());
        }

        public async Task<IDataResult<IList<Address>>> GetListAsync()
        {
            var addresses = await _addressDao.GetListAsync();
            return new SuccessDataResult<IList<Address>>(addresses);
        }

        public IResult Add(Address address)
        {
            _addressDao.Add(address);
            return new SuccessResult(true, ResultMessages.AddressAdded);
        }

        public async Task<IResult> AddAsync(Address address)
        {
            await _addressDao.AddAsync(address);
            return new SuccessResult(true, ResultMessages.AddressAdded);
        }

        public IResult Update(Address address)
        {
            _addressDao.Update(address);
            return new SuccessResult(true, ResultMessages.AddressUpdated);
        }

        public async Task<IResult> UpdateAsync(Address address)
        {
            await _addressDao.UpdateAsync(address);
            return new SuccessResult(true, ResultMessages.AddressUpdated);
        }

        public IResult Delete(Address address)
        {
            _addressDao.Delete(address);
            return new SuccessResult(true, ResultMessages.AddressDeleted);
        }

        public async Task<IResult> DeleteAsync(Address address)
        {
            await _addressDao.DeleteAsync(address);
            return new SuccessResult(true, ResultMessages.AddressDeleted);
        }
    }
}
