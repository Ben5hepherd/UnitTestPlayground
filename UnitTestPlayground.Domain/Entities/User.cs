namespace UnitTestPlayground.Domain.Entities
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
    }
}