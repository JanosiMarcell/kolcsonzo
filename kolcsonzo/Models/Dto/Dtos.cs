namespace kolcsonzo.Models.Dto
{
    public record CreateCustomerDto(string Name, string Email);
    public record UpdateCustomerDto(string Name);

    public record CreateCarDto(string Marka, string Model, DateTime Evjarat);
    public record UpdateCarDto(string Model, DateTime Evjarat);

    public record CreateRentDto(string Customer_id, string Car_id, DateTime Start, DateTime End);

    public record UpdateRentDto(DateTime End);
}
