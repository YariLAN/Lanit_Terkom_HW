namespace RabbitClient.Publishers.Interfaces
{
    public interface IGetAllMessagePublisher<Responce, T>
    {
        Responce SendGetAllMessage(T request);
    }
}
