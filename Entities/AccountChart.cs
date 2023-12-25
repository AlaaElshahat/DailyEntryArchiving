using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyEntryArchiving.Entities
{
    public class AccountChart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; } 
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
        public int Number { get; set; }
        public  virtual ICollection<DailyDetailsEntry>? Details { get; set; }
    }
}