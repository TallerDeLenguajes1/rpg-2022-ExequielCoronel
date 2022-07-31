
using System.Text.Json.Serialization;

namespace RPG{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Address2
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("street_name")]
        public string StreetName { get; set; }

        [JsonPropertyName("street_address")]
        public string StreetAddress { get; set; }

        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }
    }

    public class Coordinates
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public class CreditCard
    {
        [JsonPropertyName("cc_number")]
        public string CcNumber { get; set; }
    }

    public class Employment
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("key_skill")]
        public string KeySkill { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("social_insurance_number")]
        public string SocialInsuranceNumber { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("employment")]
        public Employment Employment { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("credit_card")]
        public CreditCard CreditCard { get; set; }

        [JsonPropertyName("subscription")]
        public Subscription Subscription { get; set; }
    }

    public class Subscription
    {
        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("term")]
        public string Term { get; set; }
    }
}