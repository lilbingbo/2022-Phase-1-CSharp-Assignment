using System.Collections;
namespace LibraryService;

public class Video : IItem
{
  public string Id { get; }
  private string Title;
  private string Producer;
  private int Copies;
  private List<Person> Borrowers = new List<Person>();

  public Video(string barcode, string title, string producer, int copies)
  {
    Id = barcode;
    Title = title;
    Producer = producer;
    Copies = copies;
  }

  public void BorrowItem(Person borrower)
  {
   if (IsAvailable() & !(Borrowers.Contains(borrower)))
        {
            Borrowers.Add(borrower);
        }
   else
        {
            throw new InvalidOperationException();
        }
  }

  public void ReturnItem(Person returnee)
  {
        var foundBorrower = Borrowers.Find(borrower => borrower == returnee);
        if (foundBorrower == null)
        {
            throw new InvalidOperationException();
        }
        else
        {
            Borrowers.Remove(returnee);
        }
    }

  public override string ToString()
  {
    return $"VIDEO - {Title} by {Producer}";
  }

  public bool IsAvailable()
  {
    return Borrowers.Count < Copies;
  }
}
