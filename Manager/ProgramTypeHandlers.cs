namespace Manager;

public class ProgramTypeHandlers : FindQueryBaseHandlers<IProgramTypeRepository, ProgramType, FindProgramTypeQuery, ProgramTypeQuery>,
    IRequestHandler<FindProgramTypeQuery, ProgramType>
{
    private readonly IMapper _mapper;

    public ProgramTypeHandlers(IProgramTypeRepository repository, IMapper mapper) : base(repository) 
    {
        _mapper = mapper;
    }

    public async Task<ProgramType> Handle(FindProgramTypeQuery query, CancellationToken cancellationToken)
    {
        var entity = _repository.FirstOrDefault(query);
        var dto = _mapper.Map<ProgramType>(entity);
        return await Task.FromResult(dto);
    }
}
