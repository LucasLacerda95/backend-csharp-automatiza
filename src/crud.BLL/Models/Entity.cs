
namespace crud.BLL.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Codigo = Guid.NewGuid();
        }

        public Guid Codigo { get; set; }
    }

}
