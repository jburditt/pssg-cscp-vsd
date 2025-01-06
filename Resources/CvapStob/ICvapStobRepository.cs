namespace Resources;

public interface ICvapStobRepository : 
    IFindRepository<FindCvapStobQuery, CvapStob>, 
    IQueryRepository<CvapStobQuery, CvapStob>,
    IBaseRepository<CvapStob> 
{ }
