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
        static async Task Main(string[] args)
        {
            int id = 1;
            int orderid=1;
            
            //Pizzeria
            System myPizzeria = new System(1, 7000);

            //Chef
            Chef Chef1 = new Chef(id, "Philippe", "Etchebest");
            id++;
            Chef Chef2 = new Chef(id, "Alain", "Ducasse");
            id++;

            //List of Chef
            List<Chef> ChefList = new List<Chef>
            {
                Chef1,
                Chef2
            };

            CircularQueue<Chef> ChefQueue = new CircularQueue<Chef>();
            ChefQueue.Enqueue(Chef1);
            ChefQueue.Enqueue(Chef2);


            //Assistant
            Assistant assistant1 = new Assistant(id, "Sacha", "Ketchum", 0717172727, "6 Avenue du Bourg-Palette", 42, 2);
            id++;
            Assistant assistant2 = new Assistant(id, "Lara", "Croft", 0818182828, "Great North Rd., Hatfield AL9 5HX", 65, 3);
            id++;

            //List of Assitant
            List<Assistant> assistantList = new List<Assistant>
            {
                assistant1,
                assistant2
            };

            CircularQueue<Assistant> AssistantQueue = new CircularQueue<Assistant>();
            AssistantQueue.Enqueue(assistant1);
            AssistantQueue.Enqueue(assistant2);

            //DeliveryMan
            Delivery deliveryMan1 = new Delivery(id, "Oh Lee", "Chit", 65, 3);
            id++;
            Delivery deliveryMan2 = new Delivery(id, "Lodi", "Bidon", 82, 5);
            id++;

            //List of deliveryMan  
            var deliveryManList = new List<Delivery>
            {
                deliveryMan1,
                deliveryMan2
            };

            CircularQueue<Delivery> deliveryQueue = new CircularQueue<Delivery>();
            deliveryQueue.Enqueue(deliveryMan1);
            deliveryQueue.Enqueue(deliveryMan2);

            //Customers
            Customer customer1 = new Customer(id, "Etienne", "Gaillard", 0618763236, "21 Rue de Goldenkin", "GenV",
                new DateOnly(2023, 10, 29), 12, 263);
            id++;
            Customer customer2 = new Customer(id, "Léo", "Amiot", 01234556, "53 Rue du joker", "Arkam City",
                new DateOnly(2023, 09, 14), 10, 248);
            id++;
            Customer customer3 = new Customer(id, "Julien", "Starck", 063456789, "5 Rue de Woopy", "Listembourg",
                new DateOnly(2023, 08, 21), 11, 305);
            id++;

            //List of customers
            List<Customer> customerList = new List<Customer>
            {
                customer1,
                customer2,
                customer3
            };
            
            //Pizza
            Pizza Margherita_M = new Pizza(1, "M", "Margherita", 25, 6);
            Pizza Margherita_L = new Pizza(2, "L", "Margherita", 30, 8);
            Pizza QuatrosFromagi_M = new Pizza(3, "M", "QuatrosFromagi", 25, 8);
            Pizza QuatrosFromagi_L = new Pizza(4, "L", "QuatrosFromagi", 30, 10);
            Pizza Regina_M = new Pizza(5, "M", "Regina", 25, 7);
            Pizza Regina_L = new Pizza(6, "L", "Regina", 30, 9);
            Pizza Calzone_M = new Pizza(7, "M", "Calzone", 25, 9);
            Pizza Calzone_L = new Pizza(8, "L", "Calzone", 30, 11);
            
            //List of pizza
            List<Pizza> availablePizzaList = new List<Pizza>
            {
                Margherita_M,
                Margherita_L,
                QuatrosFromagi_M,
                QuatrosFromagi_L,
                Regina_M,
                Regina_L,
                Calzone_M,
                Calzone_L
            };
            
            //Drinks
            Drink cocaZ_M = new Drink(1, "M", "Coca Zero", 0, 3);
            Drink cocaZ_L = new Drink(2, "L", "Coca Zero", 0, 4);
            Drink cocaC_M = new Drink(3, "M", "Coca Cherry", 0, 3);
            Drink cocaC_L = new Drink(4, "L", "Coca Cherry", 0, 4);
            Drink Oasis_M = new Drink(5, "M", "Oasis", 0, 3);
            Drink Oasis_L = new Drink(6, "L", "Oasis", 0, 4);
            Drink FuzeTea_M = new Drink(7, "M", "FuzeTea", 0, 3);
            Drink FuzeTea_L = new Drink(8, "L", "FuzeTea", 0, 4);
            
            
            //List of drinks
            List<Drink> availableDrinkList = new List<Drink>
            {
                cocaZ_M,
                cocaZ_L,
                cocaC_M,
                cocaC_L,
                Oasis_M,
                Oasis_L,
                FuzeTea_M,
                FuzeTea_L
            };

            List<Pizza> PizzaOList = new List<Pizza>(10);
            List<Drink> DrinkOList = new List<Drink>(10);

            //Random Orders
            Order order1 = new Order(orderid, 25, new DateTime(2023, 10, 28, 12, 31, 45), "4 Rue des Lilas",
                "Sarcelles", PizzaOList, DrinkOList);
            order1.closeOrder = true;
            orderid++;
            Order order2 = new Order(orderid, 32, new DateTime(2023, 10, 29, 20, 12, 37), "54bis Avenue d'Eren Yeager",
                "Maria",PizzaOList, DrinkOList);
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
            
            Console.WriteLine("\nWelcome in our Pizzeria del Zinzini !");

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
                            actualCustomer = new Customer(id, "Tony", "Stark", 0130003000, "10 rue de l'homme de fer",
                                "Califonie", new DateOnly(2022, 10, 21), 0, 0);
                            id++;
                            
                            //place in the new customer information
                            actualCustomer = myPizzeria.customerModification(actualCustomer);
                            customerList.Add(actualCustomer);
                            addCustomerInList = customerList.Count - 1;
                        }

                        if (choice == "No" || choice == "no")
                        {
                            Console.WriteLine("\nWhat is your phone number :");
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out number);

                            int local = 0;
                            while (local<customerList.Count)
                            {
                                
                                if (number == customerList[local].phoneNumber)
                                {
                                    Console.WriteLine("\nWe found you !");
                                    Console.WriteLine("\nName : " + customerList[local].name);
                                    actualCustomer = customerList[local];
                                    addCustomerInList = local;
                                }

                                local++;
                            }
                        }
                        //new order
                        Console.WriteLine("\n---------------------------------------------");
                        Console.WriteLine("\nHow many Pizza ?");
                        do
                        {
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out nbPizza);
                        } while (nbPizza > 10 || nbPizza < 0);

                        Console.WriteLine("\n---------------------------------------------");
                        Console.WriteLine("\nHow many Drinks ?");
                        do
                        {
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out nbDrink);
                        } while (nbDrink > 10 || nbDrink < 0);
                        
                        
                        // create the new order
                        Order newOrder = new Order(orderid, 0, DateTime.Now, "3 rue des Potiers", "Cissé", PizzaOList,
                            DrinkOList);
                        orderid++;

                        Console.WriteLine("\n---------------------------------------------");
                        for (int j = 0; j < nbPizza; j++)
                        {
                            
                            myPizzeria.menuPizza(availablePizzaList);
                            Console.WriteLine("\nPizza n°" + (j + 1) + " :");
                            
                            int pizzaChoice;
                            bool isValidChoice = false;

                            do
                            {
                                string input = Console.ReadLine();

                                if (Int32.TryParse(input, out pizzaChoice))
                                {
                                    if (availablePizzaList.Any(pizza => pizza.orderIdItem == pizzaChoice))
                                    {
                                        isValidChoice = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Choix invalide. Veuillez entrer un numéro de pizza valide.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrée non valide. Veuillez entrer un numéro de pizza valide.");
                                }
                            } while (!isValidChoice);

                            for (int k = 0; k < availablePizzaList.Count; k++)
                            {
                                if (availablePizzaList[k].orderIdItem == pizzaChoice)
                                {
                                    newOrder.PizzaOList.Add(availablePizzaList[k]);
                                }
                            }
                        }
                        Console.WriteLine("\n---------------------------------------------\n");
                        for (int j = 0; j < nbDrink; j++)
                        {
                            
                            myPizzeria.menuDrink(availableDrinkList);
                            Console.WriteLine("\nDrink n°" + (j + 1) + " :");
                            
                            int drinkChoice;
                            bool isValidChoice = false;

                            do
                            {
                                
                                string input = Console.ReadLine();

                                if (Int32.TryParse(input, out drinkChoice))
                                {
                                    if (availableDrinkList.Any(drink => drink.orderIdItem == drinkChoice))
                                    {
                                        isValidChoice = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Choix invalide. Veuillez entrer un numéro de pizza valide.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrée non valide. Veuillez entrer un numéro de pizza valide.");
                                }
                            } while (!isValidChoice);

                            for (int k = 0; k < availableDrinkList.Count; k++)
                            {
                                if (availableDrinkList[k].orderIdItem == drinkChoice)
                                {
                                    newOrder.DrinkOList.Add(availableDrinkList[k]);
                                }
                            }
                        }
                        Console.WriteLine("\n---------------------------------------------");

                        newOrder.customerAddress = customerList[addCustomerInList].address;
                        newOrder.customerCity = customerList[addCustomerInList].customerCity;
                        
                        Console.WriteLine("\nList of items ordered :");
                        myPizzeria.pizzaList(newOrder.PizzaOList);
                        myPizzeria.drinkList(newOrder.DrinkOList);
                        Console.WriteLine("\n---------------------------------------------");

                        newOrder.setOrderPrice();
                        Console.WriteLine("\n---------------------------------------------");

                        orderList.Add(newOrder);

                        newOrder.inPreparation = assistant1.orderOpen(newOrder);

                        Delivery actualDelivery = deliveryQueue.Dequeue();
                        Chef actualChef = ChefQueue.Dequeue();
                        Assistant actualAssistant = AssistantQueue.Dequeue();

                        //Send message 
                        await assistant1.orderInPreparationToCustomer(newOrder, actualAssistant);
                        Console.WriteLine("\n---------------------------------------------");

                        await assistant1.preparationOrderToChef(newOrder, actualAssistant);
                        Console.WriteLine("\n---------------------------------------------");

                        await assistant1.preparationOrderDelivery(newOrder, actualDelivery, actualAssistant);
                        Console.WriteLine("\n---------------------------------------------");

                        //Chef prepare order
                        await Chef1.orderPreparation(newOrder, actualChef);
                        Console.WriteLine("\n---------------------------------------------");

                        // send in delivery
                        newOrder.inDelivery = await actualDelivery.doDelivery(newOrder, actualDelivery);
                        Console.WriteLine("\n---------------------------------------------");

                        await actualDelivery.deliveryIsDone(newOrder);
                        Console.WriteLine("\n---------------------------------------------");

                        newOrder.inPreparation = false;
                        newOrder.inDelivery = false;
                        
                        actualDelivery.moneyOrder = actualDelivery.getPayment(newOrder, actualDelivery);

                        customerList[addCustomerInList].newTotalAmount(newOrder.orderInvoice);

                        myPizzeria.systemCashRegister = actualAssistant.moneyCash(myPizzeria, newOrder);

                        actualAssistant.nbOrderManaged = actualAssistant.incrementNumberOrder();

                        newOrder.closeOrder = actualAssistant.orderClose(newOrder);
                        
                        
                        
                        break;
                    
                    case 3:
                        int number2;
                        flag = true;

                        do
                        {
                            Console.WriteLine("\nCustomer Module\n");
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
                                    Console.WriteLine("The list of customer by city :\n");
                                    myPizzeria.cityCustomer(customerList);
                                    break;
                                case 2:
                                    Console.WriteLine("The list of customer by alpha order :\n");
                                    myPizzeria.alphaOrderCustomers(customerList);
                                    break;
                                case 3:
                                    Console.WriteLine("The list of best customer :\n");
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
                                    Console.WriteLine("\nThe price of an order according to its number :   ");
                                    Console.WriteLine("Number of the order : ");

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
                                    Console.WriteLine("\nPrice of the order "+ number + " is " + orderList[z].orderInvoice + " euros");
                                    break;
                                
                                case 3:
                                    Console.WriteLine("\nA complete order by its number :   ");
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
                            Console.WriteLine(" 1. display the number of orders managed by asssistant ");
                            Console.WriteLine(" 2. display the number of deliveries per delivery man");
                            Console.WriteLine(" 3. display the average price of orders");
                            Console.WriteLine(" 4. display the average of the customer accounts (Total Order Amounts)");
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
                                    Console.WriteLine("\nNumber of order managed");
                                    for (int k = 0; k < assistantList.Count; k++)
                                    {
                                        Console.WriteLine("Assistant n°"+(k+1) +" : "+assistantList[k].nbOrderManaged);
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("\nNumber of deliveries per deliveryBoy : ");
                                    for (int i = 0; i < deliveryManList.Count; i++)
                                    {
                                        Console.WriteLine("DeliveryMan n°"+(i+1) +" : "+ deliveryManList[i].deliveryNumber + " deliveries");
                                    }
                                    break;
                                case 3 :
                                    Console.WriteLine("\nThe average amount of orders :   ");
                                    myPizzeria.averageOrderAmount(orderList);
                                    break;
                                case 4:
                                    Console.WriteLine("\nThe average customer accounts (Total Order Amounts) :   ");
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

