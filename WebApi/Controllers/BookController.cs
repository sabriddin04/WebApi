namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructure.Services;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{

    private readonly BookService bookService;

    public BookController()
    {
        bookService = new BookService();
    }

    [HttpGet("get-books")]
    public List<Books> GetListBooks()
    {
        return bookService.GetListBooks();
    }

    [HttpPost("Add-books")]
    public void AddBooks(Books book)
    {
        bookService.AddBooks(book);
    }
    [HttpDelete("Delete-books")]

    public void DeleteBooks(int id)
    {
        bookService.DeleteBooks(id);
    }
    [HttpPut("Update-books")]
    public void UpdateBooks(Books book)
    {
        bookService.UpdateBooks(book);
    }

    [HttpGet("get-books by Janre")]

    public List<Books> GetListBooksByJanre(string janr)
    {
       return bookService.GetListBooksByJanre(janr);
    }
   
    [HttpGet("get-books by Title")]
    public List<Books> GetListBooksByTitle(string title )
   {
     
      return bookService.GetListBooksByTitle(title);
   }



}
