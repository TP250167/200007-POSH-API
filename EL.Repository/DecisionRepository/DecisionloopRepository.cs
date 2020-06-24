using EL.Domain.Entities.DecisionloopEntity;

namespace EL.Repository.DecisionRepository
{
    public class DecisionloopRepository : EntityBaseRepository<Decisionloop>, IDecisionloopRepository
    {
        private readonly ELContext context;
        public DecisionloopRepository(ELContext context) : base(context)
        {
            this.context = context;
        }


    }
}
