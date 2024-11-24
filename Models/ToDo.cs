namespace To_Do_Tracker.Models
{
    public class ToDo
    {
        public enum Status
        {
            Completed,
            Pending,
            Canceled
            
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public Status? TaskStatus { get; set; }

        public ToDo()
        {
            
           
                TaskStatus = Status.Pending;
            
        }

    }
}
