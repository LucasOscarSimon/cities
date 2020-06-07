namespace Entities.Models
{
    public class Citizen : ICitizen
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
