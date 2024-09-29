using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Seeds.Ufs;

namespace DoaFacil.Backend.Infra.Database.Seeds
{
    public class Seed(IRepositoryContext context) : ISeed
    {
        public virtual void Execute() => new UfSeed(context).Execute();
    }
}
