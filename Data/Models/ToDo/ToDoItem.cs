namespace BradleyHouse.Data.Models.ToDo
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CompletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int EstimatedTimeToComplete { get; set; }
        
    }
}
