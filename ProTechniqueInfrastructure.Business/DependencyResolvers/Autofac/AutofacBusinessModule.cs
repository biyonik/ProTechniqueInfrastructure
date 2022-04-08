namespace ProTechniqueInfrastructure.Business.DependencyResolvers.Autofac;
public class AutofacBusinessModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>();
        builder.RegisterType<EfProductDal>().As<IProductDal>();

    }
}