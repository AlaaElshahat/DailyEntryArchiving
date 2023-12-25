using System.ComponentModel.DataAnnotations;

namespace DailyEntryArchiving.DTOS
{
    public class DailyEntryDto
    {
       
        [Required]
        public DateTime Date { get; set; }= DateTime.Now;
        [Required]
        public string Description { get; set; }=string.Empty;
    }
}
