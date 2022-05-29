namespace LibraryService;

public class Book : IItem
{
    public string Id { get; }
    private string Title;
    private string Author;
    private Person? Borrower;
    //the next line is the constructor for the Book class
    public Book(string isbn, string title, string author)
    {
        Id = isbn;
        Title = title;
        Author = author;
    }
    //Override the tostring method
    public override string ToString()
    {
        return $"BOOK - {Title} by {Author}";
    }
    //creating a new method called BorrowItem that returns nothing
    public void BorrowItem(Person borrower)
    {
        if (IsAvailable())
        {
            Borrower = borrower;
        }
        else
        { 
            throw new InvalidOperationException(); 
        }
    }

    public void ReturnItem(Person returnee)
    {
        //check if borrower is returnee, if true, set Borrower to null 
        if (Borrower == returnee)
        {
            Borrower = null;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public bool IsAvailable()
    {
        return Borrower == null;
    }
}
