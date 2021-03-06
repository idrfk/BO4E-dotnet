using System.Collections.Generic;

using BO4E.BO;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente wird ein Teil einer Angebotsvariante abgebildet. Hier werden alle Angebotspositionen aggregiert.</summary>
    [ProtoContract]
    public class Angebotsteil : COM
    {
        /// <summary>Identifizierung eines Subkapitels einer Anfrage, beispielsweise das Los einer Ausschreibung.</summary>
        [JsonProperty(PropertyName = "anfrageSubreferenz", Required = Required.Default)]
        [ProtoMember(3)]
        public string AnfrageSubreferenz { get; set; }

        /// <summary>Marktlokationen, für die dieses Angebotsteil gilt, falls vorhanden. Durch die Marktlokation ist auch die Lieferadresse festgelegt. Details <see cref="Marktlokation" /></summary>
        [JsonProperty(PropertyName = "lieferstellenangebotsteil", Required = Required.Default)]
        [ProtoMember(4)]
        public List<Marktlokation> Lieferstellenangebotsteil { get; set; }

        /// <summary>Summe der Verbräuche aller in diesem Angebotsteil eingeschlossenen Lieferstellen. Details <see cref="Menge" /></summary>
        [JsonProperty(PropertyName = "gesamtmengeangebotsteil", Required = Required.Default)]
        [ProtoMember(5)]
        public Menge Gesamtmengeangebotsteil { get; set; }

        /// <summary>Summe der Jahresenergiekosten aller in diesem Angebotsteil enthaltenen Lieferstellen. Details <see cref="Betrag" /></summary>
        [JsonProperty(PropertyName = "gesamtkostenangebotsteil", Required = Required.Default)]
        [ProtoMember(6)]
        public Betrag Gesamtkostenangebotsteil { get; set; }

        /// <summary>Einzelne Positionen, die zu diesem Angebotsteil gehören. Details <see cref="Angebotsposition" /></summary>
        [JsonProperty(PropertyName = "positionen", Required = Required.Always)]
        [ProtoMember(7)]
        public List<Angebotsposition> Positionen { get; set; }
    }
}
