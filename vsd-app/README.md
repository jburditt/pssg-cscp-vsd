# PDF Microservice

This project uses a [Weasyprint](http://weasyprint.org/) microservice to generate PDF documents.

The PDF Microservice is currently using the [aquavitae/weasyprint](https://hub.docker.com/r/aquavitae/weasyprint/) image.  This is a simple microservice that works in an OpenShift environment.

The microservice is exposed internally to the project on http://weasyprint:5001 or at http://localhost:8083 if you are using the docker-compose development environment.

The following endpoints are available:

```
POST to /pdf?filename=myfile.pdf. The body should contain html

POST to /multiple?filename=myfile.pdf. The body should contain a JSON list of html strings. They will each be rendered and combined into a single pdf
```

By default the deployment configuration does not configure a route to the microservice; therefore it is only accessible internally to the project.  If you need an external route for conveyance you can add one manually, but this should only ever be done for a DEV environment.  

## Testing

Use Postman or some other tool to post the following html to the deployed pdf microservice.  In Postman use `Send and Download` to save the resulting pdf to disk.

Headers to set:
```
Accept: application/pdf
```

Sample html:
```
<!DOCTYPE html>
<html>
<head>
    <title>Test File</title>
</head>
<body>
    <h1>Hello World</h1>
</body>
</html>
```

## References

* Project: [Weasyprint](http://weasyprint.org/)
* Image: [aquavitae/weasyprint](https://hub.docker.com/r/aquavitae/weasyprint/)
* Source: [aquavitae/docker-weasyprint](https://github.com/aquavitae/docker-weasyprint)

## Dataverse How-To

Query
1-1 and N-1 mappings use Join method, see 
1-N and N-N mappings query see PaymentRepository.Query method

Insert with children see PaymentRepository.Insert method

### TIPS
For joins, try using anonymous types instead of creating a new class; otherwise you might get object reference not set to an instance of an object errors

Query a join table (you shouldn't need to use this, but just in case)
```
var queryResults = _databaseContext
    .CreateQuery(Vsd_Payment.Fields.Vsd_Vsd_Payment_Vsd_Invoice.ToLower())
    .Where(x => x.Attributes[Vsd_Payment.Fields.Vsd_PaymentId] == paymentQuery.Id);
```

### HELPFUL LINKS

[Dynamics365-Apps-Samples](https://github.com/microsoft/Dynamics365-Apps-Samples/blob/master/samples-from-msdn/EarlyBound/BasicContextExamples.cs)
[Message Execute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.execute?view=dataverse-sdk-latest)
[Early bound entity classes](https://learn.microsoft.com/en-us/dynamics365/customerengagement/on-premises/developer/org-service/create-early-bound-entity-classes-code-generation-tool?view=op-9-1)
[OrganizationServiceContext LINQ](https://learn.microsoft.com/en-us/power-apps/developer/data-platform/org-service/build-queries-with-linq-net-language-integrated-query)