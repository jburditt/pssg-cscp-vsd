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
    public string? ClientCode { get; set; }
    public string? ResponsibilityCentre { get; set; }
    public string? ServiceLine { get; set; }
    public string? Stob { get; set; }
    public string? ProjectCode { get; set; }
}