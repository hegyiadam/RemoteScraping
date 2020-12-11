namespace ComponentInterfaces.Tasks
{
    public interface IPageTask : ITask
    {
        int PageNumber { get; set; }
        string PageSelector { get; set; }
    }
}