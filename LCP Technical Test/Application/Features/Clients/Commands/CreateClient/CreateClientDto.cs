namespace Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientDto
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }
    }
}
