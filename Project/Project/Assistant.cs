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
    
    //increment number order managed
    public int incrementNumberOrder()
    {
        nbOrderManaged += 1;
        Console.Write("Number of order take by the assistant is " + nbOrderManaged);
        return nbOrderManaged;
    }

    public async Task<string> orderInPreparationToCustomer(Order myOrder)
    {
        int ms = 2000;
        if (myOrder.inPreparation)
        {
            string message = "your order is in preparation";
            //Async
            Console.WriteLine("Opening of the order");
            await Task.Delay(ms);
            Console.WriteLine("Message sending");
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

    public async Task<string> preparationOrderToChef(Order myOrder)
    {
        int ms = 2000;
        if (myOrder.inPreparation)
        {
            string message = "\nDetails of the order";
            // asynch
            Console.WriteLine("Opening of the order");
            await Task.Delay(ms);
            Console.WriteLine("Message sending");
            await Task.Delay(ms);
            
            //message for the Chef
            Console.WriteLine("\nMessage from assistant to Chef :\nOrder n°" + myOrder.orderID +
                              "\n\nItem present in the list :");
            for (int i = 0; i < myOrder.PizzaOList.Count; i++)
            {
               Console.WriteLine("Item n°"+ (i+1) +" "+myOrder.PizzaOList[i].orderItemName +" "+ myOrder.PizzaOList[i].size); 
            }
            Console.WriteLine(message);
            return message;
        }
        else
        {
            string message = "\nmessage not sent";
            Console.WriteLine("\nOpening of the order");
            await Task.Delay(ms);
            Console.WriteLine(message);
            return message;

        }
    }

    public async Task<string> preparationOrderDelivery(Order myOrder)
    {
        int ms = 2000;
        if (myOrder.inPreparation)
        {
            string message = "\nDetails and Customer Address sent";
            Console.WriteLine("\nOpening of the order");
            await Task.Delay(ms);
            Console.WriteLine("\nMessage is sending");
            await Task.Delay(ms);

            Thread.Sleep(ms);

            Console.WriteLine("\nMessage to Delivery : \nOrder n°"+myOrder.orderID+"\nInvoice : " + myOrder.orderInvoice +
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
            else if (myOrder.lostOrder)
            {
                Console.WriteLine("\nOrder lost");
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

    public Boolean orderLost(Order myOrder)
    {
        myOrder.lostOrder = true;
        return myOrder.lostOrder;
    }

    public int orderCashed(Order myOrder, Assistant myAssistant)
    {
        myAssistant.moneyEarned += myOrder.orderInvoice;
        Console.WriteLine("Assistant : " + myAssistant.name + "cashed " + myOrder.orderInvoice + " euros" );
        Console.WriteLine("Assistant : " + myAssistant.name + " has cashed " + myAssistant.moneyEarned + " euros" );
        return myAssistant.moneyEarned;
    }

    public int orderLost(Order myOrder, Assistant myAssistant)
    {
        myAssistant.moneyEarned -= myOrder.orderInvoice;
        Console.WriteLine("Assistant : " + myAssistant.name + "has lost " + myOrder.orderInvoice + " euros" );
        Console.WriteLine("Assistant : " + myAssistant.name + "has lost in total " + myAssistant.moneyEarned + " euros" );
        return myAssistant.moneyEarned;
    }

    public int updatePizzeriaAccount(System mySystem, Assistant myAssistant)
    {
        mySystem.systemCashRegister += myAssistant.moneyEarned;
        Console.WriteLine("box : " + mySystem.systemCashRegister);
        return mySystem.systemCashRegister;
    }  
        
    
}