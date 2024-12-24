using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using MySite.Models;
using MySite.Services;

namespace MySite.Endpoints.Books;

[HttpGet("/api/books/{id}")]
[AllowAnonymous]
public class Get(IBooksService booksService) : Endpoint<GetRequest, Results<Ok<Book>, NotFound>>
{
	private readonly IBooksService _booksService = booksService;

	public override async Task<Results<Ok<Book>, NotFound>> ExecuteAsync(GetRequest req, CancellationToken ct)
	{
		var book = await _booksService.GetAsync(req.Id);
		return (book is null) ? TypedResults.NotFound() : TypedResults.Ok(book);
	}
}