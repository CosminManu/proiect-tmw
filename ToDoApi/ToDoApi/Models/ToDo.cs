namespace ToDoApi.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? ToDoName { get; set; }   // '?' means the property might be nullable
    }
}
