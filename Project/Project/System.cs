using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project;

public class System
{
    public int systemID { get; set; }
    public int systemCashRegister{ get; set; }

    public System(int systemId, int systemCashRegister)
    {
        systemID = systemId;
        this.systemCashRegister = systemCashRegister;
    }

    public void menuPizza(List<Pizza> myPizza)
    {
        Console.WriteLine("\nList of pizza available :\n");
        for (int i = 0; i < myPizza.Count; i++)
        {
           myPizza[i].displayMenu(); 
        }
    }

    public void pizzaList(List<Pizza> myPizza)
    {
        for (int i = 0; i < myPizza.Count; i++)
        {
            Console.WriteLine("Item id : "+ myPizza[i].orderIdItem);
            Console.WriteLine("Item name : "+ myPizza[i].orderItemName);
            Console.WriteLine("Item price : " + myPizza[i].orderItemPrice);
            Console.WriteLine("Item size : " + myPizza[i].size);
            Console.WriteLine("Item time preparation (in min) : " + myPizza[i].preparationTime);
            Console.WriteLine("\n");
        }
    }
    
    public void menuDrink(List<Drink> myDrink)
    {
        Console.WriteLine("\nList of drinks available :\n");
        for (int i = 0; i < myDrink.Count; i++)
        {
            myDrink[i].displayMenu(); 
        }
    }
    
    public void drinkList(List<Drink> myDrink)
    {
        for (int i = 0; i < myDrink.Count; i++)
        {
            Console.WriteLine("Item id : "+ myDrink[i].orderIdItem);
            Console.WriteLine("Item name : "+ myDrink[i].orderItemName);
            Console.WriteLine("Item price : " + myDrink[i].orderItemPrice);
            Console.WriteLine("Item size : " + myDrink[i].size);
            Console.WriteLine("\n");
        }
    }
    
    //Display Customer by criters 

    public List<Customer> alphaOrderCustomers(List<Customer> myCustomerList)
    {
        List<Customer> sortedList = myCustomerList.OrderBy(Customer => Customer.name, StringComparer.OrdinalIgnoreCase).ToList();
        return sortedList;
    }

    public void cityCustomer(List<Customer> myCustomerList)
    {
        var list = myCustomerList.OrderBy(x => x.customerCity).ToList();
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine("Customer : " + list[i].name + " at " + list[i].customerCity);
        }
    }

    public void bestCustomer(List<Customer> myCustomerList)
    {
        List<Customer> copyList = new List<Customer>(myCustomerList);
        List<Customer> copyList2 = new List<Customer>(myCustomerList);

        for (int i = 0; i < (copyList.Count)-1; i++)
        {
            int ascending = 0;
            if (copyList[i + 1].totalAmount > copyList[i].totalAmount)
            {
                copyList2[ascending] = copyList[i + 1];
                ascending++;
                
            }
        }

        for (int i = 0; i < copyList2.Count; i++)
        {
            Console.WriteLine("Customer : " + copyList2[i].name + copyList2[i].totalAmount);
        }
    }

    public void averageOrderAmount(List<Order> orderList)
    {
        int start = 0;
        for (int i = 0; i < orderList.Count; i++)
        {
            start += orderList[i].orderInvoice;
        }

        start = start / orderList.Count;
        Console.WriteLine("Invoice : " + start);
    }

    public void averageTotalAmountCustomerOrder(List<Customer> customerList)
    {
        int avg = 0;
        for (int i = 0; i < customerList.Count; i++)
        {
            avg += customerList[i].totalAmount;
        }

        avg = avg / customerList.Count;
        Console.WriteLine("The average amount of  orders is  : " + avg);
    }

    public Customer customerModification(Customer myCustomer)
    {
        string choice;
        int nb;
        
        Console.WriteLine("\nName :");
        choice = Console.ReadLine();
        myCustomer.name = choice;
        
        Console.WriteLine("\nPhone Number :");
        choice = Console.ReadLine();
        Int32.TryParse(choice, out nb);
        myCustomer.phoneNumber = nb;
        
        Console.WriteLine("\nAddress :");
        choice = Console.ReadLine();
        myCustomer.address = choice;
        
        Console.WriteLine("\nCity :");
        choice = Console.ReadLine();
        myCustomer.customerCity = choice;

        return myCustomer;
    }
}