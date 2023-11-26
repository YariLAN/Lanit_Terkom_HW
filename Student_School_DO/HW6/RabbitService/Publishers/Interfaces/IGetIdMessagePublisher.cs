namespace RabbitClient.Publishers.Interfaces
{
    public interface IGetByIdMessagePublisher<id, Responce>
    {
        Responce SendGetByIdMessage(id request);
    }
}
