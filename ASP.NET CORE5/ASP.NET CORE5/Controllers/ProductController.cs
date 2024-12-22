using System.Security.Cryptography.X509Certificates;
using ASP.NET_CORE5.Models;
using ASP.NET_CORE5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE5.Controllers
{
	#region Örnek Gösterim

	//public class ProductController : Controller
	//{
	//	public IActionResult Index()
	//	{

	//		var products = new List<Product>
	//		{
	//			new Product { Id = 1, ProductName = "A Product", Quantity = 10 },
	//			new Product { Id = 2, ProductName = "B Product", Quantity = 15 },
	//			new Product { Id = 3, ProductName = "C Product", Quantity = 20 }

	//		};

	//		return View(products);

	//	}
	//}
	#endregion


	#region Tuple Kullanımı 

	//public class ProductController : Controller
	//{

	//	public IActionResult GetProducts()

	//	{

	//		Product product = new Product
	//		{
	//			Id = 1,
	//			ProductName = "A Product",
	//			Quantity = 15,
	//		};


	//		User user = new User()
	//		{
	//			Id = 1,
	//			UserName = "Ahmet",
	//			LastName = "Yılmaz"

	//		};

	//		//UserProduct userProduct = new UserProduct { 
	//		//	User = user,
	//		//	Product = product
	//		//};

	//		// Yukarıdaki normal kullanım aşağıdaki ise tuple kullanımı 

	//		var userProduct = (product, user);


	//		return View(userProduct);

	//	}


	//}



	#endregion

	#region Model Binding

	//public class ProductController : Controller
	//{

	//	public IActionResult GetProducts()
	//	{

	//		return View();	
	//	}

	//	public IActionResult CreateProduct()
	//	{

	//		return View();
	//	}

	//	[HttpPost]
	//	public IActionResult CreateProduct(string txtProductName, string txtQauntity)
	//	{

	//		return View();
	//	}

	//}

	#endregion

	#region Form İle Veri Alma

	//public class ProductController : Controller
	//{

	//	public IActionResult GetProducts()
	//	{

	//		return View();
	//	}

	//	public IActionResult CreateProduct()
	//	{

	//		return View();
	//	}
	//	[HttpPost]
	//	public IActionResult VeriAl(IFormCollection datas)
	//	{
	//		var value1 = datas["txtValue1"];
	//		var value2 = datas["txtValue2"];
	//		var value3 = datas["txtValue3"];

	//		return View();
	//	}
	//}

	#endregion

	#region Query String İle Veri Alma

	//public class ProductController : Controller
	//{

	//	public IActionResult GetProducts()
	//	{

	//		return View();
	//	}

	//	public IActionResult CreateProduct()
	//	{

	//		return View();
	//	}
	//	public IActionResult VeriAl(string a )
	//	{

	//		return View();
	//	}
	//}
	#endregion

	#region Header İle Veri Alma

	//public class ProductController : Controller
	//{

	//	public IActionResult GetProducts()
	//	{

	//		return View();
	//	}

	//	public IActionResult CreateProduct()
	//	{

	//		return View();
	//	}
	//	public IActionResult VeriAl()
	//	{
	//		var headers = Request.Headers.ToString;
	//		return View(); //Postman ile istek yapılıp incelendi.
	//	}
	//}

	#endregion

	#region Ajax Tabanlı Veri Alma


	//public class AjaxData
	//{
	//       public string A { get; set; }
	//       public string B { get; set; }
	//   }



	//public class ProductController : Controller
	//{

	//	public IActionResult GetProducts()
	//	{

	//		return View();
	//	}

	//	public IActionResult CreateProduct()
	//	{

	//		return View();
	//	}
	//	[HttpPost]	
	//	public IActionResult VeriAl(AjaxData ajaxData)
	//	{

	//		return View();
	//	}
	//}




	#endregion

	#region Tuple Örneği

	//public class ProductController : Controller
	//{

	//	public IActionResult GetProducts()
	//	{

	//		return View();
	//	}

	//	public IActionResult CreateProduct()
	//	{

	//		return View();
	//	}
	//	[HttpPost]
	//	public IActionResult CreateProduct([Bind (Prefix ="Item1")]Product product, [Bind(Prefix = "Item2")] User user) 
	//	{
	//		var tuple = (new Product(), new User());

	//		return View(tuple);
	//	}
	//}


	#endregion

	#region Validations

	public class ProductController : Controller
	{

		public IActionResult GetProducts()
		{

			return View();
		}

		public IActionResult CreateProduct()
		{

			return View();
		}
		[HttpPost]
		public IActionResult CreateProduct(Product model)
		{
			//ModelState: MVC'DE bir type'ın annotationslarının durumunu kontrol eden ve geriye sonuç dönen bir property.
			if (ModelState.IsValid)
			{
				//İşlem/Operasyona tabi tutulur.
				//Loglama
				//Kullanıcı bilgilendirme


				//ViewBag.HataMesaj = ModelState.Values.FirstOrDefault(x => x.ValidationState==Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;

				var messages = ModelState.ToList();

				return View(model);
			}
			return View();
		}
	}

	#endregion

}
