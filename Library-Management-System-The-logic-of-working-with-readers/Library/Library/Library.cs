using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
  public class Library
  {
    private static Library instance;

    private Library()
    {
    }
    public static Library getInstance()
    {
      if (instance == null)
        instance = new Library();
      return instance;
    }
    private Dictionary<int, Book> Books = new Dictionary<int, Book>(); //библиотека книг, id - ключ
    private Dictionary<int, Reader> Readers = new Dictionary<int, Reader>(); //библиотека читателей, id - ключ

    //Логика работы с книгами

    //Проверка, на наличие книги с таким ID
    private bool CheckIfBookExists(int bookId)
    {
      if (!Books.ContainsKey(bookId))
      {
        Console.WriteLine($"Книга с ID ({bookId}) не найдена");
        return false;
      }
      return true;
    }
    // Добавление книги в библиотеку с новым ID
    public void AddBook(string title, string author, int year, string genre)
    {
      Book booknew = new Book(title, author, year, genre);
      Books[booknew.ID] = booknew;
      Console.WriteLine($"Добавлена новая книга: {booknew}");
    }

    // Удаление книги из библиотеки (поиск по ID)
    public void RemoveBook(int id)
    {
      if (!CheckIfBookExists(id))
        return;

      if (!Books[id].IsAvailable)
      {
        Console.WriteLine($"Книга с ID ({id}) занята. Удаление отменено");
        return;
      }
      //Все проверки пройдены, книги можно удалять
      Books.Remove(id);
      Console.WriteLine($"Книга с ID ({id}) удалена");
    }

    // Редактирование книги (отдельные колонки по запросу attribute)
    public void EditBook(int id, string attribute, string newValue)
    {
      if (!CheckIfBookExists(id))
        return;

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



    //логика работы с читателями

    //Проверка на наличие читателя с таким Id
    private bool CheckIfReaderExists(int readerId)
    {
      if (!Readers.ContainsKey(readerId))
      {
        Console.WriteLine($"Читатель с ID ({readerId}) не найден");
        return false;
      }
      return true;
    }

    //добавление читателя
    public void AddReader(string FirstName, string LastName)
    {
      Reader newReader = new Reader(FirstName, LastName);
      Readers[newReader.ID] = newReader;
      Console.WriteLine($"Добавлен новый читатель: {newReader}");
    }

    //Выдать книгу
    public void IssueBook(int readerId, int bookId)
    {
      //я решила оставить все проверки в телах метода
      if (!CheckIfReaderExists(readerId) || !CheckIfBookExists(bookId))
      {
        return;
      }
      if (!Books[bookId].IsAvailable)
      {
        Console.WriteLine($"Книга с ID ({bookId}) уже занята");
        return;
      }
      //книгу можно выдавать, все проверки пройдены
      Readers[readerId].AddBookIdToBorrowedBooks(bookId);
      Books[bookId].IsAvailable = false;
      Console.WriteLine($"Книга с ID ({bookId}) успешно выдана читателю с ID ({readerId}).");
    }

    //Вернуть книгу
    public void ReturnBook(int readerId, int bookId)
    {
      //я решила оставить все проверки в телах метода
      if (!CheckIfReaderExists(readerId) || !CheckIfBookExists(bookId))
        return;

      if (!Readers[readerId].CheckIfBookIdIsBorrowed(bookId))
      {
        Console.WriteLine($"Книга с ID ({bookId}) не числится у читателя с ID({readerId})");
        return;
      }

      //книгу можно вернуть, все проверки пройдены
      Readers[readerId].RemoveBookIdFromBorrowedBooks(bookId);
      Books[bookId].IsAvailable = true;
      Console.WriteLine($"Книга с ID ({bookId}) успешно возвращена в библиотеку.");
    }
    
    //Поиск книг по полям

    public void FindBook(string required, string attribute)
    {
      if (string.IsNullOrEmpty(required))
      {
        Console.WriteLine($"пустое название не подходит");
        return;
      }

      if (string.IsNullOrEmpty(attribute))
      {
        Console.WriteLine("пустой атрибут не подходит");
        return;
      }
      
      List<Book> find;
      switch (attribute.ToLowerInvariant())
      {
        case "название":
          find = Books.Values.Where(b => b.Title.Contains(required, StringComparison.OrdinalIgnoreCase)).ToList();
          break;
        case "автор":
          find = Books.Values.Where(b => b.Author.Contains(required, StringComparison.OrdinalIgnoreCase)).ToList();
          break;
        case "жанр":
          find = Books.Values.Where(b => b.Genre.Contains(required, StringComparison.OrdinalIgnoreCase)).ToList();
          break;
        default:
          Console.WriteLine($"Доступные поля для поиска: название, автор, жанр");
          return;
      }
      if (!find.Any())
      {
        Console.WriteLine($"Книги по запросу '{required}' в поле '{attribute}' не найдены.");
        return;
        
      }
      
      Console.WriteLine($"Найдено {find.Count} Книг: ");
      foreach (var b in find)
      {
        Console.WriteLine(b.ToString());
      }
    }
    
    // Поиск доступных и занятых книг
    
    public void ShowBookAvailableStatus()
    {
      var avialablebook = Books.Values.Where(b => b.IsAvailable).ToList();
      var inaccesiblebook = Books.Values.Where(b => !b.IsAvailable).ToList();
      Console.WriteLine("Свободные книги\n");
      if (avialablebook.Any())
      {
        foreach (var b in avialablebook)
        {
          Console.WriteLine(b.ToString());
        }        
      }
      else
      {
        Console.WriteLine("Нет свободных книг\n");
      }
      
      Console.WriteLine("Занятые книги\n");
      if (inaccesiblebook.Any())
      {
        foreach (var b in inaccesiblebook)
        {
          var readership = Readers.Values.Where(r => r.CheckIfBookIdIsBorrowed(b.ID)).ToList();
          {
            Console.WriteLine($"{b} у читателя {string.Join(", ", readership.Select(r => $"{r.FirstName} {r.LastName}"))}");
          }
        }
      }
      else
      {
        Console.WriteLine("Нет занятых книг\n");
      }

    }
  }
}

