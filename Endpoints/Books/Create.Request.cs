namespace MySite.Endpoints.Books;

public record CreateRequest(
	string Name,
	decimal Price,
	string Category,
	string Author
);