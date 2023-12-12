using System.ComponentModel.DataAnnotations;

namespace Project_Pronia.ViewModels
{
	public class RegisterVm
	{
		[Required]
		[MinLength(3)]
		[MaxLength(25)]
		public string Name { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(35)]
		public string Surname { get; set; }
		[Required]
		[MaxLength(25)]
		public string Username { get; set; }
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[DataType(DataType.Password),Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
    }
}
