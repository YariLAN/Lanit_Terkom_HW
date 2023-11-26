namespace RabbitClient.Publishers.Interfaces
{
    public interface IDeleteMessagePublisher<id, Responce>
    {
        Responce SendDeleteMessage(id id);
    }
}
