using AutoMapper;
using System.Linq.Expressions;

namespace Resources;

public class FakeRepository : IFakeRepository
{
    protected readonly DatabaseContext _databaseContext;
    protected readonly IMapper _mapper;

    public FakeRepository(DatabaseContext databaseContext, IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public virtual Guid Insert(FakeDto dto)
    {
        return new Guid();
    }

    public virtual Guid Upsert(FakeDto dto)
    {
        return new Guid();
    }

    public IEnumerable<FakeDto> Where(Expression<Func<FakeDto, bool>> predicates)
    {
        throw new NotImplementedException();
    }

    public bool Update(FakeDto dto)
    {
        return true;
    }

    public virtual bool TryDelete(Guid id)
    {
        return true;
    }

    public virtual bool TryDelete(FakeDto dto, bool isRecursive = false)
    {
        return true;
    }

    public virtual bool TryDeleteRange(IEnumerable<FakeDto> invoices, bool isRecursive = false)
    {
        return true;
    }

    public virtual bool Delete(Guid id)
    {
        return true;
    }
}
