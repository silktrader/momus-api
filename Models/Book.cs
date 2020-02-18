using System;

namespace Momus
{
  public class Book
  {
    public int Id { get; set; }
    public string Isbn { get; set; }

    public string Author { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public int? Words { get; set; }
    public string Language { get; set; }
    public string Cover { get; set; }

    public DateTime? Published { get; set; }
    public DateTime? Started { get; set; }
    public DateTime? Finished { get; set; }
    public DateTime? Reviewed { get; set; }

    public int? Rating { get; set; }
    public int? Hours { get; set; }
  }
}
