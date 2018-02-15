namespace Users.Common.Models
{
    public class Address
    {
        #region Properties

        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }

        #endregion
    }
}
