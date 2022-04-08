using ProTechniqueInfrastructure.Core.DataAccess.EntityFramework;
using ProTechniqueInfrastructure.DataAccess.Concrete.EntityFramework.Contexts;

namespace ProTechniqueInfrastructure.DataAccess.Concrete.EntityFramework.Repositories;

public class EfProductDal : EfEntityRepositoryBase<Product, ProTechniqueInfrastructureDbContext>, IProductDal
{
    
}