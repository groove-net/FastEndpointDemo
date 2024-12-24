using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using MySite.Models;
using MySite.Services;
namespace MySite.Endpoints.Books;

[HttpPut("/api/books/{id}")]
[AllowAnonymous]
public class Update(IBooksService booksService) : Endpoint<UpdateRequest, Results<NoContent, NotFound>>
{
	private readonly IBooksService _booksService = booksService;

	public override async Task<Results<NoContent, NotFound>> ExecuteAsync(UpdateRequest req, CancellationToken ct)
	{
		var book = await _booksService.GetAsync(req.Id);

		if (book is null)
			return TypedResults.NotFound();

		var updatedBook = new Book(
			req.Id,
			req.Name ?? book.Name,
			req.Price ?? book.Price,
			req.Category ?? book.Category,
			req.Author ?? book.Author
		);

		await _booksService.UpdateAsync(req.Id, updatedBook);

		return TypedResults.NoContent();
	}
}
