namespace DailyEntryArchiving.DTOS
{
    public class DailyDetailsEntryDto
    {
       
        public double Debits { get; set; }
        public double Credits { get; set; }
        public string AccountName { get; set; }=string.Empty;
        public int AccountNumber { get; set; }
    }
}
