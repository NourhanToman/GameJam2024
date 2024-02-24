[System.Serializable]
public class Message
{
    public int messageNo;
    public string audioName;
    public string message;
    public Message()
    {

    }
    public Message(string text)
    {
        this.message = text;
    }
}