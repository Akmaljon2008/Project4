using Dapper;

namespace Infrastracture.Services;
using Domain.Models;
public class BookService
{
    public readonly DapperContext _db;

    public BookService()
    {
        _db = new DapperContext();
    }

    public List<BookAuthor> GetBooks()
    {
        var sql = "select b.Title,a.FullName from BookAuthor as ba join Book as b on ba.bookid = b.id join author a on a.id = ba.authorid";
        return _db.Connection().Query<BookAuthor>(sql).ToList();
    }

    public void AddBook(Book book, Author author)
    {
        var sql = "insert into Book(title, description, publisheddate)values (@title, @description, @publisheddate)";
        var sql1 = "insert into author(fullname)values (@fullname)";
        var sql2 = "insert into bookauthor(bookid, authorid)values (@bookid, @authorid)";
        _db.Connection().Execute(sql, book);
        _db.Connection().Execute(sql, author);
        _db.Connection().Execute(sql, new { Bookid = book.Id, AuthorId = author.Id });
    }

    public void UpdateBook(Book book, Author author)
    {
        var sql = "update book set Title = @title,description = @description,publisheddate = @publisheddate where id = @id";
        var sql1 = "update author set fullname = @fullname where id = @id";
        _db.Connection().Execute(sql, book);
        _db.Connection().Execute(sql1, new { FullName = author.FullName, Id = book.Id });
    }

    public void DeleteBook(int id)
    {
        var sql = "delete from book where id = @id";
        _db.Connection().Execute(sql, new { Id = id });
    }

    public BookAuthor GetByTitle(string title)
    {
        var sql = @"select b.Title,a.FullName from bookauthor as ba join Book as b on ba.bookId = b.id join Author as a on ba.authorid = a.id where b.title like %@title%";
        return _db.Connection().QuerySingle<BookAuthor>(sql, new { Title = title });
    }

    public BookAuthor GetByAuthor(string fullname)
    {
        var sql = @"select b.Title,a.FullName from bookauthor as ba join Book as b on ba.bookId = b.id join Author as a on ba.authorid = a.id where a.fullname like %@fullname%";
        return _db.Connection().QuerySingle<BookAuthor>(sql, new { Fullname = fullname });

    }
}