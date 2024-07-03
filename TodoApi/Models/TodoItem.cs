namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    // clau externa de la TodoList
    //public long TodoListId { get; set; }
    // 
    //public TodoLists TodoList { get; set; }
}