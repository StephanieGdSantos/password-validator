using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace password_validator.Configurations
{
    public class LengthPasswordOptions
    {
        [Required]
        public int MinimumLength { get; set; }
    }
}
