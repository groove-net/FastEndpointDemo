namespace MySite.Endpoints.Books;

public record DeleteRequest
{
    public string Id { get; set; } = null!;
}
