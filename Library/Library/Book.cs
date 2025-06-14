using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
  internal class Book
  {
    static private int _ID = 1;
    private string title; //название
    public string Title
    {
      get { return title; }
      set
      {
        // Сюда проверки на корректность нового значения
        title = value;
      }
    }

    private string author; //автор
    public string Author
    {
      get { return author; }
      set
      {
        // Сюда проверки на корректность нового значения
        author = value;
      }
    }

    private string year; //год
    public string Year
    {
      get { return year; }
      set
      {
        // Сюда проверки на корректность нового значения
        year = value;
      }
    }

    private string genre; //жанр
    public string Genre
    {
      get { return genre; }
      set
      {
        // Сюда проверки на корректность нового значения
        genre = value;
      }
    }
    public bool IsAvailable { get; set; } //статус
    public int ID { get; private set; } //id книги
    
    //Хранение информации в виде строки
    public Book(int id, string title, string author, int year, string genre)
    {
      ID = id;
      Title = title;
      Author = author;
      Year = year;
      Genre = genre;
      IsAvailable = true;
    }

    public override string ToString()
    {
      return $"ID: {ID}, название: '{Title}', автор: '{Author}', год издания: {Year}, жанр: '{Genre}' - статус: {(IsAvailable ? "доступна" : "взята")}";
    }
  }
  //комментарий для конструктора,
  //при создании нового экземпляра в ID класть _ID,
  //_ID после этого увеличить

}
