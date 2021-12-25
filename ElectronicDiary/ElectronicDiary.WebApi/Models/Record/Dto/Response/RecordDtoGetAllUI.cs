using System.Collections.Generic;

namespace ElectronicDiary.WebApi.Models.Record.Dto.Response
{
    public class RecordDtoGetAllUI
    {
        public List<RecordDtoGetOneUI> AllRecords { get; set; }
    }
}
