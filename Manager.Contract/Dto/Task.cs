namespace Manager.Contract;

public record TaskQuery : IRequest<TaskResult>
{
    public Guid? Id { get; set; }
    public Guid? ScheduleGId { get; set; }
}

public record TaskResult(IEnumerable<Task> Tasks);

[Description("To-Do")]
public class Task : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public required string Subject { get; set; }    // Dynamics Business Required
    public DateTime ScheduledEnd { get; set; }      // Dynamics Business Required

    // References
    public Guid? TaskTypeId { get; set; }           // Dynamics Optional
    public Guid RegardingObjectId { get; set; }     // Dynamics Business Required
    public Guid? ProgramId { get; set; }            // Dynamics Optional
    public Guid? ScheduleGId { get; set; }          // Dynamics Optional
}
