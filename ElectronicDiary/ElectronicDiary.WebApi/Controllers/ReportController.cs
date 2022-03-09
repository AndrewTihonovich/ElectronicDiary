﻿using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using ElectronicDiary.WebApi.Models.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IRecordGetUI _recordGetter;
        private string CurrentUserRole => HttpContext.User.FindFirst(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        private string CurrentUserId => HttpContext.User.FindFirst(c => c.Type == "Email")?.Value;

        public ReportController(IRecordGetUI recordGetter)
        {
            _recordGetter = recordGetter;
        }

        [HttpGet]
        public async Task<List<RecordDtoGetOneUI>> GetAllRecordAsync([FromQuery] ReportReq data, string userId)
        {
            string id;
            if (CurrentUserRole=="Admin")
            {
                id = userId;
            }
            else 
            { id = CurrentUserId; }

            var rec = await _recordGetter.GetAll(id);
            var result = rec
                .Where(x => x.WasCreated <= data.EndData.AddHours(23).AddMinutes(59).AddSeconds(59))
                .Where(x => x.WasCreated >= data.StartData)
                .ToList();
            return result;
        }
    }
}
