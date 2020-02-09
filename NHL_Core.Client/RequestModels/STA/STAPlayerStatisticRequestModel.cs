﻿using NHL_Core.Client.Attributes;

namespace NHL_Core.Client.RequestModels
{
    public class STAPlayerStatisticRequestModel
    {
        [RequestQueryParameterName("yearByYear")]
        public object YearByYearStatistic { get; set; }

        [RequestQueryParameterName("careerRegularSeason")]
        public object CareerRegularSeasonStatistic { get; set; }
    }
}