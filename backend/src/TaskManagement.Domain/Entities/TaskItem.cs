namespace TaskManagement.Domain.Entities;

public sealed class TaskItem
{
    private readonly TimeProvider _timeProvider;

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Enums.TaskStatus Status { get; private set; }
    public Enums.TaskPriority Priority { get; private set; }
    public DateTimeOffset? DueDate { get; private set; }
    public DateTimeOffset CreatedAtUtc { get; private set; }
    public DateTimeOffset UpdatedAtUtc { get; private set; }

    private TaskItem()
    {
        _timeProvider = TimeProvider.System;
        Title = string.Empty;
    }

    public TaskItem(
        string title,
        string? description = null,
        DateTimeOffset? dueDate = null,
        TimeProvider? timeProvider = null)
    {
        _timeProvider = timeProvider ?? TimeProvider.System;

        Title = ValidateTitle(title);
        Description = ValidateDescription(description);
        Status = Enums.TaskStatus.ToDo;
        Priority = Enums.TaskPriority.Medium;
        DueDate = dueDate;

        var now = _timeProvider.GetUtcNow();
        Id = Guid.NewGuid();
        CreatedAtUtc = now;
        UpdatedAtUtc = now;
    }

    public static TaskItem Create(
        string title,
        string? description = null,
        DateTimeOffset? dueDate = null,
        TimeProvider? timeProvider = null)
    {
        return new TaskItem(title, description, dueDate, timeProvider);
    }

    public void ChangeTitle(string title)
    {
        var normalized = ValidateTitle(title);

        if (string.Equals(Title, normalized, StringComparison.Ordinal))
        {
            return;
        }

        Title = normalized;
        Touch();
    }

    public void ChangeDescription(string? description)
    {
        var normalized = ValidateDescription(description);

        if (string.Equals(Description, normalized, StringComparison.Ordinal))
        {
            return;
        }

        Description = normalized;
        Touch();
    }

    public void ChangeStatus(Enums.TaskStatus status)
    {
        if (!Enum.IsDefined(status))
        {
            throw new ArgumentOutOfRangeException(nameof(status), "The task status is invalid.");
        }

        if (Status == status)
        {
            return;
        }

        Status = status;
        Touch();
    }

    public void ChangePriority(Enums.TaskPriority priority)
    {
        if (!Enum.IsDefined(priority))
        {
            throw new ArgumentOutOfRangeException(nameof(priority), "The task priority is invalid.");
        }

        if (Priority == priority)
        {
            return;
        }

        Priority = priority;
        Touch();
    }

    public void ChangeDueDate(DateTimeOffset? dueDate)
    {
        if (DueDate == dueDate)
        {
            return;
        }

        DueDate = dueDate;
        Touch();
    }

    private void Touch()
    {
        UpdatedAtUtc = _timeProvider.GetUtcNow();
    }

    private static string ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required.", nameof(title));
        }

        var normalized = title.Trim();

        if (normalized.Length is < 1 or > 200)
        {
            throw new ArgumentOutOfRangeException(nameof(title), "Title must be between 1 and 200 characters.");
        }

        return normalized;
    }

    private static string? ValidateDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return null;
        }

        var normalized = description.Trim();

        if (normalized.Length > 2000)
        {
            throw new ArgumentOutOfRangeException(nameof(description), "Description cannot exceed 2,000 characters.");
        }

        return normalized;
    }
}
