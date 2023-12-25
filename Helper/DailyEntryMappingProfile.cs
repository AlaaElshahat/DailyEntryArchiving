using AutoMapper;
using DailyEntryArchiving.DTOS;
using DailyEntryArchiving.Entities;

namespace DailyEntryArchiving.Helper
{
    public class DailyEntryMappingProfile:Profile
    {
        public DailyEntryMappingProfile()
        {
            CreateMap<DailyEntry, DailyEntryDto>()
            .ReverseMap();   
        }
    }
}
