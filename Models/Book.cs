using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MySite.Models;

public class Book
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? Id { get; set; }

	public string Name { get; set; } = null!;

	public decimal Price { get; set; }

	public string Category { get; set; } = null!;

	public string Author { get; set; } = null!;

	public Book(string name, decimal price, string category, string author)
	{
		Name = name;
		Price = price;
		Category = category;
		Author = author;
	}
	public Book(string id, string name, decimal price, string category, string author)
	{
		Id = id;
		Name = name;
		Price = price;
		Category = category;
		Author = author;
	}
}