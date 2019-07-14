namespace Model.entities
{
    public interface IHasID<T>
    {
        T ID { get; set; }
    }
}
