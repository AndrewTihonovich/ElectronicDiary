using ElectronicDiary.BLL.Models;
using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;

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
                Id=update.Id
            };
        }

        public static RecordDtoGetOneUI MapOne(RecordDto oneRecordDto)
        {
            return new RecordDtoGetOneUI
            {
                Id = oneRecordDto.Id,
                Text = oneRecordDto.Text,
                Theme=oneRecordDto.Theme
            };
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
