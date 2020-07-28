using CliApp.Core.Entities;

public class Address: BaseEntity
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}