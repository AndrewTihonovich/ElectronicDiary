using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        private string CurrentUserId => HttpContext.User.FindFirst(c => c.Type == "Email")?.Value;

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

        [Route("all")]
        [HttpGet]
        public async Task<List<RecordDtoGetOneUI>> GetAllRecord(string userId)
        {
            _logger.LogInformation("Start getall record");

            return await _recordGetter.GetAll(userId);
        }

        [HttpPost]
        public async Task<RecordDtoUI> CreateRecord([FromBody] RecordCreateDtoUI recordCreate)
        {
            _logger.LogInformation("Start create record");
            if (recordCreate.UserId == CurrentUserId && recordCreate.UserId != null)
            {
                return await _recordCreater.Create(recordCreate);
            }

            throw new Exception("Error current Id user");
        }

        [HttpPut]
        public async Task<RecordDtoUI> Put([FromBody] RecordUpdateDtoUI recordUpdate)
        {
            _logger.LogInformation("Start update record");
            if (recordUpdate.UserId == CurrentUserId)
            {
                await _recordUpdater.Update(recordUpdate);
            }

            throw new Exception("Error current Id user");
        }

        [HttpDelete]
        public async Task<RecordDtoUI> Delete(int Id)
        {
            _logger.LogInformation("Start delete record");
            return await _recordDeleter.Delete(Id);
        }
    }
}
