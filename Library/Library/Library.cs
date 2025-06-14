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

    // Редактирование книги (поиск по ID)
    public void EditBook(int id, string titlenew, string authornew, int yearnew, string genrenew)
    {
      if (Books.ContainsKey(id))
      {
        Book book = Books[id];
        book.Title = titlenew;
        book.Author = authornew;
        book.Year = yearnew;
        book.Genre = genrenew;
        Console.WriteLine($"Информация о книге {titlenew} (ID:{id}) изменена");
      }
      else
      {
        Console.WriteLine($"Книга с ID ({id}) не найдена");
      }
    }
  }
}
