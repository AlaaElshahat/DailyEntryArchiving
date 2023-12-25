using AutoMapper;
using DailyEntryArchiving.DTOS;
using DailyEntryArchiving.Entities;
using DailyEntryArchiving.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DailyEntryArchiving.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyEntryController : ControllerBase
    {
        IDailyEntryRepo _repo;
        IMapper _mapper;
        public DailyEntryController(IDailyEntryRepo repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllDailyEntries()
        {
            List<DailyEntry> dailyEntries = (List<DailyEntry>)_repo.GetAll();
            if (dailyEntries.Count == 0)
                return NotFound();
            List< DailyEntryDto> dailyEntryDtos = (List<DailyEntryDto>)_mapper.Map<List<DailyEntryDto>>(dailyEntries);
            return Ok(dailyEntryDtos);

        }
        [HttpPost]
        public IActionResult AddDailyEntry(DailyEntryDto dailyEntry)
        {
            if (dailyEntry == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            DailyEntry postedDailyEntry = _mapper.Map<DailyEntry>(dailyEntry);
            int postedSuccessfully = _repo.Add(postedDailyEntry);
            return Ok(postedSuccessfully);


        }
        [HttpPatch("{id}")]
        public IActionResult UpdateDailyEntry(int id,DailyEntryDto dailyEntry)
        {
            if(dailyEntry==null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            DailyEntry dailyEntryFound = _repo.GetById(id);
            if (dailyEntryFound == null)
                return NotFound();
            DailyEntry UpdatedEntry = _mapper.Map<DailyEntry>(dailyEntry);
            UpdatedEntry.Id = id;
             int updatedSuccessfully=_repo.Update(id,UpdatedEntry);
            return Ok(updatedSuccessfully);
        }
        [HttpDelete]
        public IActionResult DeleteDailyEntry(int id)
        {
            DailyEntry dailyEntryFound = _repo.GetById(id);
            if (dailyEntryFound == null)
                return NotFound();
            int deletedSuccessfully=_repo.Delete(id);
            return Ok(deletedSuccessfully);
        }
        [HttpGet("{id}")]
        public IActionResult GetDailyEntryById(int id)
        {
            DailyEntry dailyEntryFound = _repo.GetById(id);
            if (dailyEntryFound == null)
                return NotFound();
            return Ok(_mapper.Map<DailyEntryDto>(dailyEntryFound));
        }

    }
}
