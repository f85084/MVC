using System;
namespace BusinessLayer
{
    public interface IGamer
    {
        int Id { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        DateTime? DateOfBirth { get; set; }
        int TeamId { get; set; }
    }
}