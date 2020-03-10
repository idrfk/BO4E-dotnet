﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Mit diesem BO kann ein Versorgungsangebot zur Strom- oder Gasversorgung oder die Teilnahme an einer Ausschreibung übertragen werden.Es können verschiedene Varianten enthalten sein (z.B.ein- und mehrjährige Laufzeit). Innerhalb jeder Variante können Teile enthalten sein, die jeweils für eine oder mehrere Marktlokationen erstellt werden.
    /// </summary>
    public class Angebot : BusinessObject
    {
        /// <summary>
        ///  Eindeutige Nummer des Angebotes.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        [DataCategory(DataCategory.FINANCE)]
        [BoKey]
        public string angebotsnummer;

        /// <summary>
        /// Referenz auf eine Anfrage oder Ausschreibung.Kann dem Empfänger des Angebotes bei Zuordnung des Angebotes zur Anfrage bzw.Ausschreibung helfen.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5)]
        [ProtoMember(5)]
        [DataCategory(DataCategory.FINANCE)]
        public string anfragereferenz;

        /// <summary>
        /// Erstellungsdatum des Angebots,
        /// </summary>
        /// <example>
        /// 2017-12-24
        /// </example>
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(5)]
        [DataCategory(DataCategory.FINANCE)]
        // ToDo: handle this as DateTime object that serializes without the "time" in "DateTime"
        public string angebotsdatum;

        /// <summary>
        /// Sparte, für die das Angebot abgegeben wird (Strom/Gas).
        /// </summary>
        /// <see cref="Sparte"/>
        [JsonProperty(Required = Required.Always, Order = 7)]
        [ProtoMember(7)]
        public Sparte sparte;

        /// <summary>
        /// Bis zu diesem Zeitpunkt(Tag/Uhrzeit) inklusive gilt das Angebot
        /// </summary>
        /// <example>
        /// 2017-12-31 17:00:00
        /// </example>
        [JsonProperty(Required = Required.Default, Order = 8)]
        [ProtoMember(8)]
        [DataCategory(DataCategory.FINANCE)]
        public DateTime bindefrist;

        /// <summary>
        /// Link auf den Ersteller des Angebots.
        /// </summary>
        /// <see cref="Geschaeftspartner"/>
        [JsonProperty(Required = Required.Always, Order = 9)]
        [ProtoMember(10)]
        [DataCategory(DataCategory.FINANCE)]
        public Geschaeftspartner angebotgeber;

        /// <summary>
        /// Link auf den Empfänger des Angebots.
        /// </summary>
        /// <see cref="Geschaeftspartner"/>
        [JsonProperty(Required = Required.Always, Order = 10)]
        [ProtoMember(10)]
        [DataCategory(DataCategory.FINANCE)]
        public Geschaeftspartner angebotnehmer;

        /// <summary>
        /// Link auf die Person, die als Angebotsnehmer das Angebot angenommen hat.
        /// </summary>
        /// <see cref="Ansprechpartner"/>
        [JsonProperty(Required = Required.Default, Order = 11)]
        [ProtoMember(11)]
        [DataCategory(DataCategory.NAME)]
        public Ansprechpartner unterzeichnerAngebotsnehmer;

        /// <summary>
        /// Link auf die Person, die als Angebotsgeber das Angebots ausgestellt hat.
        /// </summary>
        /// <see cref="Ansprechpartner"/>
        [JsonProperty(Required = Required.Default, Order = 12)]
        [ProtoMember(12)]
        [DataCategory(DataCategory.NAME)]
        public Ansprechpartner unterzeichnerAngebotsgeber;

        /// <summary>
        /// Eine oder mehrere Varianten des Angebots mit den Angebotsteilen. Ein Angebot besteht mindestens aus einer Variante.
        /// </summary>
        /// <see cref="Angebotsvariante"/>
        [JsonProperty(Required = Required.Default, Order = 13)]
        [ProtoMember(13)]
        [DataCategory(DataCategory.FINANCE)]
        [MinLength(1)]
        public List<Angebotsvariante> varianten;
    }
}
