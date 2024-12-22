using System.ComponentModel.DataAnnotations;

namespace ASP.NET_CORE5.Models
{
	//public class Product
	//{
	//	[Required(ErrorMessage ="Lütfen Product name'i giriniz.")]
	//	[StringLength(100,ErrorMessage ="Lütfen Product name'i en fazla 100 karakter giriniz.")]
	//	public string ProductName{ get; set; }
	//	public int Quantity{ get; set; }

	//	[EmailAddress(ErrorMessage = " Lütfen doğru bir email adresi giriniz.")]
	//	public int Email{ get; set; }
	//}

	//public class User
	//{

	//	public string UserName { get; set; }

	//}


	public class Product
	{
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public string Email { get; set; }
	}



}
