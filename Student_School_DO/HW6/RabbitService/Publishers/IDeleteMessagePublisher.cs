namespace RabbitClient.Publishers
{
    public interface IDeleteMessagePublisher<id, Responce>
    {
        Responce SendDeleteMessage(id id);
    }
}
