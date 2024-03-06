namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructure.Services;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{

    private readonly AuthorService authorService;

    public AuthorController()
    {
        authorService = new AuthorService();
    }

    [HttpGet("get-authors")]
    public List<Authors> GetListAuthors()
    {
        return authorService.GetListAuthors();
    }

    [HttpPost("Add-authors")]
    public void AddAuthors(Authors author)
    {
        authorService.AddAuthors(author);
    }
    [HttpDelete("Delete-authors")]

    public void DeleteAuthors (int id)
    {
        authorService.DeleteAuthors(id);
    }
    [HttpPut("Update-authors")]
    public void UpdateAuthors(Authors author)
    {
        authorService.UpdateAuthors(author);
    }


}
