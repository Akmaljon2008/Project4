using Domain.Models;
using Infrastracture.Services;

namespace WebApi.Controller;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController()
    {
        _bookService = new BookService();
    }


    /*[HttpPost("add-book")]
    public void AddBook(Book book, Author author)
    {
        _bookService.AddBook(book,author);
    }*/

    [HttpGet("get-books")]
    public List<BookAuthor> GetBooks()
    {
        return _bookService.GetBooks();
    }

    /*[HttpPut("update - book")]
    public void UpdateBook(Book book, Author author)
    {
        _bookService.UpdateBook(book,author);
    }*/

    [HttpDelete("delete-book")]
    public void DeleteBook(int id)
    {
        _bookService.DeleteBook(id);
    }

    [HttpGet("get-by-title")]
    public BookAuthor GetByTitle(string title)
    {
        return _bookService.GetByTitle(title);
    }

    [HttpGet("get-by-author")]
    public BookAuthor GetByAuthor(string author)
    {
        return _bookService.GetByAuthor(author);
    }
    
}
