using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
  internal class Reader
  {
    private static int _ID = 1;
    private string firstName; //Имя
    public string FirstName
    {
      get { return firstName; }
      set
      {
        // Сюда проверки на корректность нового значения
        firstName = value;
      }
    }

    private string lastName; //Фамилия
    public string LastName
    {
      get { return lastName; }
      set
      {
        // Сюда проверки на корректность нового значения
        lastName = value;
      }
    }

    public int ID { get; private set; } //id читателя

    private List<int> BorrowedBooksIDs; //список id взятых книг

    //комментарий для конструктора,
    //при создании нового экземпляра в ID класть _ID,
    //_ID после этого увеличить
  }
}
