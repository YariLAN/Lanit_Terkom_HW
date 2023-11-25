namespace RabbitClient.Publishers
{
    public interface ICreateMessagePublisher<T, Responce>
    {
        Responce SendCreateMessage(T request);
    }
}
