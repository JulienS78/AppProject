using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project;

public class Customer : Personn
{
   public DateOnly firstOrder { get; set; }
   public string customerCity { get; set; }
   public int orderNumber { get; set; }
   public int totalAmount { get; set; }

   public Customer(int id,string name, string lastName, int phoneNumber, string address,string customerCity, DateOnly firstOrder, int orderNumber,
      int totalAmount)
   {
      this.id = id;
      this.name = name;
      this.lastName = lastName;
      this.phoneNumber = phoneNumber;
      this.address = address;
      this.customerCity = customerCity;
      this.firstOrder = firstOrder;
      this.orderNumber = orderNumber;
      this.totalAmount = totalAmount;
   }

   //update le montant total des commandes
   public void newTotalAmount(int newamountOrder)
   {
      this.totalAmount += newamountOrder;
   }
   
}