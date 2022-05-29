namespace LibraryService;

public sealed class LibraryService : ILibraryService
{

  private List<IItem> _items = new List<IItem>();

  public LibraryService() { }

  public IItem GetItem(string id)
    {
        //parts.Find(x => x.PartName.Contains("seat"));

      var foundItem = _items.Find(item => item.Id == id);
        if (foundItem == null)
        {
            throw new InvalidOperationException();
        }
        else
        { return foundItem;
        }
    }  

  public void AddItem(IItem item)
  {
        if (_items.Contains(item))
        {
            throw new InvalidOperationException();
        }
        else
        {
            _items.Add(item);
        }
  }

  public void RemoveItem(string id)
  {
    _items.Remove(GetItem(id));

  }

  public void BorrowItem(string id, Person borrower)
  {
        var book = GetItem(id); 
        if (!(book.IsAvailable()))
        {
            throw new InvalidOperationException();
        }
        else
        {
            book.BorrowItem(borrower);
        }

  }

  public void ReturnItem(string id, Person returnee)
  {
        var item = GetItem(id);
        item.ReturnItem(returnee);

  }
}
