namespace Project;

public class Assistant : Person
{
    public int moneyEarned { get; set; }
    public int nbOrderManaged { get; set; }
    
    public Assistant (int id,string name, string lastName, int phoneNumber, string address, int moneyEarned,int nbOrderManaged)
    {
        this.id = id;
        this.name = name;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.address = address;
        this.moneyEarned = moneyEarned;
        this.nbOrderManaged = nbOrderManaged;
    }
    
    
    public int incrementNumberOrder()
    {
        nbOrderManaged += 1;
        Console.Write("\nNumber of order take by the assistant is " + nbOrderManaged);
        Console.WriteLine("\n---------------------------------------------");
        return nbOrderManaged;
    }

    public async Task<string> orderInPreparationToCustomer(Order myOrder, Assistant actualAssistant)
    {
        int ms = 2000;
        if (myOrder.inPreparation)
        {
            string message = "\nMessage for client : your order is in preparation";
            //Async
            await Task.Delay(ms);
            Console.WriteLine("\nOrder request send to the asssistants room");
            await Task.Delay(ms);
            Console.WriteLine("\nOpening of the order by assistant ("+actualAssistant.name+")");
            await Task.Delay(ms);
            
            //Assistant to customer message
            Console.WriteLine("\nOrder n°"+ myOrder.orderID +" is in preparation\nAmount : "+ myOrder.orderInvoice+" euros");
            Console.WriteLine(message);
            return message;
        }
        else
        {
            string message = "your order isn't in preparation"; 
            Console.WriteLine("Opening of the order");
            await Task.Delay(ms);
            Console.WriteLine(message);
            return message;
        }
    }

    public async Task<string> preparationOrderToChef(Order myOrder, Assistant actualAssistant)
    {
        int ms = 2000;
        if (myOrder.inPreparation)
        {
            string message = "\n"+actualAssistant.name+" will now prepare the delivery";
            // asynch
            await Task.Delay(ms);
            Console.WriteLine("\nAssistant ("+actualAssistant.name+") send a message to Chef");
            await Task.Delay(ms);
            Console.WriteLine("Message sending...");
            await Task.Delay(ms);
            
            //message for the Chef
            Console.WriteLine("\nMessage Received from assistant to Chef :\nOrder n°" + myOrder.orderID +
                              "\n\nPizza present in the list :");
            for (int i = 0; i < myOrder.PizzaOList.Count; i++)
            {
               Console.WriteLine("Pizza n°"+ (i+1) +" "+myOrder.PizzaOList[i].orderItemName +" "+ myOrder.PizzaOList[i].size); 
            }
            Console.WriteLine(message);
            return message;
        }
        else
        {
            string message = "\nMessage not sent";
            Console.WriteLine("\nOpening of the order");
            await Task.Delay(ms);
            Console.WriteLine(message);
            return message;

        }
    }

    public async Task<string> preparationOrderDelivery(Order myOrder, Delivery myDelivery, Assistant actualAssistant)
    {
        int ms = 2000;
        if (myOrder.inPreparation)
        {
            string message = "\n"+myDelivery.name+" will take the Order, and wait the Chef to finish the order";
            await Task.Delay(ms);
            Console.WriteLine("\nDetails and Customer Address will be sent to "+myDelivery.name);
            await Task.Delay(ms);
            Console.WriteLine("Message sending...");
            await Task.Delay(ms);
            Thread.Sleep(ms);

            Console.WriteLine("\nMessage Received from Assistant ("+actualAssistant.name+") for the Delivery : \nOrder n°"+myOrder.orderID+"\nInvoice : " + myOrder.orderInvoice +
                              " euros & Delivery Address : "+myOrder.customerAddress +"\n");
            for (int i = 0; i < myOrder.PizzaOList.Count; i++)
            {
                Console.WriteLine("Pizza n°" + (i + 1) +" "+ myOrder.PizzaOList[i].orderItemName +" "+
                                  myOrder.PizzaOList[i].size);
            }

            for (int i = 0; i < myOrder.DrinkOList.Count; i++)
            {
                Console.WriteLine("Drink n°" + (i + 1) +" "+ myOrder.DrinkOList[i].orderItemName +" "+
                                  myOrder.DrinkOList[i].size);
            }

            Console.WriteLine(message);

            return message;
        }
        else
        {
            string message = "Details and Delivery Address not sent";
            Console.WriteLine("Opening the order");
            await Task.Delay(ms);
            Console.WriteLine(message);

            return message;
        }
    }

    public void orderStatus(Order myOrder)
        {
            Console.WriteLine("Order ID : " + myOrder.orderID);

            if (myOrder.inPreparation)
            {
                Console.WriteLine("\nOrder in preparation");
            }
            else if (myOrder.inDelivery)
            {
                Console.WriteLine("\nOrder in delivery");
            }
            else if (myOrder.closeOrder)
            {
                Console.WriteLine("\nOrder closed");
            }
        }

    public int moneyCash(System mySystem, Order myOrder)
    {
        Console.WriteLine("\nTotal Money Amount Pizzeria before actual order : " + mySystem.systemCashRegister);
        mySystem.systemCashRegister += myOrder.orderInvoice;
        Console.WriteLine("\nTotal Money Amount Pizzeria update to " + mySystem.systemCashRegister);
        return mySystem.systemCashRegister;
    }
    
    public Boolean orderClose (Order myOrder)
    {
        myOrder.closeOrder = true;
        return myOrder.closeOrder;
    }

    public Boolean orderOpen(Order myOrder)
    {
        myOrder.inPreparation = true;
        return myOrder.inPreparation;
    } 
}