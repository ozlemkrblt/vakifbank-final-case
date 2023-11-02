namespace ECommerce.Schema;
public class MessageRequest
{
    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string Text { get; set; }

    public DateTime SentTime { get; set; }

}

public class MessageResponse
{
    public int SenderId { get; set; }
    public string SenderName { get; set; }
    public int ReceiverId { get; set; }
    public string ReceiverName { get; set; }
    public string Text { get; set; }

    public DateTime SentTime { get; set; }
}

