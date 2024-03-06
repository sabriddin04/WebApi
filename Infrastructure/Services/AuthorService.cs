namespace Infrastructure.Services;
using DataContext;
using Domain.Models;
using Dapper;
public class AuthorService
{
 
   private readonly DapperContext _context;

   public AuthorService ()
   {
     _context=new DapperContext();
   }

   public List<Authors> GetListAuthors()
   {

     var sql1="select * from Authors order by id";

      return _context.Connection().Query<Authors>(sql1).ToList();

   }

   public void AddAuthors(Authors author)
   {
     var sql1=@"insert into Authors (FullName,age)
                values(@FullName,@Age)";

      _context.Connection().Execute(sql1,author);        
   }


   public void DeleteAuthors(int id)
   {
     var sql="delete from Authors where id=@id ";

     _context.Connection().Execute(sql,new{Id=id});
   }

   public void UpdateAuthors(Authors author)
   {
     var sql="Update Authors set FullName=@FullName,Age=@age where id=@id  ";

     _context.Connection().Execute(sql,author);

   }





}
