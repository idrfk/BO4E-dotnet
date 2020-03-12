using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung einer Menge mit Wert und Einheit.</summary>
    [ProtoContract]
    public class Menge : COM
    {
        /// <summary>Gibt den absoluten Wert der Menge an.</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("value", Language.EN)]
        [ProtoMember(3)]
        public decimal wert;
        /// <summary>Gibt die Einheit zum jeweiligen Wert an. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("unit", Language.EN)]
        [ProtoMember(4)]
        public Mengeneinheit einheit;
    }
}
