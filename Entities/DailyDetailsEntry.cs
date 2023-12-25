using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace DailyEntryArchiving.Entities
{
    public class DailyDetailsEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Debits { get; set; }
        public double Credits { get; set; }
        public int DailyEntryId { get;set; }
        [ForeignKey("DailyEntryId")]
        public virtual DailyEntry? DailyEntry { get; set; }
        public int AccountChartId { get; set; }
        [ForeignKey("AccountChartId ")]
        public  virtual AccountChart ?AccountChart { get; set; }
    }
}