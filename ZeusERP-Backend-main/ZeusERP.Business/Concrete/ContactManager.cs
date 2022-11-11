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
    public class ContactManager : IContactService
    {
        private IContactDao _contactDao;
        public ContactManager(IContactDao contactDao)
        {
            _contactDao = contactDao;
        }
        public IDataResult<IList<Contact>> GetList()
        {
            return new SuccessDataResult<IList<Contact>>(_contactDao.GetList());
        }

        public async Task<IDataResult<IList<Contact>>> GetListAsync()
        {
            var contacts = await _contactDao.GetListAsync();
            return new SuccessDataResult<IList<Contact>>(contacts);
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new SuccessDataResult<Contact>(_contactDao.Get(c => c.Id == id));
        }

        public async Task<IDataResult<Contact>> GetByIdAsync(int id)
        {
            var contact = await _contactDao.GetAsync(c => c.Id == id);
            return new SuccessDataResult<Contact>(contact);
        }

        public IResult Add(Contact contact)
        {
            _contactDao.Add(contact);
            return new SuccessResult(true, ResultMessages.ContactAdded);
        }

        public async Task<IResult> AddAsync(Contact contact)
        {
            await _contactDao.AddAsync(contact);
            return new SuccessResult(true, ResultMessages.ContactAdded);
        }

        public IResult Update(Contact contact)
        {
            _contactDao.Update(contact);
            return new SuccessResult(true, ResultMessages.ContactUpdated);
        }

        public async Task<IResult> UpdateAsync(Contact contact)
        {
            await _contactDao.UpdateAsync(contact);
            return new SuccessResult(true, ResultMessages.ContactUpdated);
        }

        public IResult Delete(Contact contact)
        {
            _contactDao.Delete(contact);
            return new SuccessResult(true, ResultMessages.ContactDeleted);
        }

        public async Task<IResult> DeleteAsync(Contact contact)
        {
            await _contactDao.DeleteAsync(contact);
            return new SuccessResult(true, ResultMessages.ContactDeleted);
        }

        public IDataResult<ContactDetailsDto> GetContactDetailsDtoById(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ContactDetailsDto>> GetContactDetailsDtoByIdAsync(int contactId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<ContactListDto>> GetContactListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<ContactListDto>>> GetContactListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
