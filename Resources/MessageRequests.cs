using Microsoft.Crm.Sdk.Messages;

namespace Resources;

public interface IMessageRequests
{
    string SetState(string logicalName, Guid id, int state, int status);
    //string SetState<T>(T entity, int state, int status) where T : Entity;
}

public class MessageRequests(DatabaseContext databaseContext) : IMessageRequests
{
    public string SetState(string logicalName, Guid id, int state, int status)
    {
        var request = new SetStateRequest();
        var entity = new Entity(logicalName, id);
        request.EntityMoniker = entity.ToEntityReference();
        request.State = new OptionSetValue(state);
        request.Status = new OptionSetValue(status);
        var response = (SetStateResponse)databaseContext.Execute(request);
        return response.ResponseName;
    }

    //public string SetState<T>(T entity, int state, int status) where T : Entity
    //{
    //    var request = new SetStateRequest();
    //    request.EntityMoniker = entity.ToEntityReference();
    //    request.State = new OptionSetValue(state);
    //    request.Status = new OptionSetValue(status);
    //    var response = (SetStateResponse)databaseContext.Execute(request);
    //    return response.ResponseName;
    //}
}
