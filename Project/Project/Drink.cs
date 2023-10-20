namespace Project;

public class Drink : Menu
{
    public int orderIdItem { get; set; }
    public string size { get; set; }
    public string orderItemName { get; set; }
    public int preparationTime{ get; set; }
    public int orderItemPrice { get; set; }

    public Drink(int orderIdItem, string size, string orderItemName, int preparationTime, int orderItemPrice)
    {
        this.orderIdItem = orderIdItem;
        this.size = size;
        this.orderItemName = orderItemName;
        this.preparationTime = preparationTime;
        this.orderItemPrice = orderItemPrice;
    }

    public void displayMenu()
    {
        Console.WriteLine(orderIdItem + ". " + orderItemName + " " + size);
    }
}

