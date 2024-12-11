
namespace Manager;

public class CvapStobHandlers(ICvapStobRepository repository, IMapper mapper) : FindQueryBaseHandlers<ICvapStobRepository, CvapStob, FindCvapStobQuery, CvapStobQuery>(repository)
{

}
