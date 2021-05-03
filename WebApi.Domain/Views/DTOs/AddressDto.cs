using System;
namespace WebApi.Domain.Views.DTOs
{
    public class AddressDto
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GeoDto geo { get; set; }
    }
}
