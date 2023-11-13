using Newtonsoft.Json;

namespace ObiletApp.Models.ResponseModels
{
    public class JourneyResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("partner-id")]
        public int? PartnerId { get; set; }

        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }

        [JsonProperty("route-id")]
        public int? RouteId { get; set; }

        [JsonProperty("bus-type")]
        public string BusType { get; set; }

        [JsonProperty("bus-type-name")]
        public string BusTypeName { get; set; }

        [JsonProperty("total-seats")]
        public int TotalSeats { get; set; }

        [JsonProperty("available-seats")]
        public int AvailableSeats { get; set; }

        [JsonProperty("journey")]
        public Journey Journey { get; set; }

        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonProperty("is-active")]
        public bool IsActive { get; set; }

        [JsonProperty("origin-location-id")]
        public int OriginLocationId { get; set; }

        [JsonProperty("destination-location-id")]
        public int DestinationLocationId { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }

        [JsonProperty("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }

        [JsonProperty("display-offset")]
        public string DisplayOffset { get; set; }

        [JsonProperty("partner-rating")]
        public string PartnerRating { get; set; }

        [JsonProperty("has-dynamic-pricing")]
        public bool HasDynamicPricing { get; set; }

        [JsonProperty("disable-sales-without-hes-code")]
        public bool DisableSalesWithoutHesCode { get; set; }

        [JsonProperty("disable-single-seat-selection")]
        public bool DisableSingleSeatSelection { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("display-coupon-code-input")]
        public bool DisplayCouponCodeInput { get; set; }

        [JsonProperty("allow-sales-foreign-passenger")]
        public bool AllowSalesForeignPassenger { get; set; }

        [JsonProperty("has-seat-selection")]
        public bool HasSeatSelection { get; set; }

        [JsonProperty("has-gender-selection")]
        public bool HasGenderSelection { get; set; }

        [JsonProperty("has-dynamic-cancellation")]
        public bool HasDynamicCancellation { get; set; }

        [JsonProperty("partner-available-alphabets")]
        public string PartnerAvailableAlphabets { get; set; }

        [JsonProperty("provider-id")]
        public int? ProviderId { get; set; }

        [JsonProperty("partner-code")]
        public string PartnerCode { get; set; }

        [JsonProperty("enable-full-journey-display")]
        public bool EnableFullJourneyDisplay { get; set; }

        [JsonProperty("provider-name")]
        public string ProviderName { get; set; }

        [JsonProperty("enable-all-stops-display")]
        public bool EnableAllStopsDisplay { get; set; }

        [JsonProperty("is-destination-domestic")]
        public bool IsDestinationDomestic { get; set; }

        [JsonProperty("require-foreign-gov-id")]
        public bool RequireForeignGovId { get; set; }

        [JsonProperty("is-cancellation-info-text")]
        public bool IsCancellationInfoText { get; set; }

        [JsonProperty("is-time-zone-not-equal")]
        public bool IsTimeZoneNotEqual { get; set; }

    }
    public class Journey
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("stops")]
        public List<Stop> Stops { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTime? Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime? Arrival { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("original-price")]
        public string OriginalPrice { get; set; }

        [JsonProperty("internet-price")]
        public string InternetPrice { get; set; }

        [JsonProperty("provider-internet-price")]
        public string ProviderInternetPrice { get; set; }

        [JsonProperty("bus-name")]
        public string BusName { get; set; }

        [JsonProperty("is-segmented")]
        public bool IsSegmented { get; set; }

    }
    public class Stop
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("station")]
        public string Station { get; set; }


        [JsonProperty("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool IsDestination { get; set; }
    }
}
