using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyEntryArchiving.Entities
{
    public class DailyEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
        public DateTime  Date { get; set; }
        [Required]
        [MinLength(5)]
        public string Description { get; set; }=string.Empty;
        public virtual ICollection<DailyDetailsEntry>?DetailsEntries { get; set; }
    }
}
