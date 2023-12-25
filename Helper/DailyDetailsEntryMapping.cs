using AutoMapper;
using DailyEntryArchiving.DTOS;
using DailyEntryArchiving.Entities;

namespace DailyEntryArchiving.Helper
{
    public class DailyDetailsEntryMapping:Profile
    {
        public DailyDetailsEntryMapping()
        {
            CreateMap<DailyDetailsEntry, DailyDetailsEntryDto>()
           .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.AccountChart.ArabicName))
           .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountChart.Number)).ReverseMap();

            CreateMap<DailyDetailsEntry,DailyDetailsEntryPOSTDto>()
            .ForMember(dest=>dest.AccountId,opt=>opt.MapFrom(src=>src.AccountChartId)).ReverseMap();
        }

    
    }
}
