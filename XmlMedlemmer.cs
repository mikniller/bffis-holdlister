/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "leder")]
    public class Leder
    {
        [XmlElement(ElementName = "medlem")]
        public List<string> Medlem { get; set; }
    }

    [XmlRoot(ElementName = "medlem")]
    public class MedlemInstance
    {
        [XmlElement(ElementName = "medlem")]
        public List<string> Medlem { get; set; }
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "alt_id")]
        public string Alt_id { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "koen")]
        public string Koen { get; set; }
        [XmlElement(ElementName = "navn")]
        public string Navn { get; set; }
        [XmlElement(ElementName = "adresse1")]
        public string Adresse1 { get; set; }
        [XmlElement(ElementName = "adresse2")]
        public string Adresse2 { get; set; }
        [XmlElement(ElementName = "postnr")]
        public string Postnr { get; set; }
        [XmlElement(ElementName = "postnr_by")]
        public string Postnr_by { get; set; }
        [XmlElement(ElementName = "kommune")]
        public string Kommune { get; set; }
        [XmlElement(ElementName = "kommune_navn")]
        public string Kommune_navn { get; set; }
        [XmlElement(ElementName = "tlf")]
        public string Tlf { get; set; }
        [XmlElement(ElementName = "mobil")]
        public string Mobil { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "birth")]
        public string Birth { get; set; }
        [XmlElement(ElementName = "individuel1")]
        public string Individuel1 { get; set; }
        [XmlElement(ElementName = "individuel2")]
        public string Individuel2 { get; set; }
        [XmlElement(ElementName = "individuel3")]
        public string Individuel3 { get; set; }
        [XmlElement(ElementName = "individuel4")]
        public string Individuel4 { get; set; }
        [XmlElement(ElementName = "individuel5")]
        public string Individuel5 { get; set; }
        [XmlElement(ElementName = "off_navn")]
        public string Off_navn { get; set; }
        [XmlElement(ElementName = "off_adresse1")]
        public string Off_adresse1 { get; set; }
        [XmlElement(ElementName = "off_adresse2")]
        public string Off_adresse2 { get; set; }
        [XmlElement(ElementName = "off_postnr")]
        public string Off_postnr { get; set; }
        [XmlElement(ElementName = "off_tlf")]
        public string Off_tlf { get; set; }
        [XmlElement(ElementName = "off_mobil")]
        public string Off_mobil { get; set; }
        [XmlElement(ElementName = "off_email")]
        public string Off_email { get; set; }
        [XmlElement(ElementName = "noegle")]
        public string Noegle { get; set; }
        [XmlElement(ElementName = "pinkode")]
        public string Pinkode { get; set; }
        [XmlElement(ElementName = "noegle_er_betalt")]
        public string Noegle_er_betalt { get; set; }
        [XmlElement(ElementName = "betalingskort_abonnement_transaktionsid")]
        public string Betalingskort_abonnement_transaktionsid { get; set; }
        [XmlElement(ElementName = "betalingskort_abonnement_betalingsid")]
        public string Betalingskort_abonnement_betalingsid { get; set; }
        [XmlElement(ElementName = "betalingskort_abonnement_udloeb")]
        public string Betalingskort_abonnement_udloeb { get; set; }
        [XmlElement(ElementName = "kontobetaling_automatisk_optankning_tilmeldt")]
        public string Kontobetaling_automatisk_optankning_tilmeldt { get; set; }
        [XmlElement(ElementName = "kontobetaling_automatisk_optankning_beloeb")]
        public string Kontobetaling_automatisk_optankning_beloeb { get; set; }
        [XmlElement(ElementName = "mangler_bekraeftigelse")]
        public string Mangler_bekraeftigelse { get; set; }
        [XmlElement(ElementName = "slettet")]
        public bool Slettet { get; set; }
    }

    [XmlRoot(ElementName = "gruppe")]
    public class Gruppe
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "leder")]
        public Leder Leder { get; set; }
        [XmlElement(ElementName = "medlem")]
        public MedlemInstance Medlem { get; set; }
    }

    [XmlRoot(ElementName = "relationer")]
    public class Relationer
    {
        [XmlElement(ElementName = "gruppe")]
        public Gruppe Gruppe { get; set; }
    }

    [XmlRoot(ElementName = "medlemmer")]
    public class Medlemmer
    {
        [XmlElement(ElementName = "medlem")]
        public List<MedlemInstance> Medlem { get; set; }
    }

    [XmlRoot(ElementName = "conventus")]
    public class Conventus
    {
        [XmlElement(ElementName = "relationer")]
        public Relationer Relationer { get; set; }
        [XmlElement(ElementName = "medlemmer")]
        public Medlemmer Medlemmer { get; set; }
    }

}
