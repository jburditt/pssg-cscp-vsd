namespace Resources;

public class TaskRepository : BaseRepository<Database.Model.Task, Manager.Contract.Task>, ITaskRepository
{
    private readonly DatabaseContext _databaseContext;

    public TaskRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper) 
    {
        _databaseContext = databaseContext;
    }

    public TaskResult Query(TaskQuery taskQuery)
    {
        var queryResults = _databaseContext.TaskSet
            .WhereIf(taskQuery.Id != null, x => x.Id == taskQuery.Id)
            .WhereIf(taskQuery.ScheduleGId != null, x => x.Vsd_ScheduleGId.Id == taskQuery.ScheduleGId)
            //.WhereIf(taskQuery.StateCode != null, c => c.StateCode == (Vsd_Task_StateCode)taskQuery.StateCode)
            //.WhereIf(taskQuery.StatusCode != null, c => c.StatusCode == (Vsd_Task_StatusCode)taskQuery.StatusCode)
            .ToList();
        var tasks = _mapper.Map<IEnumerable<Manager.Contract.Task>>(queryResults);
        return new TaskResult(tasks);
    }
}
