namespace RabbitClient.Publishers.Interfaces
{
    public interface ICreateMessagePublisher<T, Responce>
    {
        Responce SendCreateMessage(T request);
    }
}
