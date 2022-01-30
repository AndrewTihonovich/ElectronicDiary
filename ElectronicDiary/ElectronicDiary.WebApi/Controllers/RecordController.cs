using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordCreateUI _recordCreater;
        private readonly IRecordDeleteUI _recordDeleter;
        private readonly IRecordGetUI _recordGetter;
        private readonly IRecordUpdateUI _recordUpdater;
        private readonly ILogger<RecordController> _logger;

        private string CurrentUserId => HttpContext.User.FindFirst(c => c.Type == "Email").Value;

        public RecordController(
            IRecordCreateUI recordCreater,
            IRecordDeleteUI recordDeleter,
            IRecordGetUI recordGetter,
            IRecordUpdateUI recordUpdater,
            ILogger<RecordController> logger)
        {
            _recordCreater = recordCreater;
            _recordDeleter = recordDeleter;
            _recordGetter = recordGetter;
            _recordUpdater = recordUpdater;
            _logger = logger;
        }

        [HttpGet]
        public async Task<RecordDtoGetOneUI> GetOneRecord (int Id)
        {
            _logger.LogInformation("Start get record");
            return  await _recordGetter.GetOne(Id);
        }

        [HttpPost]
        public async Task<RecordDtoUI> CreateRecord([FromBody] RecordCreateDtoUI recordCreate)
        {
            _logger.LogInformation("Start create record");
            recordCreate.UserId = CurrentUserId;
            return await _recordCreater.Create(recordCreate);
        }

        [HttpPut]
        public async Task<RecordDtoUI> Put([FromBody] RecordUpdateDtoUI recordUpdate)
        {
            _logger.LogInformation("Start update record");
            recordUpdate.UserId = CurrentUserId;
            return await _recordUpdater.Update(recordUpdate);
        }

        [HttpDelete]
        public async Task<RecordDtoUI> Delete(int Id)
        {
            _logger.LogInformation("Start delete record");
            return await _recordDeleter.Delete(Id);
        }
    }
}
