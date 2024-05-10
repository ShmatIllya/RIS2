using System;

public class Appartement
{
    public string Number { get; set; }
    public string Adress { get; set; }
    public string Region { get; protected set; }
    public string Description { get; protected set; }

    public decimal Views { get; protected set; }

    public Appartement(string number, string adress, string region, string description, decimal views)
    {
        Number = number;
        Adress = adress;
        Region = region;
        Description = description;
        Views = views;
    }
    public void IncreaseViews()
    {
        Views++;
    }

  
}
