namespace RabbitClient.Publishers.Interfaces
{
    public interface IUpdateMessagePublisher<id, T, Responce>
    {
        Responce SendUpdateMessage(id id, T request);
    }
}
