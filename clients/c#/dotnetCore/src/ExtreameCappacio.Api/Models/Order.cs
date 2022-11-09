namespace ExtreameCappacio.Api.Models;

public class Order
{
    public decimal[] prices { get; set; }
    public int [] quantities { get; set; }
    public string country { get; set; }
    public string reduction { get; set; }
}
