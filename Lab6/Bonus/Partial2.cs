using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class ExtendedAppartement : Appartement
{
    // Константа
    public const int MaxBonusLimit = 1000;

    // Read-only поле
    public readonly string AdditionalInfo = "Additional Information";

    // Статическое поле
    private static int totalExtendedCards = 0;

    // Статический метод
    public static int GetTotalExtendedCards()
    {
        return totalExtendedCards;
    }

    // Другие методы и элементы класса
}

