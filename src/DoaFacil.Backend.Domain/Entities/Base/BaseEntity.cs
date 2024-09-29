namespace DoaFacil.Backend.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        protected BaseEntity() => SetId(Guid.NewGuid());
        
        public Guid Id { get; private set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
