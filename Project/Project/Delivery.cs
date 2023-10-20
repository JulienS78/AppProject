using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project;

public class Delivery : Personn
{
    public int deliveryID{ get; set; }
    public int moneyOrder { get; set; }
    public int deliveryNumber { get; set; }

    public Delivery(int deliveryID,string name, string lastName, int moneyOrder, int deliveryNumber)
    {
        this.deliveryID = deliveryID;
        this.name = name;
        this.lastName = lastName;
        this.moneyOrder = moneyOrder;
        this.deliveryNumber = deliveryNumber;
    }

    public Boolean doDelivery(Order myOrder, Delivery myDelivery)
    {
        Console.WriteLine("Order is ready, it will be delivery soon ");
        myOrder.inDelivery = true;

        myDelivery.deliveryNumber += 1;
        Console.WriteLine("Number of delivery done by the deliveryMan " +myDelivery.name +" : "+ myDelivery.deliveryNumber);
        return myOrder.inDelivery;
    }

    public int getPayment(Order myOrder, Delivery myDelivery)
    {
        myDelivery.moneyOrder += myOrder.orderInvoice;
        Console.WriteLine("Money Order Delivery by "+ myDelivery.name +" : "+ myDelivery.moneyOrder );
        return myDelivery.moneyOrder;

    }
    
    //message when order is delivered
    public async Task<string> deliveryIsDone(Order myOrder)
    {
        int ms = 2000;
        if (myOrder.inDelivery)
        {
            string message = "\nDelivery is done";
            Console.WriteLine("\nSend delivery Address");
            await Task.Delay(ms);
            Console.WriteLine("\nMessage is sending");
            await Task.Delay(ms);
            Console.WriteLine("\nDelivery in progress");
            await Task.Delay(ms);
            
            Console.WriteLine("\nMessage Delivery is done for : \nOrder n°"+myOrder.orderID+ "\nAddress : " + myOrder.customerAddress + "\n\nList of items :");
            for (int i = 0; i < myOrder.PizzaOList.Count; i++)
            {
                Console.WriteLine("Pizza n°"+(i+1)+ " is "+myOrder.PizzaOList[i].orderItemName);
            }
            for (int i = 0; i < myOrder.DrinkOList.Count; i++)
            {
                Console.WriteLine("Drink n°"+(i+1)+" is "+myOrder.DrinkOList[i].orderItemName);
            }
            Console.WriteLine(message);

            return message;
        }

        else
        {
            string message = "\nOrder not delivered yet !";
            Console.WriteLine("\nSearching for the delivery Address");
            await Task.Delay(ms);
            Console.WriteLine(message);

            return message;
        }


    }
}