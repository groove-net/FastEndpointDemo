using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using MySite.Services;

namespace MySite.Endpoints.Books;

[HttpDelete("/api/books/{id}")]
[AllowAnonymous]
public class Delete(IBooksService booksService) : Endpoint<DeleteRequest, Results<NoContent, NotFound>>
{
	private readonly IBooksService _booksService = booksService;

	public override async Task<Results<NoContent, NotFound>> ExecuteAsync(DeleteRequest req, CancellationToken ct)
	{
		var book = await _booksService.GetAsync(req.Id);

		if (book is null)
			return TypedResults.NotFound();

		await _booksService.RemoveAsync(req.Id);

		return TypedResults.NoContent();
	}
}
