﻿using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Interfaces
{
    public interface IRecordGetUI
    {
        Task<RecordDtoGetOneUI> GetOne (int Id);
    }
}
