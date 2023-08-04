namespace TaskManager.Models;
public record TaskItem(Guid Id, string Name, string Description, DateTime CreationDate, DateTime DueDate);