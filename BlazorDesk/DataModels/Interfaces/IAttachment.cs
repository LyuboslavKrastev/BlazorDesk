
namespace BlazorDesk.DataModels.Interfaces
{
    public interface IAttachment : IEntity
    {
        string FileName { get; set; }
        string PathToFile { get; set; }
    }
}