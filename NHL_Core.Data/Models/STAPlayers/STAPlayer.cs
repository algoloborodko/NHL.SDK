﻿using NHL.Data.Attributes;
using NHL.Data.Interfaces;
using System.Collections.Generic;

namespace NHL.Data.Models
{
    [ObjectAnnotation("people")]
    public class STAPlayer : IIdentityNHLModel
    {
        public bool Active { get; set; }
        public bool AlternateCaptain { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string BirthDate { get; set; }
        public bool Captain { get; set; }
        public int CurrentAge { get; set; }
        public STAeam CurrentTeam { get; set; }
        public long TeamId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Height { get; set; }
        public int Id { get; set; }
        public string Weight { get; set; }
        public string Link { get; set; }
        public string Nationality { get; set; }
        public int PrimaryNumber { get; set; }
        public bool Rookie { get; set; }
        public string RosterStatus { get; set; }
        public string ShootsCatches { get; set; }
        public STAPosition PrimaryPosition { get; set; }
        public List<STAPlayerStatistic> Stats { get; set; } = new List<STAPlayerStatistic>();

        //TODO: create enums for Position (Type = Forward...)
    }
}
