using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicDiary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordCreateUI _recordCreater;
        private readonly IRecordDeleteUI _recordDeleter;
        private readonly IRecordGetUI _recordGetter;
        private readonly IRecordUpdateUI _recordUpdater;

        public RecordController(
            IRecordCreateUI recordCreater,
            IRecordDeleteUI recordDeleter,
            IRecordGetUI recordGetter,
            IRecordUpdateUI recordUpdater)
        {
            _recordCreater = recordCreater;
            _recordDeleter = recordDeleter;
            _recordGetter = recordGetter;
            _recordUpdater = recordUpdater;
        }

        [HttpGet]
        public async Task<RecordDtoGetOneUI> GetOneRecord (int Id)
        {
            return  await _recordGetter.GetOne(Id);
        }

        [HttpPost]
        public async Task<RecordDtoUI> CreateRecord([FromBody] RecordCreateDtoUI recordCreate)
        {
            return await _recordCreater.Create(recordCreate);
        }

        [HttpPut]
        public async Task<RecordDtoUI> Put([FromBody] RecordUpdateDtoUI recordUpdate)
        {
            return await _recordUpdater.Update(recordUpdate);
        }

        [HttpDelete]
        public async Task<RecordDtoUI> Delete(int Id)
        {
            return await _recordDeleter.Delete(Id);
        }
    }
}
