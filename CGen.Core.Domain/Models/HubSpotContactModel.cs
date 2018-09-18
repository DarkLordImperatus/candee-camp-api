using System.Collections.Generic;

namespace CGen.Core.Domain.Models
{
    public class HubSpotContactModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
    }

    public class HubSpotContactProperty
    {
        public string Property { get; set; }
        public string Value { get; set; }
    }

    public class HubSpotContactProperties
    {
        public HubSpotContactProperties()
        {
            Properties = new List<HubSpotContactProperty>();
        }

        public List<HubSpotContactProperty> Properties { get; set; }
    }

    public static class HubSpotExtensions
    {
        private const string LeadStatusProperty = "hs_lead_status";
        private const string LeadStatusValue = "NEW";
        
        public static HubSpotContactProperties Transform(this HubSpotContactModel model)
        {
            var properties = new HubSpotContactProperties();
            
            properties.Properties.Add(new HubSpotContactProperty
            {
                Property = nameof(model.FirstName),
                Value = model.FirstName
            });
            
            properties.Properties.Add(new HubSpotContactProperty
            {
                Property = nameof(model.LastName),
                Value = model.LastName
            });
            
            properties.Properties.Add(new HubSpotContactProperty
            {
                Property = nameof(model.Email),
                Value = model.Email
            });
            
            properties.Properties.Add(new HubSpotContactProperty
            {
                Property = nameof(model.Phone),
                Value = model.Phone
            });
            
            properties.Properties.Add(new HubSpotContactProperty
            {
                Property = nameof(model.Company),
                Value = model.Company
            });
            
            properties.Properties.Add(new HubSpotContactProperty
            {
                Property = nameof(model.Website),
                Value = model.Website
            });
            
            properties.Properties.Add(new HubSpotContactProperty
            {
                Property = LeadStatusProperty,
                Value = LeadStatusValue
            });

            return properties;
        }
    }
}