using Library;

namespace Library_Test;

using System;

  class Program
  {
        static void Main(string[] args)
        {
            Library library = new Library();
            
            while (true)
            {
                Console.WriteLine( "\n" + "Меню библиотеки:" + "\n" +
                                   "1. Добавить книгу"+ "\n" +
                                   "2. Удалить книгу"+ "\n" +
                                   "3. Изменить информацию о книге"+ "\n" +
                                   "4. Выйти из библиотеки");
            
                int menyitem = int.Parse(Console.ReadLine());
                
                try
                {
                    switch (menyitem)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Добавление книги, введите информацию:"+ "\n" +
                                  "Название - ");
                            string title = Console.ReadLine();
                            Console.Write( "\n" + "Автор - ");
                            string author = Console.ReadLine();
                            Console.Write( "\n" + "Год издания - ");
                            int year = int.Parse(Console.ReadLine());
                            Console.Write( "\n" + "Жанр - ");
                            string genre = Console.ReadLine();
                            library.AddBook(title, author, year, genre); // Добавление книги
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("Удаление книги, введите информацию:"+ "\n" +
                                          "ID книги - ");
                            int id = int.Parse(Console.ReadLine());
                            library.RemoveBook(id); // Удаление книги из библиотеки
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Редактирование данных книги, введите информацию:"+ "\n" +
                                  "ID книги - ");
                            int idbook = int.Parse(Console.ReadLine());
                            Console.Write( "\n" + "Новое название - ");
                            string titlenew = Console.ReadLine();
                            Console.Write( "\n" + "Новый автор - ");
                            string authornew= Console.ReadLine();
                            Console.Write( "\n" + "Новый год издания - ");
                            int yearnew = int.Parse(Console.ReadLine());
                            Console.Write( "\n" + "Новый жанр - ");
                            string genrenew = Console.ReadLine();
                            library.EditBook(idbook, titlenew, authornew, yearnew, genrenew); // Редактирование книги
                            break;
                        case 4:
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
                    Console.ReadLine();
                }
            }
        }
  }
