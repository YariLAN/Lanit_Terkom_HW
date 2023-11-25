namespace RabbitClient.Publishers
{
    public interface IUpdateMessagePublisher<id, T, Responce>
    {
        Responce SendUpdateMessage(id id, T request);
    }
}
