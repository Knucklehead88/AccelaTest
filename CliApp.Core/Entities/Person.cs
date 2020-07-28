using CliApp.Core.Entities;
using System.Collections.Generic;

public class Person: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName{ get; set; }
    public List<Address> Adresses { get; set; } = new List<Address>();
    

}