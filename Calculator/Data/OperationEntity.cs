namespace Calculator.Data
{
    public class OperationEntity
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Expression { get; set; } = string.Empty;

        public string Result { get; set; } = string.Empty;
    }
}
