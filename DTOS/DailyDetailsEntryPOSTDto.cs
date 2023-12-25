namespace DailyEntryArchiving.DTOS
{
    public class DailyDetailsEntryPOSTDto
    {
        public double Debits { get; set; }
        public double Credits { get; set; }
        public int AccountId { get; set; }
        public int DailyEntryId { get; set; }
    }
}
