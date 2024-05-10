using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class ExtendedAppartement : Appartement
{
    protected string SecretInfo { get; set; }
    protected int ReadOnlyField { get; }



    public ExtendedAppartement(string number, string adress, string region, string description, decimal views,
        string secretInfo, int readOnlyValue)
        : base(number, adress, region, description, views)
    {
        SecretInfo = secretInfo;
        ReadOnlyField = readOnlyValue;
    }

    // Пример свойства для защищенного поля
    public string SecretInfoProperty
    {
        get { return SecretInfo; }
        set { SecretInfo = value; }
    }

    // Пример свойства для read-only поля
    public int ReadOnlyFieldProperty
    {
        get { return ReadOnlyField; }
    }
}
