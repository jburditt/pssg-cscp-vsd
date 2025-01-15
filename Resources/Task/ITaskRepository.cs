using Task = Manager.Contract.Task;

namespace Resources;

public interface ITaskRepository : IBaseRepository<Task>
{
    TaskResult Query(TaskQuery taskQuery);
}