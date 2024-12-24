namespace MySite.Endpoints.Books;

public record GetRequest
{
	public string Id { get; set; } = null!;
}
