using Volo.Abp.Domain.Entities;

namespace SimpleTodoApp.Entities;

public class Todo : AggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}