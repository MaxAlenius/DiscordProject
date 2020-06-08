using System;
using System.Threading.Tasks;

public class ItemService
{
	public interface IItemService
    {
		Task<Item> GetItemByName(string ItemName);
    }

	public class ItemService
	{
	}
}
