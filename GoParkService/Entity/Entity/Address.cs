using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoParkService.Entity.Entity;

[Table(nameof(Address))]
public class Address : BaseEntity
{

    [MaxLength(255)]
    public string StreetAddress { get; set; }

    [MaxLength(100)]
    public string City { get; set; }

    [MaxLength(100)]
    public string StateProvince { get; set; }

    [MaxLength(20)]
    public string PostalCode { get; set; }

    [MaxLength(100)]
    public string Country { get; set; }

    //Optional Address Name. Example: Shipping address, billing address, warehouse address
    [MaxLength(100)]
    public string AddressName { get; set; }

    //Optional Foreign Key to Company.
    public Guid? CompanyId { get; set; }
    public Company Company { get; set; }
}
