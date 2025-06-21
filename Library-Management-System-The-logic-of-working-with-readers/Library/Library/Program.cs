using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
  class Program
  {
    static Library library = Library.getInstance(); //экземпляр библиотеки
    static void Main(string[] args)
    {
      while (true)
      {
        Console.WriteLine("\n" + "Меню библиотеки:" + "\n" +
                           "1. Добавить книгу" + "\n" +
                           "2. Удалить книгу" + "\n" +
                           "3. Изменить информацию о книге" + "\n" +
                           "4. Добавить читателя\n" +
                           "5. Взять книгу\n" +
                           "6. Вернуть книгу\n" +
                           "7. Поиск книг\n" +
                           "8. Вывести список свободных и занятых книг\n" +
                           "9. Выйти из библиотеки");


        int bookId, readerId;
        try
        {
          int menyitem = int.Parse(Console.ReadLine());
          switch (menyitem)
          {
            case 1:
              Console.Clear(); //нужно ли постоянно очищать консоль??
              Console.Write("Добавление книги, введите информацию:" + "\n" +
                    "Название - ");
              string title = Console.ReadLine();
              Console.Write("\n" + "Автор - ");
              string author = Console.ReadLine();
              Console.Write("\n" + "Год издания - ");
              int year;
              if (!int.TryParse(Console.ReadLine(), out year))
              {
                Console.WriteLine("Некорректный год, введите число\nКнига не создалась");
                break;
              }
              Console.Write("\n" + "Жанр - ");
              string genre = Console.ReadLine();
              library.AddBook(title, author, year, genre); // Добавление книги
              break;
            
            case 2:
              Console.Clear();
              Console.Write("Удаление книги, введите информацию:" + "\n" +
                            "ID книги - ");
              bookId = int.Parse(Console.ReadLine());
              library.RemoveBook(bookId); // Удаление книги из библиотеки
              break;
            case 3:
              Console.Clear();
              Console.Write("Редактирование данных книги, введите информацию:" + "\n" +
                            "ID книги - ");
              bookId = int.Parse(Console.ReadLine());

              Console.Write("\n" +
                            "Введите параметр, который надо изменить (название, автор, год, жанр) - ");
              string atribute = Console.ReadLine();
              Console.Write("\n" + "Новое значение - ");
              string newvalue = Console.ReadLine();
              library.EditBook(bookId, atribute, newvalue);

              break;
            case 4:
              Console.Clear();
              Console.Write("Добавление читателя, введите информацию:" + "\n" +
                                  "Имя - ");
              string firstName = Console.ReadLine();
              Console.Write("\n" + "Фамилия - ");
              string lastName = Console.ReadLine();
              library.AddReader(firstName, lastName); // Добавление читателя
              break;
            case 5:
              Console.Clear();
              Console.Write("Взятие книги, введите информацию:" + "\n" +
                                          "ID читателя - ");
              readerId = int.Parse(Console.ReadLine());
              Console.Write("\n" + "ID книги - ");
              bookId = int.Parse(Console.ReadLine());
              library.IssueBook(readerId, bookId);//Взятие книги
              break;
            case 6:
              Console.Clear();
              Console.Write("Возврат книги, введите информацию:" + "\n" +
                                          "ID читателя - ");
              readerId = int.Parse(Console.ReadLine());
              Console.Write("\n" + "ID книги - ");
              bookId = int.Parse(Console.ReadLine());
              library.ReturnBook(readerId, bookId);//Взятие книги
              break;
            case 7:
              Console.Clear();
              Console.WriteLine("Поиск книг\nВведите параметр (название, автор, жанр) - ");
              string parametr = Console.ReadLine();
              Console.WriteLine("Введите Наименование");
              string name = Console.ReadLine();
              library.FindBook(name, parametr);
              break;
            case 8:
              Console.Clear();
              Console.WriteLine("Вывод доступных и занятых книг\n");
              library.ShowBookAvailableStatus();
              break;
            case 9:
              return;
            default:
              Console.Clear();
              Console.WriteLine("Некорректный выбор, попробуйте снова.");
              break;
          }
        }
        catch
        {
          
          Console.WriteLine("Введено неверное значение.");
        }
      }
    }

  }
}