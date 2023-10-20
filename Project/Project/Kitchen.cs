using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project;

public class Kitchen : Personn
{
    public Kitchen(int id,string name, string lastName)
    {
        this.id = id;
        this.name = name;
        this.lastName = lastName;
    }

    public async void orderPreparation(Order myOrder)
    {
        int delayms;
        for (int i = 0; i < myOrder.PizzaOList.Count; i++)
        {
            Console.WriteLine("In preparation");
            delayms = myOrder.PizzaOList[i].preparationTime;
            await Task.Delay(delayms * 200);
            Console.WriteLine("\nItem n°"+ (i+1)+" prepared");
        }
        Console.WriteLine("\nOrder in preparation !");
    }
}