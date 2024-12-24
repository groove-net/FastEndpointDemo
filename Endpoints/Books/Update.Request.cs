namespace MySite.Endpoints.Books;

public record UpdateRequest(
	string Id,
	string? Name,
	decimal? Price,
	string? Category,
	string? Author
);