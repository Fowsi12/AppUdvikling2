namespace BlazorApp1.Logic;

public class Shop
{
    private List<Item> items;

    public Shop()
    {
        items = new List<Item>();

        Item item1 = new Item()
        {
            Name = "Bukser",
            Price = 199,
            Stock = 10,
            Color = "Blue"
        };

        Item item2 = new Item()
        {
            Name = "Bukser",
            Price = 199,
            Stock = 10,
            Color = "Blue"
        };
        
        Item item3 = new Item()
        {
            Name = "Hat",
            Price = 129,
            Stock = 0,
            Color = "Black"
        };

        Item item4 = new Item()
        {
            Name = "T-Shirt",
            Price = 229,
            Stock = 8,
            Color = "White"
        };

        Item item5 = new Item()
        {
            Name = "Sko",
            Price = 229,
            Stock = 2,
            Color = "Blue"
        };

        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public List<Item> ItemsInStock()
    {
        List<Item> itemsInStock = new List<Item>();

        foreach (Item item in items)
        {
            if (item.Stock > 0)
            {
                itemsInStock.Add(item);
            }
        }

        return itemsInStock;
    }

    public List<Item> ItemsByColor(string color)
    {
        List<Item> itemsByColor = new List<Item>();

        foreach (Item item in items)
        {
            if (item.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            {
                itemsByColor.Add(item);
            }
        }

        return itemsByColor;
    }
}