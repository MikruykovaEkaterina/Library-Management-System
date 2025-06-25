using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
  // Интерфейс стратегии редактирования книги
  public interface IEditStrategy
  {
    void Edit(Book book, string newValue);
  }

  // Стратегия редактирования названия книги
  public class TitleEditStrategy : IEditStrategy
  {
    public void Edit(Book book, string newValue)
    {
      book.Title = newValue;
      Console.WriteLine($"Название изменено: {book}");
    }
  }

  // Стратегия редактирования автора книги
  public class AuthorEditStrategy : IEditStrategy
  {
    public void Edit(Book book, string newValue)
    {
      book.Author = newValue;
      Console.WriteLine($"Автор изменен: {book}");
    }
  }

  // Стратегия редактирования года издания книги
  public class YearEditStrategy : IEditStrategy
  {
    public void Edit(Book book, string newValue)
    {
      if (int.TryParse(newValue, out int newYear))
      {
        book.Year = newYear;
        Console.WriteLine($"Год издания изменен: {book}");
      }
      else
      {
        Console.WriteLine("Неверное значение");
      }
    }
  }

  // Стратегия редактирования жанра книги
  public class GenreEditStrategy : IEditStrategy
  {
    public void Edit(Book book, string newValue)
    {
      book.Genre = newValue;
      Console.WriteLine($"Жанр изменен: {book}");
    }
  }
}
