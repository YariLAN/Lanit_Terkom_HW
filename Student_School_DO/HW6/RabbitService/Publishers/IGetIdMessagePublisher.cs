namespace RabbitClient.Publishers
{
    public interface IGetByIdMessagePublisher<id, Responce>
    {
        Responce SendGetByIdMessage(id request);
    }
}
