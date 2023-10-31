using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project;

public class Order
{
    public int orderID = 1;
    public int orderInvoice { get; set; }
    public DateTime orderDateTime { get; set; }
    public string customerAddress { get; set; }
    public  string customerCity { get; set; }

    public List<Pizza> PizzaOList;
    public List<Drink> DrinkOList;
    public Boolean inPreparation { get; set; }
    public Boolean inDelivery { get; set; }
    public Boolean closeOrder { get; set; }
    public Boolean lostOrder { get; set; }

    public Order(int orderID, int orderInvoice, DateTime orderDateTime, string customerAddress, string customerCity,List<Pizza> PizzaOList,List<Drink> DrinkOList)
    {
        this.orderID = orderID;
        this.orderInvoice = orderInvoice;
        this.orderDateTime = orderDateTime;
        this.customerAddress = customerAddress;
        this.customerCity = customerCity;
        this.PizzaOList = PizzaOList;
        this.DrinkOList = DrinkOList;
        inPreparation = false;
        inDelivery = false;
        closeOrder = false;
        lostOrder = false;
    }
    
    //increment number of order


    public void displayOrder()
    {
        Console.WriteLine("\nOrder n°" + orderID +" :");
        Console.WriteLine(" Order price : " + orderInvoice + " euros");
        Console.WriteLine(" Order date and time : " + orderDateTime);
        Console.WriteLine(" Order address : " + customerAddress +", "+ customerCity);

        for (int i = 0; i < PizzaOList.Count; i++)
        {
            Console.WriteLine("Pizza: " + (i+1));
            PizzaOList[i].displayMenu();
        }

        for (int i = 0; i < DrinkOList.Count; i++)
        {
            Console.WriteLine("Drink: "+(i+1));
            DrinkOList[i].displayMenu();
        }
    }

    public void setOrderPrice()
    {
        for (int i = 0; i < PizzaOList.Count; i++)
        {
            orderInvoice += PizzaOList[i].orderItemPrice;
        }
        for (int i = 0; i < DrinkOList.Count; i++)
        {
            orderInvoice += DrinkOList[i].orderItemPrice;
        }
        Console.WriteLine("\nOrder ID: " + orderID + "\nOrder Invoice: " + orderInvoice + " euros" );
        
    }

}