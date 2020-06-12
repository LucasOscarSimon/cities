namespace Entities.Models
{
    public class Citizen : ICitizen
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Document { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
