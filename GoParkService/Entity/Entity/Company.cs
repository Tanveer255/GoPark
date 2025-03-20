using Stripe;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoParkService.Entity.Entity;

[Table(nameof(Company))]
public class Company : BaseEntity
{

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(20)]
    public string RegistrationNumber { get; set; }

    // Primary Address
    public Address PrimaryAddress { get; set; }

    // Secondary Address (Optional)
    public Address SecondaryAddress { get; set; }

    // Invoice Address (Optional, could be different from primary)
    public Address InvoiceAddress { get; set; }

    // Other Addresses (List)
    public List<Address> OtherAddresses { get; set; } = new List<Address>();

    // Contact Information
    [MaxLength(50)]
    public string PrimaryContactName { get; set; }

    [MaxLength(20)]
    public string PrimaryPhoneNumber { get; set; }

    [MaxLength(255)]
    public string PrimaryEmail { get; set; }

    // Website
    [MaxLength(255)]
    public string Website { get; set; }
    // Add other relevant properties like industry, etc.
}
