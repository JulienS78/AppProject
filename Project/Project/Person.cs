using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project;

public abstract class Person
{
    public int id{ get; set; }
    public string? name { get; set; }
    public string? lastName { get; set; }
    public int phoneNumber { get; set; }
    public string? address { get; set; }
}