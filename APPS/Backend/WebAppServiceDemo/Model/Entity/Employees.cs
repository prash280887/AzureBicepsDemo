using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAppServiceDemo.Model.Entity
{
    public class Employees
    {
        [Required]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Email { get; set; }
    }
}
