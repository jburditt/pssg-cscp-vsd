namespace Manager;

public class ProgramHandlers : QueryBaseHandlers<IProgramRepository, Program, ProgramQuery>,
    IRequestHandler<ProgramQuery, IEnumerable<Program>>,
    IRequestHandler<GetApprovedCommand, IEnumerable<Program>>
{
    private readonly IMapper _mapper;

    public ProgramHandlers(IProgramRepository repository, IMapper mapper) : base(repository) 
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<Program>> Handle(ProgramQuery query, CancellationToken cancellationToken)
    {
        var programResults = _repository.Query(query);
        var programs = _mapper.Map<IEnumerable<Program>>(programResults);
        return await Task.FromResult(programs);
    }

    public async Task<IEnumerable<Program>> Handle(GetApprovedCommand dummy, CancellationToken cancellationToken)
    {
        var programResults = _repository.GetApproved();
        var programs = _mapper.Map<IEnumerable<Program>>(programResults);
        return await Task.FromResult(programs);
    }
}
