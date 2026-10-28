using TaskManagement.Domain.Entities;
using TaskStatus = TaskManagement.Domain.Enums.TaskStatus;
using TaskPriority = TaskManagement.Domain.Enums.TaskPriority;

namespace TaskManagement.UnitTests;

public class TaskItemTests
{
    [Fact]
    public void TaskStatus_ContainsOnlySupportedStatuses()
    {
        Assert.Equal(
            new[] { TaskStatus.ToDo, TaskStatus.InProgress, TaskStatus.Completed },
            Enum.GetValues<TaskStatus>());
    }

    [Fact]
    public void TaskPriority_ContainsOnlySupportedPriorities()
    {
        Assert.Equal(
            new[] { TaskPriority.Low, TaskPriority.Medium, TaskPriority.High },
            Enum.GetValues<TaskPriority>());
    }

    [Fact]
    public void Create_SetsDefaultValuesAndUtcTimestamps()
    {
        var fixedNow = new DateTimeOffset(2025, 10, 28, 9, 30, 0, TimeSpan.Zero);
        var timeProvider = new ManualTimeProvider(fixedNow);

        var task = TaskItem.Create("   Finish sprint review   ", "   Prepare notes   ", null, timeProvider);

        Assert.NotEqual(Guid.Empty, task.Id);
        Assert.Equal("Finish sprint review", task.Title);
        Assert.Equal("Prepare notes", task.Description);
        Assert.Equal(TaskStatus.ToDo, task.Status);
        Assert.Equal(TaskPriority.Medium, task.Priority);
        Assert.Null(task.DueDate);
        Assert.Equal(fixedNow, task.CreatedAtUtc);
        Assert.Equal(fixedNow, task.UpdatedAtUtc);
    }

    [Fact]
    public void ChangeTitle_WhenTitleChanges_UpdatesUpdatedAtUtc()
    {
        var fixedNow = new DateTimeOffset(2025, 10, 28, 9, 30, 0, TimeSpan.Zero);
        var timeProvider = new ManualTimeProvider(fixedNow);
        var task = TaskItem.Create("Original title", timeProvider: timeProvider);

        timeProvider.Advance(TimeSpan.FromMinutes(15));
        task.ChangeTitle("  Updated title  ");

        Assert.Equal("Updated title", task.Title);
        Assert.Equal(fixedNow.AddMinutes(15), task.UpdatedAtUtc);
    }

    [Fact]
    public void ChangeTitle_WhenTitleIsUnchanged_DoesNotUpdateTimestamp()
    {
        var fixedNow = new DateTimeOffset(2025, 10, 28, 9, 30, 0, TimeSpan.Zero);
        var timeProvider = new ManualTimeProvider(fixedNow);
        var task = TaskItem.Create("Original title", timeProvider: timeProvider);

        task.ChangeTitle("Original title");

        Assert.Equal(fixedNow, task.UpdatedAtUtc);
    }

    [Fact]
    public void ChangeDescription_WhenDescriptionExceedsMaxLength_Throws()
    {
        var task = TaskItem.Create("Task title");
        var description = new string('x', 2001);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => task.ChangeDescription(description));
        Assert.Equal("description", exception.ParamName);
    }

    [Fact]
    public void Create_WithEmptyTitle_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => TaskItem.Create("   "));
        Assert.Equal("title", exception.ParamName);
    }

    [Fact]
    public void ChangePriority_AndStatus_AllowValidUpdates()
    {
        var fixedNow = new DateTimeOffset(2025, 10, 28, 9, 30, 0, TimeSpan.Zero);
        var timeProvider = new ManualTimeProvider(fixedNow);
        var task = TaskItem.Create("Task title", timeProvider: timeProvider);

        timeProvider.Advance(TimeSpan.FromMinutes(5));
        task.ChangeStatus(TaskStatus.InProgress);
        timeProvider.Advance(TimeSpan.FromMinutes(5));
        task.ChangePriority(TaskPriority.High);

        Assert.Equal(TaskStatus.InProgress, task.Status);
        Assert.Equal(TaskPriority.High, task.Priority);
        Assert.Equal(fixedNow.AddMinutes(10), task.UpdatedAtUtc);
    }

    [Theory]
    [InlineData((TaskStatus)0)]
    [InlineData((TaskStatus)99)]
    public void ChangeStatus_WithUndefinedValue_Throws(TaskStatus status)
    {
        var task = TaskItem.Create("Task title");

        Assert.Throws<ArgumentOutOfRangeException>(() => task.ChangeStatus(status));
    }

    [Theory]
    [InlineData((TaskPriority)0)]
    [InlineData((TaskPriority)99)]
    public void ChangePriority_WithUndefinedValue_Throws(TaskPriority priority)
    {
        var task = TaskItem.Create("Task title");

        Assert.Throws<ArgumentOutOfRangeException>(() => task.ChangePriority(priority));
    }

    [Fact]
    public void ChangeDueDate_WhenSetToNull_UpdatesTimestampAndClearsValue()
    {
        var fixedNow = new DateTimeOffset(2025, 10, 28, 9, 30, 0, TimeSpan.Zero);
        var timeProvider = new ManualTimeProvider(fixedNow);
        var task = TaskItem.Create("Task title", dueDate: fixedNow.AddDays(1), timeProvider: timeProvider);

        timeProvider.Advance(TimeSpan.FromMinutes(10));
        task.ChangeDueDate(null);

        Assert.Null(task.DueDate);
        Assert.Equal(fixedNow.AddMinutes(10), task.UpdatedAtUtc);
    }

    private sealed class ManualTimeProvider : TimeProvider
    {
        private DateTimeOffset _utcNow;

        public ManualTimeProvider(DateTimeOffset utcNow)
        {
            _utcNow = utcNow;
        }

        public void Advance(TimeSpan delta)
        {
            _utcNow = _utcNow.Add(delta);
        }

        public override DateTimeOffset GetUtcNow()
        {
            return _utcNow;
        }
    }
}
