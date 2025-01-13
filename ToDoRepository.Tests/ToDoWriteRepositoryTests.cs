using System;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Infrastructure;
using Xunit;

public class ToDoWriteRepositoryTests
{
    private readonly IToDoWriteRepository _repository;

    public ToDoWriteRepositoryTests()
    {
        _repository = new ToDoWriteRepository();
    }

    [Fact]
    public async Task AddAsync_ShouldAddToDoItem()
    {
        // Arrange
        var newToDo = new ToDoItem { Title = "Test ToDo", Description = "Test Description" };

        // Act
        var addedToDo = await _repository.AddAsync(newToDo);

        // Assert
        Assert.NotNull(addedToDo);
        Assert.Equal(newToDo.Title, addedToDo.Title);
        Assert.Equal(newToDo.Description, addedToDo.Description);
        Assert.NotEqual(Guid.Empty, addedToDo.Id);
        Assert.NotEqual(DateTime.MinValue, addedToDo.CreatedDate);
    }

    //[Fact]
    //public async Task UpdateAsync_ShouldUpdateToDoItem()
    //{
    //    // Arrange
    //    var existingToDo = new ToDoItem { Id = Guid.NewGuid(), Title = "Test ToDo", Description = "Test Description" };
    //    await _repository.AddAsync(existingToDo);
    //    existingToDo.Title = "Updated ToDo";

    //    // Act
    //    await _repository.UpdateAsync(existingToDo);

    //    // Assert
    //    var updatedToDo = MockToDoItemsData.Instance.GetToDoItems.Find(t => t.Id == existingToDo.Id);
    //    Assert.NotNull(updatedToDo);
    //    Assert.Equal("Updated ToDo", updatedToDo.Title);
    //}

    //[Fact]
    //public async Task DeleteAsync_ShouldRemoveToDoItem()
    //{
    //    // Arrange
    //    var toDoToDelete = new ToDoItem { Id = Guid.NewGuid(), Title = "Test ToDo", Description = "Test Description" };
    //    await _repository.AddAsync(toDoToDelete);

    //    // Act
    //    await _repository.DeleteAsync(toDoToDelete.Id);

    //    // Assert
    //    var deletedToDo = MockToDoItemsData.Instance.GetToDoItems.Find(t => t.Id == toDoToDelete.Id);
    //    Assert.Null(deletedToDo);
    //}

    [Fact]
    public async Task UpdateStatusAsync_ShouldUpdateToDoStatus()
    {
        // Arrange
        var toDo = new ToDoItem { Id = Guid.NewGuid(), Title = "Test ToDo", Description = "Test Description" };
        await _repository.AddAsync(toDo);

        // Act
        await _repository.UpdateStatusAsync(toDo.Id, true);

        // Assert
        var updatedToDo = MockToDoItemsData.Instance.GetToDoItems.Find(t => t.Id == toDo.Id);
        Assert.NotNull(updatedToDo);
        Assert.True(updatedToDo.IsCompleted);
        Assert.NotNull(updatedToDo.CompletedDate);
    }
}
