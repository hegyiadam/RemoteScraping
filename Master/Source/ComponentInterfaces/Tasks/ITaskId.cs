namespace ComponentInterfaces.Tasks
{
    public interface ITaskId
    {
        ITaskId Deserialize(string source);

        string Serialize();
    }
}