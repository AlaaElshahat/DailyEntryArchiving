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
    public class DailyDetailsEntryController : ControllerBase
    {
        IDailyDetailsEntryRepo _repo;
        IMapper _mapper;
        public DailyDetailsEntryController(IDailyDetailsEntryRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllDailyDetails() {
            List<DailyDetailsEntry> dailyDetailsEntriesList = (List<DailyDetailsEntry>)_repo.GetAll();
            if (dailyDetailsEntriesList.Count == 0)
                return NotFound();
            List<DailyDetailsEntryDto> dailyDetailsEntryDtos =
            (List<DailyDetailsEntryDto>)_mapper.Map<IReadOnlyList<DailyDetailsEntry>, IReadOnlyList<DailyDetailsEntryDto>>(dailyDetailsEntriesList);
          
            return Ok(dailyDetailsEntryDtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetDailyDetailsByID(int id)
        {
            DailyDetailsEntry dailyDetailsEntryFound = _repo.GetById(id);
            if (dailyDetailsEntryFound == null)
                return NotFound();
            return Ok(_mapper.Map<DailyDetailsEntryDto>(dailyDetailsEntryFound));
        }
        [HttpDelete]
        public IActionResult DeleteDailyDetails(int id)
        {
            DailyDetailsEntry dailyDetailsEntryFound = _repo.GetById(id);
            if (dailyDetailsEntryFound == null)
                return NotFound();
            int deletedSuccessfully = _repo.Delete(id);
            return Ok(deletedSuccessfully);

        }
        [HttpPost]
        public IActionResult AddDetailedEntry(DailyDetailsEntryPOSTDto dailyDetailsEntry)
        {
            if (dailyDetailsEntry == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest();
            int postedSuccessfully= _repo.Add(_mapper.Map<DailyDetailsEntry>(dailyDetailsEntry));
            return Ok(postedSuccessfully);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateEntryDetails(int id, DailyDetailsEntryPOSTDto dailyDetailsEntry)
        {
            DailyDetailsEntry dailyDetailsEntryFound = _repo.GetById(id);
            if (dailyDetailsEntryFound == null)
                return NotFound();
            if (dailyDetailsEntry == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            DailyDetailsEntry updatedDailyDetailed = _mapper.Map<DailyDetailsEntry>(dailyDetailsEntry);
            updatedDailyDetailed.Id = id;
            int updatedSuccessfully= _repo.Update(id,updatedDailyDetailed);
            return Ok(updatedSuccessfully);


        }
        //public IActionResult GetDetailsEnteriesBYEntrYId()
        //{

        //}
    }
}
