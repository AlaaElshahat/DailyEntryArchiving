using AutoMapper;
using DailyEntryArchiving.DTOS;
using DailyEntryArchiving.Entities;

namespace DailyEntryArchiving.Helper
{
    public class AccountChartMappingProfile:Profile
    {
        public AccountChartMappingProfile()
        {
            CreateMap<AccountChart,AccountChartDto>()
            .ReverseMap();
        }
    }
}
