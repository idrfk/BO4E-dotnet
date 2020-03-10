﻿using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Die Variante des Preisblattmodells zur Abbildung von allgemeinen Abgaben
    /// </summary>
    [ProtoContract]
    public class PreisblattKonzessionsabgabe : Preisblatt
    {
        /// <summary>
        /// Sparte, auf die sich die KA bezieht.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7)]
        [ProtoMember(7)]
        public Sparte sparte;

        /// <summary>
        /// Kundegruppe anhand derer die Höhe der Konzessionsabgabe festgelegt ist.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        [ProtoMember(8)]
        public KundengruppeKA kundengruppeKA;
    }
}
