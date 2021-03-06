using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.BO
{

    // https://github.com/Hochfrequenz/energy-service-hub/issues/11
    //@JsonPropertyOrder({ "versionStruktur", "boTyp", "marktlokationsId", "sparte", "energierichtung",
    //        "bilanzierungsmethode", "verbrauchsart", "unterbrechbar", "netzebene", "netzbetreiberCodeNr", "gebietTyp",
    //        "netzgebietNr", "bilanzierungsgebiet", "grundversorgerCodeNr", "gasqualitaet", "endkunde", "lokationsadresse",
    //        "geoadresse", "katasterinformation", "zugehoerigeMesslokationen" })
    /// <summary>
    /// Objekt zur Aufnahme der Informationen zu einer Marktlokation
    /// </summary>
    [ProtoContract]
    public class Marktlokation : BusinessObject
    {
        /// <summary>
        /// Identifikationsnummer einer Marktlokation, an der Energie entweder
        /// verbraucht, oder erzeugt wird
        /// </summary>
        [DefaultValue("|null|")]
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "marktlokationsId")]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        [ProtoMember(4)]
        public string MarktlokationsId { get; set; }
        /// <summary>Sparte der Messlokation, z.B. Gas oder Strom.</summary>
        [JsonProperty(Required = Required.Always, Order = 5, PropertyName = "sparte")]
        [ProtoMember(5)]
        public Sparte Sparte { get; set; }

        /// <summary>Kennzeichnung, ob Energie eingespeist oder entnommen (ausgespeist) wird.</summary>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "energierichtung")]
        [ProtoMember(6)]
        public Energierichtung Energierichtung { get; set; }

        /// <summary>Kennzeichnung, ob Energie eingespeist oder entnommen (ausgespeist) wird.</summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName = "bilanzierungsmethode")]
        [ProtoMember(7)]
        public Bilanzierungsmethode Bilanzierungsmethode { get; set; }

        /// <summary>Verbrauchsart der Marktlokation</summary>
        [JsonProperty(Required = Required.Default, Order = 8, PropertyName = "verbrauchsart")]
        [ProtoMember(8)]
        public Verbrauchsart? Verbrauchsart { get; set; }

        /// <summary>Gibt an, ob es sich um eine unterbrechbare Belieferung handelt.</summary>
        [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "unterbrechbar")]
        [ProtoMember(9)]
        public bool? Unterbrechbar { get; set; }

        ///<summary>
        /// Netzebene, in der der Bezug der Energie erfolgt. Bei Strom Spannungsebene der
        /// Lieferung, bei Gas Druckstufe. Beispiel Strom: Niederspannung Beispiel Gas:
        /// Niederdruck.
        /// <seealso cref="ENUM.Netzebene" /></summary> 
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName = "netzebene")]
        [ProtoMember(10)]
        public Netzebene Netzebene { get; set; }

        /// <summary>
        /// Codenummer des Netzbetreibers, an dessen Netz diese Marktlokation
        /// angeschlossen ist.
        /// </summary>
        [JsonProperty(PropertyName = "netzbetreiberCodeNr", Required = Required.Default, Order = 11)]
        [ProtoMember(11)]
        public string NetzbetreiberCodeNr { get; set; }

        /// <summary>Typ des Netzgebietes,z.B.Verteilnetz.</summary>
        /// https://github.com/Hochfrequenz/energy-service-hub/issues/11
        [JsonProperty(PropertyName = "gebietTyp", Order = 12, Required = Required.Default)]
        [ProtoMember(12)]
        public Gebiettyp? GebietType { get; set; }

        /// <summary>Die Nummer des Netzgebietes in der ene't-Datenbank.</summary>
        [JsonProperty(PropertyName = "netzgebietNr", Order = 13, Required = Required.Default)]
        [ProtoMember(13)]
        public string NetzgebietNr { get; set; }

        /// <summary>Bilanzierungsgebiet, dem das Netzgebiet zugeordnet ist - im Falle eines Strom Netzes.</summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "bilanzierungsgebiet")]
        [ProtoMember(14)]
        public string Bilanzierungsgebiet { get; set; }

        /// <summary>CodeNummer des Grundversorgers, der für diese Marktlokation zuständig ist.</summary>
        [JsonProperty(PropertyName = "grundversorgerCodeNr", Order = 15, Required = Required.Default)]
        [ProtoMember(15)]
        public string GrundversorgerCodeNr { get; set; }

        ///<summary>Die Gasqualität in diesem Netzgebiet. H-Gas oder L-Gas. Im Falle eines Gas-Netzes.<seealso cref="ENUM.Gasqualitaet" /></summary> */
        [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "gasqualitaet")]
        [ProtoMember(16)]
        public Gasqualitaet? Gasqualitaet { get; set; }

        /// <summary>Link zum Geschäftspartner, dem diese Marktlokation gehört.</summary>
        [JsonProperty(Required = Required.Default, Order = 17, NullValueHandling = NullValueHandling.Ignore, PropertyName = "endkunde")]
        [ProtoMember(17)]
        public Geschaeftspartner Endkunde { get; set; }

        /// <summary>Die Adresse, an der die Energie-Lieferung oder -Einspeisung erfolgt. <seealso cref="Adresse" /></summary> */
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default, Order = 18, PropertyName = "lokationsadresse")]
        [ProtoMember(18)]
        public Adresse Lokationsadresse { get; set; }

        /// <summary>Alternativ zu einer postalischen Adresse kann hier ein Ort mittels Geokoordinaten angegeben werden (z.B. zur Identifikation von Sendemasten).<seealso cref="Geokoordinaten" /></summary> */
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default, Order = 19, PropertyName = "geoadresse")]
        [ProtoMember(19)]
        public Geokoordinaten Geoadresse { get; set; }

        /// <summary>Alternativ zu einer postalischen Adresse und Geokoordinaten kann hier eine  Ortsangabe mittels Gemarkung und Flurstück erfolgen. <seealso cref="Katasteradresse" /></summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default, Order = 20, PropertyName = "katasterinformation")]
        [ProtoMember(20)]
        public Katasteradresse Katasterinformation { get; set; }

        /// <summary>
        /// für EDIFACT mapping 
        /// </summary>
        // ToDo: specify docstring / evaluate if necessary
        [JsonProperty(Required = Required.Default, Order = 21, PropertyName = "marktrollen")]
        [ProtoMember(1021)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [Obsolete("I'm pretty sure the BO.Marktlokation is not the right place to store this information. Please evaluate!")]
        public List<COM.Marktrolle> Marktrollen { get; set; } // ToDo: evaluate this

        /// <summary>
        /// für EDIFACT mapping 
        /// </summary>
        // ToDo: specify docstring.
        [JsonProperty(Required = Required.Default, Order = 22, PropertyName = "regelzone")]
        [ProtoMember(1022)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public string Regelzone { get; set; }

        /// <summary>
        /// für EDIFACT mapping 
        /// </summary>
        // ToDo: specify docstring.
        [JsonProperty(Required = Required.Default, Order = 23, PropertyName = "marktgebiet")]
        [ProtoMember(1023)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public string Marktgebiet { get; set; }

        /// <summary>
        /// für EDIFACT mapping 
        /// </summary>
        // ToDo: specify docstring.
        [JsonProperty(Required = Required.Default, Order = 24, PropertyName = "zeitreihentyp")]
        [ProtoMember(1024)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Zeitreihentyp? Zeitreihentyp { get; set; }

        /// <summary>
        /// für EDIFACT mapping 
        /// </summary>
        // ToDo: specify docstring.
        [JsonProperty(Required = Required.Default, Order = 25, PropertyName = "zaehlwerke")]
        [ProtoMember(1025)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public List<Zaehlwerk> Zaehlwerke { get; set; }

        /// <summary>
        /// für EDIFACT mapping 
        /// </summary>
        // ToDo: specify docstring / check if needed
        [JsonProperty(Required = Required.Default, Order = 26, PropertyName = "verbrauchsmenge")]
        [ProtoMember(1026)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [Obsolete("Consider if this is really the right place to store the information. I think Energiemenge->energieverbrauch is better suited.")]
        public List<Verbrauch> Verbrauchsmenge { get; set; }

        /// <summary>
        /// für EDIFACT mapping 
        /// </summary>
        // ToDo: specify docstring.
        [JsonProperty(Required = Required.Default, Order = 27, PropertyName = "messlokationen")]
        [ProtoMember(1027)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public List<Messlokation> Messlokationen { get; set; }

        /// <summary>Aufzählung der Messlokationen, die zu dieser Marktlokation gehören.</summary>
        /// Es können 3 verschiedene Konstrukte auftreten:
        /// <ol>
        /// <li>Beziehung 1 : 0 : Hier handelt es sich um Pauschalanlagen ohne Messung.
        /// D.h. die Verbrauchsdaten sind direkt über die Marktlokation abgreifbar.</li>
        /// <li>Beziehung 1 : 1 : Das ist die Standard-Beziehung für die meisten Fälle.
        /// In diesem Fall gibt es zu einer Marktlokation genau eine Messlokation.</li>
        /// <li>Beziehung 1 : N : Hier liegt beispielsweise eine Untermessung vor. Der
        /// Verbrauch einer Marklokation berechnet sich hier aus mehreren Messungen.</li>
        /// </ol>
        ///
        /// Es gibt praktisch auch noch die Beziehung N : 1, beispielsweise bei einer
        /// Zweirichtungsmessung bei der durch eine Messeinrichtung die Messung sowohl
        /// für die Einspreiseseite als auch für die Aussspeiseseite erfolgt. Da
        /// Abrechnung und Bilanzierung jedoch für beide Marktlokationen getrennt
        /// erfolgt, werden nie beide Marktlokationen gemeinsam betrachtet. Daher lässt
        /// sich dieses Konstrukt auf zwei 1:1-Beziehung zurückführen, wobei die
        /// Messlokation in beiden Fällen die gleiche ist.
        ///
        /// In den Zuordnungen sind ist die arithmetische Operation mit der der Verbrauch
        /// einer Messlokation zum Verbrauch einer Marktlokation beitrögt mit aufgeführt.
        /// Der Standard ist hier die Addition.
        [DataCategory(DataCategory.POD)]
        [JsonProperty(Required = Required.Default, Order = 28, PropertyName = "zugehoerigeMesslokationen")]
        [ProtoMember(28)]
        public List<Messlokationszuordnung> ZugehoerigeMesslokationen { get; set; }


        /// <summary>
        /// Regular Expression used to validate 11 digit MarktlokationId
        /// </summary>
        [JsonIgnore]
        protected static readonly Regex REGEX_VALIDATE = new Regex(@"^[1-9][\d]{10}$", RegexOptions.Compiled);
        /// <summary>
        /// Regular Expression to check if a string consists only of numbers (is numeric)
        /// </summary>
        [JsonIgnore]
        protected static readonly Regex REGEX_NUMERIC_STRING = new Regex(@"^\d+$", RegexOptions.Compiled);

        /// <summary>
        /// Test if a <paramref name="id"/> is a valid Marktlokations ID.
        /// </summary>
        /// <param name="id">id to test</param>
        /// <returns></returns>
        public static bool ValidateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }
            if (!REGEX_VALIDATE.IsMatch(id))
            {
                return false;
            }
            string expectedChecksum = GetChecksum(id);
            string actualChecksum = id.Substring(10, 1);
            return actualChecksum == expectedChecksum;
        }

        /// <summary>
        /// Get the checksum of a marklokationsId:
        /// a) Quersumme aller Ziffern in ungerader Position
        /// b) Quersumme aller Ziffern
        /// auf gerader Position multipliziert mit 2 c) Summe von a) und b) d) Differenz
        /// von c) zum nächsten Vielfachen von 10 (ergibt sich hier 10, wird die
        /// Prüfziffer 0 genommen)
        /// https://bdew-codes.de/Content/Files/MaLo/2017-04-28-BDEW-Anwendungshilfe-MaLo-ID_Version1.0_FINAL.PDF
        /// </summary>
        /// <returns>expected checksum</returns>
        public static string GetChecksum(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"Input '{nameof(input)}' must not be empty but was '{input}'");
            }
            if (input.Length < 10 || input.Length > 11)
            {
                throw new ArgumentException($"Input '{nameof(input)}' must be a string with length 10 (to generate the checksum) or 11 (to validate the checksum).");
            }
            if (!REGEX_NUMERIC_STRING.IsMatch(input))
            {
                throw new ArgumentException($"Input '{nameof(input)}' must be numeric was '{input}'");
            }
            int oddChecksum = 0;
            int evenChecksum = 0;

            // start counting at 1 to be consistent with the above description of "even" and  "odd" but stop at tenth digit.
            for (int i = 1; i < 11; i++)
            {
                string s = input.Substring(i - 1, 1);
                if (i % 2 == 0)
                {
                    evenChecksum += 2 * Int32.Parse(s);
                }
                else
                {
                    oddChecksum += Int32.Parse(s);
                }
            }
            int result = (10 - ((evenChecksum + oddChecksum) % 10)) % 10;
            return result.ToString();
        }

        /// <summary>
        /// Test if the <see cref="marktlokationsId"/> is valid.
        /// </summary>
        /// <returns>if marktlokaionsId matches the expected format</returns>
        public bool HasValidId()
        {
            return ValidateId(this.MarktlokationsId);
        }

        /// <summary>
        /// same as <see cref="BusinessObject.IsValid()" /> if <paramref name="checkId"/> is false but by default additionally checks if the <see cref="marktlokationsId"/> is valid using <see cref="HasValidId"/>.
        /// </summary>
        /// <param name="checkId">validate the <see cref="marktlokationsId"/>, too</param>
        /// <returns>true if the marktlokation is valid</returns>
        public bool IsValid(bool checkId = true)
        {
            return base.IsValid() && (!checkId || HasValidId());
        }
    }
}