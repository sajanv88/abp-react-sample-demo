using SimpleTodoApp.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SimpleTodoApp.Services;

public class ItemService(IRepository<Todo, Guid> todos, ILogger<ItemService> logger) : ApplicationService
{
    public async Task<List<Todo>> GetTodoItems()
    {
        return await todos.GetListAsync();
    }
    
    public async Task<Todo> GetTodoItem(Guid id)
    {
        return await todos.GetAsync(id);
    }
    
    public async Task<Todo> CreateTodoItem(Todo todo)
    {
        return await todos.InsertAsync(todo);
    }
    
    public async Task<Todo> UpdateTodoItem(Todo todo)
    {
        return await todos.UpdateAsync(todo);
    }
    
    public async Task DeleteTodoItem(Guid id)
    {
        await todos.DeleteAsync(id);
    }
}