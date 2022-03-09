using ElectronicDiary.BLL.Models;
using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using System.Collections.Generic;

namespace ElectronicDiary.WebApi.Models.Record.Mapper
{
    public class RecordMapperUI
    {
        public static RecordDtoRequest MapCreate(RecordCreateDtoUI create)
        {
            return new RecordDtoRequest
            {
                Theme = create.Theme,
                Text = create.Text,
                UserId = create.UserId
            };
        }

        public static RecordDtoRequest MapGetAll(string userId)
        {
            return new RecordDtoRequest
            {
                UserId = userId
            };
        }

        public static RecordDtoRequest MapGetOne(int Id)
        {
            return new RecordDtoRequest
            {
                Id = Id
            };
        }

        public static RecordDtoRequest MapDelete(int Id)
        {
            return new RecordDtoRequest
            {
                Id = Id
            };
        }

        public static RecordDtoRequest MapUpdate(RecordUpdateDtoUI update)
        {
            return new RecordDtoRequest
            {
                Theme = update.Theme,
                Text = update.Text,
                Id=update.Id,
                UserId=update.UserId
            };
        }

        public static RecordDtoGetOneUI MapOne(RecordDto oneRecordDto)
        {
            return new RecordDtoGetOneUI
            {
                Id = oneRecordDto.Id,
                Text = oneRecordDto.Text,
                Theme=oneRecordDto.Theme,
                WasCreated= oneRecordDto.WasCreated
    };
        }

        public static List<RecordDtoGetOneUI> MapList(List<RecordDto> listRecordDto)
        {
            var result = new List<RecordDtoGetOneUI>();
            foreach (var item in listRecordDto)
            {
                result.Add(new RecordDtoGetOneUI
                {
                    Id = item.Id,
                    Text = item.Text,
                    Theme = item.Theme,
                    WasCreated = item.WasCreated,
                });
            }

            return result;
        }

        public static RecordDtoUI Map(RecordDto recordDto)
        {
            return new RecordDtoUI
            {
                Id = recordDto.Id
            };
        }
    }
}
