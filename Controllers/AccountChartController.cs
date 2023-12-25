using AutoMapper;
using DailyEntryArchiving.DTOS;
using DailyEntryArchiving.Entities;
using DailyEntryArchiving.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyEntryArchiving.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountChartController : ControllerBase
    {
        IAccountChartRepo _repo;
        IMapper _mapper;
        public AccountChartController(IAccountChartRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAccountsChart() 
        {
            List<AccountChart> accountCharts = (List<AccountChart>)_repo.GetAll();
            if(accountCharts.Count == 0) 
                return NotFound();
            List<AccountChartDto>accountChartDtos=(List<AccountChartDto>)_mapper.Map<IReadOnlyList<AccountChartDto>>(accountCharts);
            return Ok(accountChartDtos);
           
            
        }
        [HttpGet("{id}")]
        public IActionResult GetAccountsChartById(int id) 
        {
            AccountChart accountChart= _repo.GetById(id);
            if(accountChart==null)
                return NotFound();
            return Ok(_mapper.Map<AccountChartDto>(accountChart));
        }
    }
}
