using InertiaCore;
using Microsoft.AspNetCore.Mvc;
using SimpleTodoApp.Entities;
using SimpleTodoApp.Services;
using SimpleTodoApp.Services.Dtos;

namespace SimpleTodoApp.controllers;

public class HomeController(ItemService todoItem, ILogger<HomeController> logger) : Controller
{
    public async Task<IActionResult> Index()
    {
        var todos = await todoItem.GetTodoItems();
        return  Inertia.Render("Index",new { name = "John Doe", todos });
    }
    
    [HttpPost("/create"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] CreateTodo todo)
    {
      
        await todoItem.CreateTodoItem(new Todo
        {
            Title = todo.Title,
            Description = todo.Description,
        });
      
        return RedirectToAction("Index");
    }
    
    [HttpPost("/update/{id}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(string id, [FromForm] UpdateTodo todo)
    {
       var existingTodo = await todoItem.GetTodoItem(Guid.Parse(id));
            existingTodo.IsCompleted = todo.IsCompleted;
       await todoItem.UpdateTodoItem(existingTodo);
        return RedirectToAction("Index");
    }
    
    [HttpPost("/delete/{id}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(string id)
    {
        await todoItem.DeleteTodoItem(Guid.Parse(id));
        return RedirectToAction("Index");
    }
}   