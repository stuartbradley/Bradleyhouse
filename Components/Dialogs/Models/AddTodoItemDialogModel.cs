namespace BradleyHouse.Components.Dialogs.Models
{
    public class AddTodoItemDialogModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int EstimatedTimeToComplete { get; set; }
    }
}
