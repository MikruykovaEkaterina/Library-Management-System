using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

    public Reader(string firstName, string lastName)
    {
      this.ID = _ID;
      _ID++;
      FirstName = firstName;
      LastName = lastName;
      BorrowedBooksIDs = new List<int>();
    }

    public override string ToString()
    {
      string borrowedBooks = string.Join(", ", BorrowedBooksIDs);
      return $"ID {ID}, имя: '{FirstName}', фамилия: '{LastName}', список ID взятых книг: {borrowedBooks}";
    }

    public void AddBookIdToBorrowedBooks(int bookId)
    {
      BorrowedBooksIDs.Add(bookId);
    }

    public bool CheckIfBookIdIsBorrowed(int bookId)
    {
      return BorrowedBooksIDs.Contains(bookId);
    }

    public void RemoveBookIdFromBorrowedBooks(int bookId)
    {
      BorrowedBooksIDs.Remove(bookId);
    }
  }
}
