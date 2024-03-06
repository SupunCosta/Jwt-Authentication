using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace JwtAuthentication.Areas.Identity.Data.User;

[ValidateNever]
public class Students
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Age { get; set; }
    public string? PhoneNumberId { get; set; }
    
    [ForeignKey(nameof(PhoneNumberId))]
    public PhoneNumber PhoneNumber { get; set; }
    public string? AddressId { get; set; }
    
    [ForeignKey(nameof(AddressId))]
    public Address Address { get; set; }

}