
namespace API.Requests
{
    public sealed record UpdateTodoRequest
    (
        string Title,
        string? Description,
        bool Done
    );
}