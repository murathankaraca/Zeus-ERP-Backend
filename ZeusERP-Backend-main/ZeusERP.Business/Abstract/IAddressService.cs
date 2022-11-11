using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<Address> GetById(int id);
        Task<IDataResult<Address>> GetByIdAsync(int id);
        IDataResult<IList<Address>> GetList();
        Task<IDataResult<IList<Address>>> GetListAsync();
        IResult Add(Address address);
        Task<IResult> AddAsync(Address address);
        IResult Update(Address address);
        Task<IResult> UpdateAsync(Address address);
        IResult Delete(Address address);
        Task<IResult> DeleteAsync(Address address);
    }
}
