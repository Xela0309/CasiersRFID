using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCasier
{

    [AttributeUsage(AttributeTargets.Field)]
    public class RegExPlaqueAttribute : Attribute
    {
        public string Regex { get; }

        public RegExPlaqueAttribute(string regex)
        {
            Regex = regex;
        }
    }

    public enum PaysEuropeen
    {
        [RegExPlaque("^[A-Z]{2}-\\d{3}-[A-Z]{2}$")]
        France,

        [RegExPlaque("^[A-Z]{1,3} [A-Z]{1,2} \\d{1,4}$")]
        Allemagne,

        [RegExPlaque("^[A-Z]{2} \\d{3} [A-Z]{2}$")]
        Italie,

        [RegExPlaque("^\\d{4} [A-Z]{3}$")]
        Espagne,

        [RegExPlaque("^\\d{2}-[A-Z]{2}-\\d{2}$")]
        Portugal,

        [RegExPlaque("^\\d-[A-Z]{3}-\\d{3}$")]
        Belgique,

        [RegExPlaque("^[A-Z0-9]{2}-[A-Z0-9]{2}-[A-Z0-9]{2}$")]
        PaysBas,

        [RegExPlaque("^[A-Z]{2} \\d{1,6}$")]
        Suisse,

        [RegExPlaque("^[A-Z]{1,3} \\d{1,5} [A-Z]{1,2}$")]
        Autriche,

        [RegExPlaque("^[A-Z]{3} \\d{3}$")]
        Suede,

        [RegExPlaque("^[A-Z]{2} \\d{5}$")]
        Norvege,

        [RegExPlaque("^[A-Z]{3}-\\d{3}$")]
        Finlande,

        [RegExPlaque("^[A-Z]{2} \\d{2} \\d{3}$")]
        Danemark,

        [RegExPlaque("^[A-Z]{2}\\d{2} [A-Z]{3}$")]
        RoyaumeUni,

        [RegExPlaque("^\\d{2,3}-[A-Z]{1,2}-\\d{1,5}$")]
        Irlande,

        [RegExPlaque("^[A-Z]{2} \\d{4,5}$")]
        Pologne,

        [RegExPlaque("^\\d[A-Z]\\d \\d{4}$")]
        Tchequie,

        [RegExPlaque("^[A-Z]{2} \\d{3}[A-Z]{2}$")]
        Slovaquie,

        [RegExPlaque("^[A-Z]{3}-\\d{3}$")]
        Hongrie,

        [RegExPlaque("^[A-Z]{1,2} \\d{2,3} [A-Z]{3}$")]
        Roumanie,

        [RegExPlaque("^[A-Z]{1,2} \\d{4} [A-Z]{1,2}$")]
        Bulgarie,

        [RegExPlaque("^[A-Z]{2} [A-Z]{1,2}-\\d{3}$")]
        Slovenie,

        [RegExPlaque("^[A-Z]{2} \\d{3}-[A-Z]{1,2}$")]
        Croatie,

        [RegExPlaque("^[A-Z]{2} \\d{3}-[A-Z]{2}$")]
        Serbie,

        [RegExPlaque("^[A-Z]{2} \\d{4} [A-Z]{2}$")]
        MacedoineNord,

        [RegExPlaque("^[A-Z]{2} [A-Z]{1,2}\\d{3}$")]
        Montenegro,

        [RegExPlaque("^[A-Z]{2} \\d{3} [A-Z]{2}$")]
        Albanie,

        [RegExPlaque("^[A-Z]{3} \\d{4}$")]
        Grece
    }

    public static class ExtensionPaysEuropeen
    {
        public static string ObtenirRegexPlaque(this PaysEuropeen pays)
        {
            var type = pays.GetType();
            var infoMembre = type.GetMember(pays.ToString());
            var attributs = infoMembre[0].GetCustomAttributes(typeof(RegExPlaqueAttribute), false);

            return attributs.Length > 0
                ? ((RegExPlaqueAttribute)attributs[0]).Regex
                : null;
        }
    }

}
