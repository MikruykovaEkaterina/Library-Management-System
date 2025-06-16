using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
  public class Library
  {
    private static Library instance;
    private Library()
    { }
    public static Library getInstance()
    {
      if (instance == null)
        instance = new Library();
      return instance;
    }
    private Dictionary<int, Book> Books= new Dictionary<int, Book>(); //библиотека книг, id - ключ
    private Dictionary<int, Reader> Readers; //библиотека читателей, id - ключ
   
    // Добавление книги в библиотеку с новым ID
    public void AddBook(string title, string author, int year, string genre)
    {
      Book booknew = new Book(title, author, year, genre);
      Books[booknew.ID] = booknew;
      Console.WriteLine($"Добавлена книга: {title}");
    }

    // Удаление книги из библиотеки (поиск по ID)
    public void RemoveBook(int id)
    {
            if (Books.ContainsKey(id))
            {
                if (Books[id].IsAvailable == true)
                {
                    Books.Remove(id);
                    Console.WriteLine($"Книга с ID ({id}) удалена");
                }
                else
                {
                    Console.WriteLine($"Книга с ID ({id}) занята. Удаление отменено");
                }
            }
            else
            {
                Console.WriteLine($"Книга с ID ({id}) не найдена");
            }
    }

    // Редактирование книги (отдельные колонки по запросу attribute)
        public void EditBook(int id, string attribute, string newValue)
        {
            if (Books.ContainsKey(id))
            {
                Book book = Books[id];
                IEditStrategy editStrategy = attribute switch
                {
                    "название" => new TitleEditStrategy(),
                    "автор" => new AuthorEditStrategy(),
                    "год" => new YearEditStrategy(),
                    "жанр" => new GenreEditStrategy(),
                    _ => throw new ArgumentException("Неверно введен параметр")
                };
                editStrategy.Edit(book, newValue);
            }
            else
            {
                Console.WriteLine($"Книга с ID ({id}) не найдена");
            }
        }
        // Вывод всех книг
        public void DisplayBooks()
        {
            Console.WriteLine("Книг в библиотэке вооот столько:");
            foreach (var book in Books)
            {
                Console.WriteLine($"ID: {book.Key}, {book.Value}");
            }
        }
    }
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
}
