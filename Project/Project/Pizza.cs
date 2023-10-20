using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project;

public class Pizza : Menu
{
  public int orderIdItem { get; set; }
  public string size { get; set; }
  public string orderItemName { get; set; }
  public int preparationTime{ get; set; }
  public int orderItemPrice { get; set; }
  

  public Pizza(int orderIdItem, string size, string orderItemName, int preparationTime, int orderItemPrice)
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