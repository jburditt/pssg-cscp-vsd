public class PaymentScheduleTests(IMediator mediator, ITeamRepository teamRepository, IIncomeSupportParameterRepository incomeSupportParameterRepository, IPaymentRepository paymentRepository)
{
    // NOTE not a practical integration test, used to speed up the development of PaymentController.SchedulePayment service
    [Fact]
    public async Task Schedule_Payment()
    {
        var teamQuery = new SingleTeamQuery();
        teamQuery.Name = "CVAP Administrative Team";
        teamQuery.TeamType = TeamType.Owner;
        var team = await mediator.Send(teamQuery);
        if (team == null)
        {
            throw new Exception("CVAP Admin Team not found.");
        }

        var incomeSupportParamterQuery = new SingleIncomeSupportParameterQuery();
        incomeSupportParamterQuery.Type = IncomeSupportParameterType.MinimumWage;
        incomeSupportParamterQuery.BeforeEffectiveDate = DateTime.Today;
        incomeSupportParamterQuery.StateCode = StateCode.Active;
        incomeSupportParamterQuery.StatusCode = IncomeSupportParameterStatusCode.Active;
        incomeSupportParamterQuery.Validated = YesNo.Yes;
        var minimumWage = await mediator.Send(incomeSupportParamterQuery);
    }
}
