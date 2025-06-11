using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
  internal class Library
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
    private Dictionary<int, Book> Books; //библиотека книг, id - ключ
    private Dictionary<int, Reader> Readers; //библиотека читателей, id - ключ
  }
}
