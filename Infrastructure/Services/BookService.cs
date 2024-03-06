namespace Infrastructure.Services;
using DataContext;
using Dapper;
using Domain.Models;
public class BookService
{
  
   private readonly DapperContext context;

   public BookService()
   {
     context=new DapperContext();
   }

   public List<Books> GetListBooks()
   {

     var sql1="select * from Books order by id";

      return context.Connection().Query<Books>(sql1).ToList();

   }

   public void AddBooks(Books book)
   {
     var sql1=@"insert into Books (Title,Isbn,Janr,Date_of_print,Dostup)
                values(@Title,@Isbn,@Janr,@Date_of_print,@Dostup)";

      context.Connection().Execute(sql1,book);        
   }


   public void DeleteBooks(int id)
   {
     var sql="delete from Books where id=@id ";

     context.Connection().Execute(sql,new{Id=id});
   }

   public void UpdateBooks(Books book)
   {
     var sql="Update Books set Title=@Title,Isbn=@Isbn,Janr=@Janr,Date_of_print=@Date_of_print,Dostup=@Dostup where id=@id  ";

     context.Connection().Execute(sql,book);

   }

   public List<Books> GetListBooksByJanre(string janr)
   {
      var sql="select * from Books where Janr=@janr order by id ";

      return context.Connection().Query<Books>(sql,new{Janr=janr}).ToList();
   }


    public List<Books> GetListBooksByTitle(string title )
   {
      var sql="select * from Books where Title ilike @title order by id ";

      return context.Connection().Query<Books>(sql,new{Title=$"%{title}%"}).ToList();
   }


    
}
