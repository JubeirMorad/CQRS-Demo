
namespace API.Requests
{
    public sealed record CreateTodoRequest
    (
        string Title,
        string? Description
    );
}