using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using MySite.Services;

namespace MySite.Endpoints.Books;

[HttpGet("/api/books")]
[AllowAnonymous]
public class List(IBooksService booksService) : Endpoint<EmptyRequest, Ok<ListResponse>>
{
	private readonly IBooksService _booksService = booksService;

	public override async Task<Ok<ListResponse>> ExecuteAsync(EmptyRequest req, CancellationToken ct)
	{
		var booksList = await _booksService.GetAsync();
		return TypedResults.Ok(new ListResponse(booksList.Count, booksList));
	}
}
