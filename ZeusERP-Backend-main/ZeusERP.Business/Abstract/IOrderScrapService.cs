using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IOrderScrapService
    {
        IDataResult<IList<Scrap>> GetList();
        Task<IDataResult<IList<Scrap>>> GetListAsync();
        IDataResult<Scrap> GetById(int id);
        Task<IDataResult<Scrap>> GetByIdAsync(int id);

        IResult Add(Scrap scrap);
        Task<IResult> AddAsync(Scrap scrap);

        IResult Update(Scrap scrap);
        Task<IResult> UpdateAsync(Scrap scrap);

        IResult Delete(Scrap scrap);
        Task<IResult> DeleteAsync(Scrap scrap);


        // DTOS

        IDataResult<ScrapDetailsDto> GetScrapDetailsDtoById(int scrapId);
        Task<IDataResult<ScrapDetailsDto>> GetScrapDetailsDtoByIdAsync(int scrapId);
        IDataResult<IList<ScrapListDto>> GetScrapListDto();
        Task<IDataResult<IList<ScrapListDto>>> GetScrapListDtoAsync();
    }
}
