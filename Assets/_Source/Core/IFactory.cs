namespace Core
{
    public interface IFactory<TValue>
    {
        TValue Create();
    }
}