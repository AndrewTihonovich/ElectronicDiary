﻿using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RecordController> _logger;

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
            return await _recordCreater.Create(recordCreate);
        }

        [HttpPut]
        public async Task<RecordDtoUI> Put([FromBody] RecordUpdateDtoUI recordUpdate)
        {
            _logger.LogInformation("Start update record");
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
