using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project;

public class Chef : Person
{
    public Chef (int id,string name, string lastName)
    {
        this.id = id;
        this.name = name;
        this.lastName = lastName;
    }

    public async Task orderPreparation(Order myOrder, Chef actualChef)
    {
        int delayms;
        int ms = 2000;
        
        await Task.Delay(ms);
        Console.WriteLine("\n"+actualChef.name+" "+actualChef.lastName+" will now prepare the order");
        await Task.Delay(ms);
        for (int i = 0; i < myOrder.PizzaOList.Count; i++)
        {
            Console.WriteLine("\nPizza n°"+(i + 1)+" is in preparation");
            delayms = myOrder.PizzaOList[i].preparationTime;
            await Task.Delay(delayms * 200);
            Console.WriteLine("\nPizza n°"+(i + 1)+" is done");
        }
    }
}