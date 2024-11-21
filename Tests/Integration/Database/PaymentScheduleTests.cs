using Task = System.Threading.Tasks.Task;

public class PaymentScheduleTests(IMediator mediator, ITeamRepository teamRepository, IPaymentRepository paymentRepository)
{
    // NOTE not a practical integration test, used to speed up the development of PaymentController.SchedulePayment service
    [Fact]
    public async Task Schedule_Payment()
    {
        var teamQuery = new BaseTeamQuery();
        teamQuery.Name = "queueid";
        teamQuery.TeamType = TeamType.Owner;
        //var team = teamRepository.FirstOrDefault(teamQuery);
        var team = await mediator.Send(teamQuery);
    }
}
