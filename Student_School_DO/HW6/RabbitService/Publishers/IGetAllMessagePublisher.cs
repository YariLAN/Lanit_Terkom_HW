namespace RabbitClient.Publishers
{
    public interface IGetAllMessagePublisher<Responce, T>
    {
        Responce SendGetAllMessage(T request);
    }
}
