using Laboration;

namespace Laboration.Tests;

public class TaskServiceTests
{
    [Fact]
    public void GetAll_ReturnThreeTasks()
    {
        var service = new TaskService();

        var tasks = service.GetAll();

        Assert.Equal(3, tasks.Count);
    }

    [Fact]
    public void GetById_ReturnCorrectTask()
    {
        var service = new TaskService();

        var task = service.GetById(1);

        Assert.NotNull(task);
        Assert.Equal("Read the assignment", task.Title);
    }

    [Fact]
    public void GetById_ReturnNullWhenNotFound()
    {
        var service = new TaskService();

        var task = service.GetById(99);

        Assert.Null(task);
    }

    [Fact]
    public void Create_ReturnNewTask()
    {
        var service = new TaskService();

        var task = service.Create("städa garaget");

        Assert.Equal(4, task.Id);
        Assert.Equal("städa garaget", task.Title);
        Assert.False(task.IsCompleted);
    }

    [Fact]
    public void Create_AddsTaskToList()
    {
        var service = new TaskService();

        service.Create("köpa mjölk");

        Assert.Equal(4, service.GetAll().Count);
    }

    [Fact]
    public void Create_ThrowsWhenTitleIsNull()
    {
        var service = new TaskService();

        Assert.Throws<ArgumentException>(() => service.Create(null));
    }

    [Fact]
    public void Create_ThrowsWhenTitleIsEmpty()
    {
        var service = new TaskService();

        Assert.Throws<ArgumentException>(() => service.Create(""));
    }

    [Fact]
    public void Create_ThrowsWhenTitleIsWhitespace()
    {

        var service = new TaskService();

        Assert.Throws<ArgumentException>(() => service.Create(" "));
    }

    [Fact]
    public void Complete_MarkTaskAsCompleted()
    {
        var service = new TaskService();

        var result = service.Complete(1);

        Assert.True(result);

        var task = service.GetById(1);
        Assert.NotNull(task);
        Assert.True(task.IsCompleted);
    }

    [Fact]
    public void Complete_ReturnFalseWhenNotFound()
    {
        var service = new TaskService();

        var result = service.Complete(99);

        Assert.False(result);
    }
}