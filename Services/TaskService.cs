using TaskManager.Models;

namespace TaskManager.Services;
public class TaskService
{
    public List<TaskItem> FindTasks()
    {
        var taskList = new List<TaskItem>()
        {
            new TaskItem(
                Id: Guid.NewGuid(),
                Name: "Study ASP.NET Core",
                Description: "Study ASP.NET Core for 2 hours a day",
                CreationDate: DateTime.Now,
                DueDate: DateTime.Now + TimeSpan.FromDays(7)
            ),
            new TaskItem(
                Id: Guid.NewGuid(),
                Name: "Study ASP.NET Core",
                Description: "Clean the room at 4 pm",
                CreationDate: DateTime.Now,
                DueDate: DateTime.Now + TimeSpan.FromDays(7)
            ),
            new TaskItem(
                Id: Guid.NewGuid(),
                Name: "Submit Monthly Report",
                Description: "Submit the monthly sales report by the end of the week",
                CreationDate: DateTime.Now,
                DueDate: DateTime.Now + TimeSpan.FromDays(5)
            ),
            new TaskItem(
                Id: Guid.NewGuid(),
                Name: "Prepare Presentation",
                Description: "Prepare a presentation for the upcoming client meeting",
                CreationDate: DateTime.Now,
                DueDate: DateTime.Now + TimeSpan.FromDays(3)
            ),
            new TaskItem(
                Id: Guid.NewGuid(),
                Name: "Buy Groceries",
                Description: "Buy groceries for the week",
                CreationDate: DateTime.Now,
                    DueDate: DateTime.Now + TimeSpan.FromDays(2)
                    )
                };
        return taskList;
    }

    public TaskItem FindTaskByName(string name)
    {
        try
        {
            var taskList = FindTasks();
            var task = taskList.SingleOrDefault(t => t.Name == name);
            return task;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
