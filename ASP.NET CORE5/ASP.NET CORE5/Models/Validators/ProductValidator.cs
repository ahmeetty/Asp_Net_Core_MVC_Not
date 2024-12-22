using ASP.NET_CORE5.Controllers;
using AspNetCore;
using FluentValidation;

namespace ASP.NET_CORE5.Models.Validators
{
	public class ProductValidator: AbstractValidator<Product>
	{

		public ProductValidator()
		{

			RuleFor(x => x.Email).NotNull().WithMessage("E mail boş olamaz!");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen Doğru Bir Email Giriniz!");

		}
	}
}
