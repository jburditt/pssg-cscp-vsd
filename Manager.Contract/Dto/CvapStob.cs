public record FindCvapStobQuery : BaseCvapStobQuery, IRequest<CvapStob> { }
public record CvapStobQuery : BaseCvapStobQuery, IRequest<IEnumerable<CvapStob>> { }
public record BaseCvapStobQuery
{
    public Guid? Id { get; set; }
}

public record CvapStob : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public required string ClientCode { get; set; }             // Dynamics Business Required
    public required string ResponsibilityCentre { get; set; }   // Dynamics Business Required
    public required string ServiceLine { get; set; }            // Dynamics Business Required
    public required string Stob { get; set; }                   // Dynamics Business Required
    public required string ProjectCode { get; set; }            // Dynamics Business Required
}