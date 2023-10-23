// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            int id = 1;
            int orderid=1;
            
            
            //initialize pizzeria
            System myPizzeria = new System(1, 10000);

            // initialize deliveryBoy
            Delivery deliveryMan1 = new Delivery(id, "Frederique", "Meunier", 70, 3);
            id++;
            Delivery deliveryMan2 = new Delivery(id, "Clémentine", "Silengo", 70, 5);
            id++;

            //new list of deliveryMan and the queue correspondent 
            var deliveryManList = new List<Delivery>
            {
                deliveryMan1,
                deliveryMan2
            };

            Queue<Delivery> deliveryQueue = new Queue<Delivery>();
            deliveryQueue.Enqueue(deliveryMan1);
            deliveryQueue.Enqueue(deliveryMan2);



            // initialize Assistant
            Assistant assistant1 = new Assistant(id, "Pierre", "Caillou", 09873456, "34 rue Albert Einstein", 0, 0);
            id++;
            Assistant assistant2 = new Assistant(id, "Camille", "Briand", 0634231234, "63 rue de Mont Mirail", 34, 4);
            id++;

            //new list of Assitant
            List<Assistant> assistantList = new List<Assistant>
            {
                assistant1,
                assistant2
            };

            // initialize Chef
            Chef Chef1 = new Chef(id, "Pierrick", "Marsault");
            id++;
            Chef Chef2 = new Chef(id, "Marc", "Rougagnou");
            id++;

            //new list of Chef
            List<Chef> ChefList = new List<Chef>
            {
                Chef1,
                Chef2
            };

            // initialize Customers
            Customer customer1 = new Customer(id, "Zoé", "Niddam", 0618763236, "12 rue Marcel Pagnol", "Villejuif",
                new DateOnly(2022, 10, 13), 12, 456);
            id++;
            Customer customer2 = new Customer(id, "Jean", "Huault", 01234556, "24 rue Alfred Musset", "Dijon",
                new DateOnly(2021, 03, 22), 2, 16);
            id++;
            Customer customer3 = new Customer(id, "Elise", "Prieur", 063456789, "40 rue Milamon", "Arras",
                new DateOnly(2022, 07, 17), 7, 1);
            id++;


            //new list of customers
            List<Customer> customerList = new List<Customer>
            {
                customer1,
                customer2,
                customer3
            };
            
            //Pizza
            Pizza ClassiqueM = new Pizza(1, "M", "Classical", 25, 6);
            Pizza ClassiqueL = new Pizza(2, "L", "Classical", 30, 8);
            Pizza fromageM = new Pizza(3, "M", "fromage", 25, 6);
            Pizza fromageL = new Pizza(4, "L", "fromage", 30, 8);
            Pizza reginaM = new Pizza(5, "M", "regina", 25, 6);
            Pizza reginaL = new Pizza(6, "L", "regina", 30, 8);
           
            //new list of pizza
            List<Pizza> availablePizzaList = new List<Pizza>
            {
                ClassiqueM,
                ClassiqueL,
                fromageM,
                fromageL,
                reginaM,
                reginaL
            };
            
            //Drinks
            Drink cocaM = new Drink(1, "M", "Coca", 0, 3);
            Drink cocaL = new Drink(2, "L", "Coca", 0, 4);
            Drink iceTeaM = new Drink(3, "M", "iceTea", 0, 3);
            Drink iceTeaL = new Drink(4, "L", "iceTea", 0, 4);
            Drink vinM = new Drink(5, "M", "vin", 0, 6);
            Drink vinL = new Drink(6, "L", "vin", 0, 8);
            
            //new list of drinks
            List<Drink> availableDrinkList = new List<Drink>
            {
                cocaM,
                cocaL,
                iceTeaM,
                iceTeaL,
                vinM,
                vinL
            };

            List<Pizza> PizzaOList = new List<Pizza>(10);
            List<Drink> DrinkOList = new List<Drink>(10);

            //create 2 random orders
            Order order1 = new Order(orderid, 25, new DateTime(2022, 10, 21, 19, 35, 05), "12 rue Marcel Pagnol",
                "Villejuif", PizzaOList, DrinkOList);
            order1.closeOrder = true;
            orderid++;
            Order order2 = new Order(orderid, 32, new DateTime(2022, 10, 21, 19, 40, 55), "21 rue Alfred Musset",
                "Dijon",PizzaOList, DrinkOList);
            order2.closeOrder = true;
            orderid++;
            
            //new list of orders
            List<Order> orderList = new List<Order>
            {
                order1,
                order2
            };
            
            //waiting list
            Queue<Order> orderQueue = new Queue<Order>();
            
            Console.WriteLine("\nWelcome in our Pizzeria !");

            bool bigflag;
            do
            {
                Console.WriteLine("\n\nChoose what you want to do :\n");
                Console.WriteLine(" 1. Display the menu ");
                Console.WriteLine(" 2. Make an order");
                Console.WriteLine(" 3. Customer Module");
                Console.WriteLine(" 4. Order Module");
                Console.WriteLine(" 5. Statistics Module");
                Console.WriteLine(" 6. Stop the program");
                Console.WriteLine("\n");

                string choice;
                int number;

                do
                {
                    choice = Console.ReadLine();
                    Int32.TryParse(choice, out number);
                } while (number>6 || number<1);

                bigflag = true;
                Boolean flag;
                switch (number)
                {
                    default:
                        Console.WriteLine("break by default");
                        break;
                    
                    case 1:
                        Console.WriteLine("\nMenu :\n");
                        myPizzeria.menuPizza(availablePizzaList);
                        Console.WriteLine("\n");
                        myPizzeria.menuDrink(availableDrinkList);
                        Console.WriteLine("\n");

                        break;
                    case 2 :
                        Console.WriteLine("\nMake your order : \n");
                        int nbPizza;
                        int nbDrink;

                        do
                        {
                            Console.WriteLine("Are you a new Customer (Yes or No)");
                            choice = Console.ReadLine();

                        } while (choice!="Yes" && choice!="yes" && choice!="No" && choice!="no");

                        Customer actualCustomer;
                        int addCustomerInList = 0;
                        if (choice == "Yes" || choice == "yes")
                        {
                            actualCustomer = new Customer(id, "Soazic", "Fournier", 045678986, "23 rue de Marcel",
                                "Califonie", new DateOnly(2022, 10, 21), 0, 0);
                            id++;
                            
                            //place in the new customer information
                            actualCustomer = myPizzeria.customerModification(actualCustomer);
                            customerList.Add(actualCustomer);
                            addCustomerInList = customerList.Count - 1;
                        }

                        if (choice == "No" || choice == "no")
                        {
                            Console.WriteLine("What is your phone number :");
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out number);

                            int local = 0;
                            while (local<customerList.Count)
                            {
                                // browse a list
                                if (number == customerList[local].phoneNumber)
                                {
                                    Console.WriteLine("We found you !");
                                    Console.WriteLine("Name : " + customerList[local].name);
                                    actualCustomer = customerList[local];
                                    addCustomerInList = local;
                                }

                                local++;
                            }
                        }
                        //new order
                        Console.WriteLine("\nHow many Pizza ?");
                        do
                        {
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out nbPizza);
                        } while (nbPizza > 10 || nbPizza < 0);
                        
                        Console.WriteLine("\nHow many Drinks ?");
                        do
                        {
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out nbDrink);
                        } while (nbDrink > 10 || nbDrink < 0);
                        
                        // create the new order
                        Order newOrder = new Order(orderid, 0, DateTime.Now, "30 avenue du palace", "César", PizzaOList,
                            DrinkOList);
                        orderid++;

                        for (int j = 0; j < nbPizza; j++)
                        {
                            myPizzeria.menuPizza(availablePizzaList);
                            Console.WriteLine("\nPizza n°"+(j+1)+" :");
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out number);
                            for (int k = 0; k < availablePizzaList.Count; k++)
                            {
                                if (availablePizzaList[k].orderIdItem == number)
                                {
                                    newOrder.PizzaOList.Add(availablePizzaList[k]);
                                }
                            }
                            
                        }

                        for (int j = 0; j < nbDrink; j++)
                        {
                            myPizzeria.menuDrink(availableDrinkList);
                            Console.WriteLine("\nDrink n°"+(j+1)+" :");
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out number);
                            for (int i = 0; i < availableDrinkList.Count; i++)
                            {
                                if (availableDrinkList[i].orderIdItem == number)
                                {
                                    newOrder.DrinkOList.Add(availableDrinkList[i]);
                                }
                            }
                        }

                        newOrder.customerAddress = customerList[addCustomerInList].address;
                        
                        Console.WriteLine("\nList of items ordered :");
                        myPizzeria.pizzaList(newOrder.PizzaOList);
                        myPizzeria.drinkList(newOrder.DrinkOList);
                        
                        newOrder.setOrderPrice();
                        
                        orderList.Add(newOrder);

                        newOrder.inPreparation = assistant1.orderOpen(newOrder);

                        Delivery actualDelivery = deliveryQueue.Dequeue();
                        
                        //Send message 
                        assistant1.orderInPreparationToCustomer(newOrder);

                        assistant1.preparationOrderToChef(newOrder);

                        assistant1.preparationOrderDelivery(newOrder);
                        
                        //Chef prepare order
                        Chef1.orderPreparation(newOrder);
                        
                        // send in delivery
                        newOrder.inDelivery = actualDelivery.doDelivery(newOrder, actualDelivery);

                        actualDelivery.deliveryIsDone(newOrder);

                        actualDelivery.moneyOrder = actualDelivery.getPayment(newOrder, actualDelivery);

                        customerList[addCustomerInList].newTotalAmount(newOrder.orderInvoice);

                        myPizzeria.systemCashRegister = assistant1.moneyCash(myPizzeria, newOrder);

                        assistant1.nbOrderManaged = assistant1.incrementNumberOrder();

                        newOrder.closeOrder = assistant1.orderClose(newOrder);
                        
                        deliveryQueue.Enqueue(actualDelivery);
                        
                        break;
                    
                    case 3:
                        int number2;
                        flag = true;

                        do
                        {
                            Console.WriteLine("\nCustomer Module");
                            Console.WriteLine(" 1. display the list of customers by city   ");
                            Console.WriteLine(" 2. display the list of customers by Alpha order ");
                            Console.WriteLine(" 3. display the list of the best customers   ");
                            Console.WriteLine(" 4. return to main menu ");

                            do
                            {
                                choice = Console.ReadLine();
                                Int32.TryParse(choice, out number2);
                            } while (number2 > 4 || number2 < 1);

                            switch (number2)
                            {
                                default:
                                    Console.WriteLine("break by default");
                                    break;
                                case 1:
                                    Console.WriteLine("The list of customer by alpha order");
                                    myPizzeria.alphaOrderCustomers(customerList);
                                    break;
                                case 2:
                                    Console.WriteLine("The list of customer by city");
                                    myPizzeria.cityCustomer(customerList);
                                    break;
                                case 3:
                                    Console.WriteLine("The list of best customer ");
                                    myPizzeria.bestCustomer(customerList);
                                    break;
                                case 4:
                                    flag = false;
                                    break;
                                    
                            }
                            
                        } while (flag);
                        break;
                    
                    case 4:
                        int number3;
                        flag = true;

                        do
                        {
                            Console.WriteLine("\nOrder Module");
                            Console.WriteLine(" 1. display Order Status   ");
                            Console.WriteLine(" 2. display the price of an order according to its number   ");
                            Console.WriteLine(" 3. display a complete order according to its number   ");
                            Console.WriteLine(" 4. return to main menu ");

                            do
                            {
                                choice = Console.ReadLine();
                                Int32.TryParse(choice, out number3);

                            } while (number3 > 4 || number3 < 1);

                            switch (number3)
                            {
                                default:
                                    Console.WriteLine("break by default");
                                    break;
                                
                                case 1:
                                    Console.WriteLine("Display Order Status :   ");
                                    
                                    Console.WriteLine("Number of the order :");
                                    do
                                    {
                                        choice = Console.ReadLine();
                                        Int32.TryParse(choice, out number);
                                    } while (number < 1 || number > orderList.Count);

                                    int x = 0;
                                    while (number != orderList[x].orderID)
                                    {
                                        x++;
                                    }
                                    assistant1.orderStatus(orderList[x]);
                                    break;
                                case 2 :
                                    Console.WriteLine(" The price of an order according to its number :   ");
                                    Console.WriteLine("Number of order : ");

                                    do
                                    {
                                        choice = Console.ReadLine();
                                        Int32.TryParse(choice, out number);
                                    } while (number < 1 || number > orderList.Count);

                                    int z = 0;
                                    while (number !=orderList[z].orderID)
                                    {
                                        z++;
                                    }
                                    Console.WriteLine("Price of order :"+ number + "->" + orderList[z].orderInvoice + "euros");
                                    break;
                                
                                case 3:
                                    Console.WriteLine("A complete order by its number :   ");
                                    Console.WriteLine("Number of order : ");
                                    do
                                    {
                                        choice = Console.ReadLine();
                                        Int32.TryParse(choice, out number);
                                    } while (number < 1 || number > orderList.Count);

                                    int a = 0;
                                    while (number != orderList[a].orderID)
                                    {
                                        a++;
                                    }
                                    orderList[a].displayOrder();
                                    break;
                                case 4:
                                    flag = false;
                                    break;
                            }

                            
                        } while (flag);
                        
                        break;
                    
                    case 5 :
                        int number4;
                        flag = true;
                        do
                        {
                            Console.WriteLine("\nStatistics Module");
                            Console.WriteLine(" 1. display the number of orders managed by clerk :   ");
                            Console.WriteLine(" 2. display the number of deliveries per delivery man :   ");
                            Console.WriteLine(" 3. display the average price of orders  :   ");
                            Console.WriteLine(" 4. display the average of the customer accounts (Total Order Amounts) :   ");
                            Console.WriteLine(" 5. return to main menu ");
                            
                            do
                            {
                                choice = Console.ReadLine();
                                Int32.TryParse(choice, out number4);
                            } while (number4 > 5 || number4 < 1);

                            switch (number4)
                            {
                                default:
                                    Console.WriteLine("break by default");
                                    break;
                                
                                case 1:
                                    Console.WriteLine("Number of order managed");
                                    for (int k = 0; k < assistantList.Count; k++)
                                    {
                                        Console.WriteLine("Assistant n° :"+assistantList[k].id+assistantList[k].nbOrderManaged);
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("number of deliveries per deliveryBoy : ");
                                    for (int i = 0; i < deliveryManList.Count; i++)
                                    {
                                        Console.WriteLine("DeliveryBoy :"+deliveryManList[i].id + deliveryManList[i].deliveryNumber + "deliveries");
                                    }
                                    break;
                                case 3 :
                                    Console.WriteLine("The average amount of  orders  :   ");
                                    myPizzeria.averageOrderAmount(orderList);
                                    break;
                                case 4:
                                    Console.WriteLine("The average customer accounts (Total Order Amounts) :   ");
                                    myPizzeria.averageTotalAmountCustomerOrder(customerList);
                                    break;
                                case 5:
                                    flag = false;
                                    break;
                                    
                                    
                            }
                            
                        } while (flag);
                        
                        break;
                    
                    case 6:
                        
                        Console.WriteLine(" 16. stop the program ");
                        bigflag = false;
                        Environment.Exit(0);
                        
                        break;
                }
            } while(bigflag);
            Console.WriteLine("Thank you !");
            Environment.Exit(0);
        }
    }
}

