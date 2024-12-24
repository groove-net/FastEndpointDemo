using MySite.Models;

namespace MySite.Endpoints.Books;

public record ListResponse(
	int NumberOfBooks,
	IReadOnlyCollection<Book> Books
);