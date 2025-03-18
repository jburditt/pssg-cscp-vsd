public class PaymentScheduleTests(IMediator mediator, IMessageRequests messageRequests, IEntitlementRepository entitlementRepository, ILoggerFactory loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<PaymentScheduleTests>();

    // NOTE not a practical integration test, used to speed up the development of PaymentController.SchedulePayment service

    // README to setup date to be able to "test" this, you will need to run the SeedDatabaseTests.Seed_Fake_Data test
    // The test will upsert a payment schedule and entitlement but the entitlement will have Entitlement.PaymentScheduleStatus = Modified
    // To fix this, you will need to navigate to Dynamics 365 portal https://cscp-vs.dev.jag.gov.bc.ca/main.aspx?appid=11fae680-ee36-470f-a7a2-9c8e16e11a67&pagetype=entityrecord&etn=vsd_entitlement&id=26df878f-b0bb-408b-b829-427053fcd0f0
    // You will not be able to find Entitlements in Dynamics by navigating Dynamics 365 portal, so use the above link to find the entitlement, change the appid query parameter, if needed
    // Under "Benefit Status" change the Payment Status to "Active" and save. Now you can run the below test and it will pick up the payment schedule with entitlement
    [Fact]
    public async Task Schedule_Payment()
    {
        var command = new ScheduleCvapPaymentsCommand();
        var isSuccess = await mediator.Send(command);

        Assert.True(isSuccess);
    }
}
