namespace Manager;

public class ScheduleGHandlers(IScheduleGRepository repository) :
    QueryBaseHandlers<IScheduleGRepository, ScheduleG, ScheduleGQuery>(repository),
    IRequestHandler<ScheduleGQuery, IEnumerable<ScheduleG>>,
    IRequestHandler<InsertCommand<ScheduleG>, Guid>
{

}
