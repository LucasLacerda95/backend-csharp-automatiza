
namespace crud.BLL.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; set; }
    }

}
