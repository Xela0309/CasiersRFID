using System;
using System.Collections.Generic;

public enum PaysEuropeen
{
    France,
    Allemagne,
    Italie,
    Espagne,
    Portugal,
    Belgique,
    PaysBas,
    Suisse,
    Autriche,
    Suede,
    Norvege,
    Finlande,
    Danemark,
    RoyaumeUni,
    Irlande,
    Pologne,
    Tchequie,
    Slovaquie,
    Hongrie,
    Roumanie,
    Bulgarie,
    Slovenie,
    Croatie,
    Serbie,
    MacedoineNord,
    Montenegro,
    Albanie,
    Grece,
    Luxembourg,
    Estonie,
    Lettonie,
    Lituanie,
    Chypre,
    Malte
}

public class PlaqueInfo
{
    public string Regex { get; set; }
    public string Exemple { get; set; }

    public PlaqueInfo(string regex, string exemple)
    {
        Regex = regex;
        Exemple = exemple;
    }
}

public static class PlaquesEuropeennes
{
    public static readonly Dictionary<PaysEuropeen, PlaqueInfo> InfosPlaques = new Dictionary<PaysEuropeen, PlaqueInfo>()
    {
        { PaysEuropeen.France, new PlaqueInfo("^[A-Z]{2}-\\d{3}-[A-Z]{2}$", "AB-123-CD") },
        { PaysEuropeen.Allemagne, new PlaqueInfo("^[A-Z]{1,3} [A-Z]{1,2} \\d{1,4}$", "B AB 1234") },
        { PaysEuropeen.Italie, new PlaqueInfo("^[A-Z]{2} \\d{3} [A-Z]{2}$", "AA 123 BB") },
        { PaysEuropeen.Espagne, new PlaqueInfo("^\\d{4} [A-Z]{3}$", "1234 ABC") },
        { PaysEuropeen.Portugal, new PlaqueInfo("^\\d{2}-[A-Z]{2}-\\d{2}$", "12-AB-34") },
        { PaysEuropeen.Belgique, new PlaqueInfo("^\\d-[A-Z]{3}-\\d{3}$", "1-ABC-123") },
        { PaysEuropeen.PaysBas, new PlaqueInfo("^[A-Z0-9]{2}-[A-Z0-9]{2}-[A-Z0-9]{2}$", "AB-12-CD") },
        { PaysEuropeen.Suisse, new PlaqueInfo("^[A-Z]{2} \\d{1,6}$", "GE 123456") },
        { PaysEuropeen.Autriche, new PlaqueInfo("^[A-Z]{1,3} \\d{1,5} [A-Z]{1,2}$", "W 12345 AB") },
        { PaysEuropeen.Suede, new PlaqueInfo("^[A-Z]{3} \\d{3}$", "ABC 123") },
        { PaysEuropeen.Norvege, new PlaqueInfo("^[A-Z]{2} \\d{5}$", "AB 12345") },
        { PaysEuropeen.Finlande, new PlaqueInfo("^[A-Z]{3}-\\d{3}$", "ABC-123") },
        { PaysEuropeen.Danemark, new PlaqueInfo("^[A-Z]{2} \\d{2} \\d{3}$", "AB 12 345") },
        { PaysEuropeen.RoyaumeUni, new PlaqueInfo("^[A-Z]{2}\\d{2} [A-Z]{3}$", "AB12 CDE") },
        { PaysEuropeen.Irlande, new PlaqueInfo("^\\d{2,3}-[A-Z]{1,2}-\\d{1,5}$", "12-D-12345") },
        { PaysEuropeen.Pologne, new PlaqueInfo("^[A-Z]{2} \\d{4,5}$", "AB 12345") },
        { PaysEuropeen.Tchequie, new PlaqueInfo("^\\d[A-Z]\\d \\d{4}$", "1A2 3456") },
        { PaysEuropeen.Slovaquie, new PlaqueInfo("^[A-Z]{2} \\d{3}[A-Z]{2}$", "BA 123AB") },
        { PaysEuropeen.Hongrie, new PlaqueInfo("^[A-Z]{3}-\\d{3}$", "ABC-123") },
        { PaysEuropeen.Roumanie, new PlaqueInfo("^[A-Z]{1,2} \\d{2,3} [A-Z]{3}$", "B 123 ABC") },
        { PaysEuropeen.Bulgarie, new PlaqueInfo("^[A-Z]{1,2} \\d{4} [A-Z]{1,2}$", "CB 1234 AB") },
        { PaysEuropeen.Slovenie, new PlaqueInfo("^[A-Z]{2} [A-Z]{1,2}-\\d{3}$", "LJ AB-123") },
        { PaysEuropeen.Croatie, new PlaqueInfo("^[A-Z]{2} \\d{3}-[A-Z]{1,2}$", "ZG 123-AA") },
        { PaysEuropeen.Serbie, new PlaqueInfo("^[A-Z]{2} \\d{3}-[A-Z]{2}$", "NS 123-AA") },
        { PaysEuropeen.MacedoineNord, new PlaqueInfo("^[A-Z]{2} \\d{4} [A-Z]{2}$", "SK 1234 AB") },
        { PaysEuropeen.Montenegro, new PlaqueInfo("^[A-Z]{2} [A-Z]{1,2}\\d{3}$", "PG AB123") },
        { PaysEuropeen.Albanie, new PlaqueInfo("^[A-Z]{2} \\d{3} [A-Z]{2}$", "AA 123 BB") },
        { PaysEuropeen.Grece, new PlaqueInfo("^[A-Z]{3} \\d{4}$", "ABC 1234") },
        { PaysEuropeen.Luxembourg, new PlaqueInfo("^\\d{2,6}$", "123456") },
        { PaysEuropeen.Estonie, new PlaqueInfo("^[0-9]{3}[A-Z]{3}$", "123ABC") },
        { PaysEuropeen.Lettonie, new PlaqueInfo("^[A-Z]{2}-\\d{4}$", "AB-1234") },
        { PaysEuropeen.Lituanie, new PlaqueInfo("^[A-Z]{3} \\d{3}$", "ABC 123") },
        { PaysEuropeen.Chypre, new PlaqueInfo("^[A-Z]{3}-\\d{3}$", "ABC-123") },
        { PaysEuropeen.Malte, new PlaqueInfo("^[A-Z]{3} \\d{3}$", "MLT 123") }
    };
}
