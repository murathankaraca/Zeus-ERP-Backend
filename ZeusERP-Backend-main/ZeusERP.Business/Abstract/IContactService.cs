using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IContactService
    {
        IDataResult<IList<Contact>> GetList();
        Task<IDataResult<IList<Contact>>> GetListAsync();
        IDataResult<Contact> GetById(int id);
        Task<IDataResult<Contact>> GetByIdAsync(int id);
        IResult Add(Contact contact);
        Task<IResult> AddAsync(Contact contact);
        IResult Update(Contact contact);
        Task<IResult> UpdateAsync(Contact contact);
        IResult Delete(Contact contact);
        Task<IResult> DeleteAsync(Contact contact);


        // DTOS

        IDataResult<ContactDetailsDto> GetContactDetailsDtoById(int contactId);
        Task<IDataResult<ContactDetailsDto>> GetContactDetailsDtoByIdAsync(int contactId);
        IDataResult<IList<ContactListDto>> GetContactListDto();
        Task<IDataResult<IList<ContactListDto>>> GetContactListDtoAsync();
    }
}
