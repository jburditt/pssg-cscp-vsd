using Microsoft.Crm.Sdk.Messages;

namespace Resources;

public interface IMessageRequests
{
    string SetState<T>(T entity, int state, int status) where T : Entity;
}

public class MessageRequests(DatabaseContext databaseContext) : IMessageRequests
{
    public string SetState<T>(T entity, int state, int status) where T : Entity
    {
        var request = new SetStateRequest();
        request.EntityMoniker = entity.ToEntityReference();
        request.State = new OptionSetValue(state);
        request.Status = new OptionSetValue(status);
        var response = (SetStateResponse)databaseContext.Execute(request);
        return response.ResponseName;
    }
}
