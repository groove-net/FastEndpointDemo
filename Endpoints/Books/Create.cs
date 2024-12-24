// using System;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using MySite.Models;
using MySite.Services;

namespace MySite.Endpoints.Books;

[HttpPost("/api/books")]
[AllowAnonymous]
public class Create(IBooksService booksService) : Endpoint<CreateRequest, Created<Book>>
{
	private readonly IBooksService _booksService = booksService;

	public override async Task<Created<Book>> ExecuteAsync(CreateRequest req, CancellationToken ct)
	{
		var newBook = new Book(req.Name, req.Price, req.Category, req.Author);
		await _booksService.CreateAsync(newBook);
		return TypedResults.Created($"/api/books/{newBook.Id}", newBook);
	}
}
