using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddFluentValidation(config =>
	{
		// FluentValidation'ý assembly'deki tüm validator'larý bulup eklemesi için ayarla
		config.RegisterValidatorsFromAssemblyContaining<Program>();
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route tanýmý ekle
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"); // Default: Home controller, Index action

app.Run();








#region MVC ALT YAPISI OLUÞTURMA

/*
 
 * MVC'de gelen isteði karþýlayan controller vardýr.  Bu Controller ihtiyaca göre MODELE gidiyordu. Modelden ilgili veriyi alýyordu
  eðer ki varsa görselleþtirilme View'e gidiyordu View'den veriyi alýp tekrardan request edip client'a gönderiyordu. Temel MVC sistemi budur.
 
 */

#endregion

#region Controller

// Uygulamaya gelen istekleri karþýlayabilmek için kullandýðýmý sýnýflardýr.

// Controller sýnýflarý genellikle Contorllers klasörü altýnda tutulurlar.

// Controller sýnýflarýnýn isimlerinin sonuna Controller eki konulmasý gelenekseldir. Home.Contoller.cs

// Controller sýnýflarý içerisinde istekleri karþýlayan metodlara action metot denir.

// Controller sýnýflarý içerisinde tanýmlanan tüm metodlar artýk action metod olarak neticelendirelecektir.

#endregion

#region View

// View dosyalarý .cshtml uzantýlý doyalardýr.

// cs + html + cshtml ==> Razor (Html içerisinde C# kodlarýný yazmamýzý saðlayan bir teknolojidir.)

#endregion

#region Action Türleri

#region ViewResult

// Response olarak bir view dosyasýný (.cshtml) render etmemizi saðlayan action türüdür.

// Kullanýmý;

//public ViewResult GetProducts()
//{
//    ViewResult result = new ViewResult();
//    return result;

//}

// Bunun haricinde bir view result deðeri göndermek için yapýlacak harici bir iþlem yoktur.

#endregion

#region PartialViewResult

// Yine bir view dosyasýný (.cshtml) render etmemizi saðlayan bir action türüdür.

// ViewResult'tan temel farký, client yapýlan Ajax isteklerinde kullanýma yatkýn olmasýdýr.

// Bir sayfayý düþünelim sayfanýn tamamý ViewResult'tur. PartialViewResult'sa bir sayfanýn içindeki parçanýn yapýsý olarak örneklendirilebilir.

// Teknik fark ise ViewResult_ViewStart.cshtml dosyasýný baz alýr. Lakin PartialViewResult ise ilgili dosyayý baz almadan render edilir.

// Kullanýmý;

//public PartialViewResult GetProducts()
//{

//    PartialViewResult result = PartialView();
//    return result;
//}


#endregion

#region JsonResult

// Üretilen datayý JSON türüne dönüþtürüp  döndüren bir action türüdür.

// Kullanýmý;

//public JsonResult GetProducts()
//{
//    JsonResult result = Json(new Product

//    {

//        Id = 5,
//        ProductName = "Terlik",
//        Quantity = 15
//    });





#endregion

#region EmptyResult

// Bazen gelen istekler neticesinde herhangi bir þey döndürmek istemeyebiliriz. Böyle bir durumda EmptyResult kullanýlýr.

// Kullanýmý;
//public EmptyResult GetProducts()
//{
//    return new EmptyResult();
//}

#endregion

#region ContentResult

// Ýstek neticesinde cevap olarak metinsel bir deðer döndürmemizi saðlayan action türüdür.

//Kullanýmý;
//public ContentResult GetProducts()
//{

//    ContentResult result =  Content("falan filan kðdöwqifçwqgþq");
//    return result;
//}

#endregion

#region ActionResult

// Gelen bir istek neticesinde geriye döndürüecek action türleri deðiþkenlik gösterebildiði durumlarda kullanýldýðý action türüdür.

// Bütün result deðerlerinin base class'ýdýr.

// Kullanýmý þu þekildedir bir durumu kontrol ederken kullanýmý;
//public ActionResult GetProducts()
//{

//    if(true)
//    {
//        //...

//        return Json(new object());

//    }
//    else if (true) 
//        {
//        return Content("kdsapfpfkq");
//    }
//    return View();

//}

#endregion


#region NonAction Attribute

// Kullanýmý ve notu;

//public class ProductController : Controller
//{

//    public IActionResult Index()
//    {
//        X();
//        return View();
//    }
//    [NonAction] // Contoller içerisinde NonAction attribute ile iþaretlenen fonskiyonlar dýþarýdan request karþýlamazlar. Sadece operatif yani algoritma barýndýran/iþ mantýðý yüürüten metottur.
//    public void X()
//    {
//        {


//        }
//    }

//}


#endregion

#region NonController Attribute

//Kullanýmý ve notu ;

//[NonController] // ProductController bir controller olmadýðýný ifade eder. Dýþardan request almaz normal bir sýnýf haline döner iþlevsel controller olmaktan çýkar. Yani tarayýcý üzerinden istek gönderip çaðýramayýz.
//public class ProductController : Controller
//{

//    public IActionResult Index()
//    {
//        X();
//        return View();
//    }
//    public void X()
//    {
//        {


//        }
//    }

//}



#endregion

#endregion

#region Tuple Nesnesi Kullanýmý 

//var userProduct = (user, product); //Controller yerine

// @model (ASP.NET_CORE1.Models.Product, ASP.NET_CORE1.Models.User) //Bunuda cshtml yerine yazarak tuple nesnesi kullanarak birden çok nesneyi göndeririz.


#endregion

#region Razor Nedir?
/*
 

* ASP.NET Core mimarisinde  cshtml dosyasýnda c# kodlarýný yazmamýzý saðlayan bir teknolojidir.

* @ Operatörü Razor operatörüdür.

*  Razor teknolojisinde yorum satýrý þu þekildedir; @* *@

* Razor ile deðiþken oluþturma; 
 
string metin = "fkqpgwqpgþmkwqgq";


* Razor ile deðiþken okuma;
 
int a =5;
Console.WriteLine(a);

* Razor Ýle Parçalý Scope Yapýsý
 
@{

             Parçalý scope yapýsý: Bütün scopeler bir scope altýndaymýþ gibi görünür.

}

* Razor Ýçerisinde HTML Kullanýmý

@{

<div></div> //Html kullanabilmekteyiz.

}

* Razor Ýle <text> Etiketi


if(true)
{

<text>Evet</text>

}
else
{

<text>Hayýr</text>


}


* Sayýsal Ýþlemler 

<h3> @(5+4)</h3>
<h3> @(metin)</h3>
<h3> @metin</h3>


* Ternary Operatörü


<h3> @(33 % 5 == 3 ? "Evet" : "Hayýr")</h3>



* Kouþ yapýlarý 


@{
 int sayi = 5;
if(sayi == 5)
{
<h3>aöfðaigöagða</h3>

}
else
{

}


}



* Döngüler 


@foreach(var item in collection)
{

}

@for (int i = 0; i< lenght; i++)
{

}

 
 */


#endregion

#region Helpers 

#region UrlHelperss
// Asp.NET Core MVC uygulamalarýnda url oluþturmak için yardýmcý metotlar içeren  ve o anki url'e dair bizlere bilgi veren sýnýftýr.

/*
 Metotlar: Action,ActionLink,Content,RouteUrl

Property: ActionContext

 */

#region Metotlar

/*
 
 * Action Metodu: Verilen Controller ve Action'a ait url oluþturmayý saðlayan metottur

 Kullanýmý;  Url.Action(" index ", "product", new {id = 5})
 
 
* ActionLink Metodu : Verilen Controller ve Action'a ait url oluþturmayý saðlayan metottur.
 Kullanýmý : Url.ActionLink(" index ", "product", new {id = 5})


* Content Metodu: Genellikle CSS ve Script gibi dosya diszinlerini programatik olarak tarif etmek için kullanmaktayýz.

Kullanýmý: Url.Content("~/site.css")

* UseStaticFiles middleware ile gelen static dosya yapýlanmasý bu metodun iþlevselliðini daha efektif üstlenmektedir.


* RouteUrl Metodu: Mimaride tanýmlý olan Route isimlerine uygun bir þekilde url oluþturan bir metottur.
  Kullanýmý: Url.RouteUrl ("Default")
 
 
 * ActionContext Property: O anki url'e dair tüm bilgilere eriþebilmemizi saðlayan bir propertydir.
 Kullanýmý; Url.ActionContext;  burda buna dair bilgileri vericektir.

 
 
 
 */

#endregion

#endregion

#region HtmlHelpers 


// Html etikerlerini server tabanlý oluþturmamýzý saðlayan sözde yardýmcý barýndýrmakta.

// Hedeflenen .cshtml dosyalarýný render etmemizi saðlamakta.

// O anki context'e dait bilgiler edinmemizi saðlamakta.

// Veri taþýma kontrollerine eriþmemizi saðlamaktadýr.

/*

Metotlarý: Html.Partial,Html.RenderPartial,HtmlActionLink,Html Form Metotlarý

Propertyleri: ViewContext,TempData,ViewData,ViewBag
 
 */

#region Metotlar

/*
 
* Html.Partial Metodu: Hedef view'i render etmemizi saðlayan bir fonksiyondur.  
 Kullanýmý: @Html.Partial ("~/Views/Product/Index.cshtml")


* Html.RenderPartial: Hedef view'i render etmemizi saðlayan bir metottur.
 
Kullanýmý: @{Html.RenderPartial ("~/Views/Product/Index.cshtml");}


* Html.ActionLink Metodu: Url oluþturur.

Kullanýmý: @Html.ActionLink ("Anasayfa","Index","Home")

* Html Form Metotlarý

Kullanýcýyla etkileþime girmemizi saðlayan form ve input nesneleri oluþturmamýzý saðlayan metotlardýr.





 */

#endregion


#endregion


#region TagHelper Nedir ?

/*
 
* Tag Helpers, daha okunabilir anlaþýlabilir ve kolay geliþtirilebilir bir view inþa etmemizi saðlayan Asp.NET Core ile birlikte
HtmlHelpers'larýn yerine gelen yapýlardýr.
 
* TagHelper'lar view'lerde ki kod maliyetini oldukca düþürmektedir.

 * HtmlHelpers'larýn html nesnelerinin generate edilmesini server'a yüklemesini getirdiði maliyetide ortadan kaldýrmaktadýr.

 * HtmlHelpers'lar da ki programatik yapýlanma programlama bilmeyen tasarýmcýlarýn çalýþmasýný imkansýz hale getirmektedir.
TagHelpers'lar ile buradaki kusur giderildi ve tasarýmcýlar açýsýndan programlama bilgisine ihtiyaç duyulmaksýzýn çalýþma yapýlabilir nitelik kazandýrdý.
 
 */

#endregion

#endregion

#region View Kullanýmý ve Viewe veri taþýma 

//public class ProductController : Controller
//{
//	public IActionResult Index()
//	{
//		var products = new List<Product>
//	{
//		new Product { Id = 1, ProductName = "A Product", Quantity = 10 },
//		new Product { Id = 2, ProductName = "B Product", Quantity = 15 },
//		new Product { Id = 3, ProductName = "C Product", Quantity = 20 }
//	};
//		#region Model Bazlý veri Taþýma
//		//return View(products);
//		#endregion

//		#region Veri Taþýma Controlleri
//		#region ViewBag
//		// View'e gönderilecek taþýnacak datayý dynamic þekilde tanýmlanan bir deðiþkenle taþýmamýzý saðlayan bir taþýma kontrolüdür.

//		ViewBag.Products = products;

//		#endregion

//		#region ViewData
//		// ViewBag'de olduðu gibi acitondaki datayý view'e taþýmamýzý saðlayan bir kontroldür.
//		ViewData["products"] = products;


//		#endregion

//		#region TempData
//		// ViewData'de olduðu gibi acitondaki datayý view'e taþýmamýzý saðlayan bir kontroldür.
//		TempData["products"] = products;
//		#endregion



//		#endregion

//		return View();
//	}
//}
#endregion

#region Kullanýcan Veri Alma Yöntemleri

#region Query String

// Güvenlik gerektirmeyen bilgilerin url üzerinde taþýnmasý için kullanýlan yapýlanmalardýr.

// Yapýlan request'in her ne olursa olsun query string deðerleri taþýnabilir. 

// Tarayýcý üzerinden domain girildikten sonra ?a= 5 diye tanýmlanýr.

#endregion

#endregion

#region Kullanýcan Gelen Verilerin Doðrulanmasý

#region Validations

/*
 
Bir deðerin içinde bulunduðu sartlara uygun olmasý durumudur.

Beklenen kosullra ve amaca uygun olup olmama durumunu kontrol edilmesidir. Bu kontrollere göre verinin iþleme tabi tutulmasý durumudur. 
 
 Validation client ve server tabanýnda paralel bir þekilde uygulanmalýdýr. BU kesinlikle yapýlmalýdýr. Örneðin bir bankacalýk uygulamasýna girerken client'ta her ne kadar bir doðrulama sistemi varsa server bazlý da olmalýdýr.
 
 */


#endregion

#endregion

#region Layout Nedir?

/*
 
 * Web sayfalarýn olmazsa olmazýdýr.
 * Sayfadan sayfaya gezinirken kullanýcýya tutarlý bir deneyim saðlayan ortak sayfa taslaðýdýr.
 * Tutarlý bir düzene sahip web sitesi oluþturmak için kullanýlýr.
 * Layout dosyaasý özünde bir .cshtml dosyasýdýr.
 * Oluþturulma süreci views altýnda shared dosyasý içerisinde oluþturulur.
 * RenderBody() ile sabit deðerler belirlenir.  Layout üzerinde o an ki render edilenView'ýn resultunu nereye basýlacaðýný ifade eden fonksiyondur.
 * RenderSeciton() : Layout içerisinde isimsel bölümler oluþturmamýzý saðlar. Ýhtiyaç doðrultusunda bu bölümler render edilen viewlerden de içerikler atanabilir.
 
 
 */

#region _ViewStart Dosyasý Nedir

/*
 
 Asýl amacý tüm viewler de kullanýlmasý yapýlmasý gereken otak çalýþmalarýn yapýldýðý viewdir.

Bir nevi tüm viewlerin atasýdýr diyebiliriz.

Views klasörð altýnda _ViewStart.cshtml olarak oluþturulmasý gerekir.

Genellikle tüm viewlerin ortak kullanacaðý Layout tanýmlamasý bu dosya içerisinde gerçekleþtirilir.
 
 */



#endregion

#region _ViewImports Dosyasý Nedir

/*
 
 Razor sayfalarý için kütüphane ve namespace tanýmlamalarýný sayfa sayfa farkl tanýmaktansa ortak merkezi olarak tanýmlamamýzý saðlayan bir dosyadýr.

Views klasörü altýnda _ViewImports.cshtml isminde oluþturulmalýdýr.
 
 
 */

#endregion

#endregion

#region PartialView Nedir?


/*
 
Modüler tasarýmda modülün ayrý bir .cshtml parça olarak tasarlanmasýný ve ihtiyaç 
doðrultusunda ilgili parçanýn çaðýrýlýp kullanýlmasýný saðlayan bir yöntemdir.
 
 
 */

#endregion

#region ViewCompenent Nedir ?

/*
 
PartialView yapýlanmasý ihtiyacý olan datalarý Controller üzerinden elde edeceði 
için Controller'daki maliyeti arttýrmakta ve SOLÝD prensiplerine aykýrý davranýlmasýna sebebiyet vermektedir.


ViewCompenent ihtiyacý olan datalarý controller üzerinden deðil direkt olarak kendi cs dosyasýndan elde edebilmektedir. Böylece controllerdaki lüzumsuz
maliyeti ortadan kaldýrmýs olmaktayýz.


Tasarlanan VC. çaðýrýlýp render edildiðinde içerisinde çalýþmasýný istediðimiz kodlarý aþaðýdaki imza ile tanýmlamalýyýz.

public IViewCompenentResult Invoke()
{

}
 
 
 
 */

#endregion

#region Middleware Nedir ?

/*
 
Web uygulamasýnda client'tan gelen request'e karþýlýk verilecek response'a kadar arada farklý iþlemler gerçkelþtirmek ve sürecin
gidiþatýna farklý yön vermek isteyebiliriz.

Middleware sarmal bir þekilde tetiklenirler. Heryerde ayný çalýþma mekanizmasýna sahiptir sadece Asp.Net Core için geçerli deðildir.

Configure metodu içerisinde middleware'ler çaðýrýlýr.

Asp.Net Core mimarisinde tüm mmiddlewareler Use adýyla baslar.

Middleware'lerde tetiklenme sýrasý önemlidir.
 
 */

#region Hazýr Middleware'ler

/*
 Run   Use   Map    MapWhen
 
 */

#region Run

// Run fonksiyonu kendisinden sonra gelen middleware'i tetiklemez.

#endregion

#region Use

// Run metoduna nazaran devreye girdikten sonra süreçte sýradaki middleware'i çaðýrmakta ve normal biddleware iþlevi bikttikten sonra geriye dönüp devam edilebilen bir yapýya sahiptir.

#endregion

#region Map
// Bazen öiddleware'i talep gönderen path'e göre filtrelemek isteyebiliriz. Bunun için Use ya da Run fonksiyonlarýnda if kontrolü saðlayabilir yahut Map Metodu ile daha profesyonel iþlem yapabiliriz.

#endregion

#region MapWhen

// Map metodu ile sadece rquest'in yapýldýðý path'e göre filtreleme yapýlýrken MapWhen metodu ile gelen request'in herhangi bir özelliðine göre bir filtreleme iþlemi gerçekleþtirilebilir.

#endregion

#endregion

#endregion

#region Dependency Injection Nedir

/*
 
Baðýlýlýk oluþturacak parçalarýn ayrýlýp bunlarýn dýþarýdan verilmesiyle sistem içerisine minmize etme iþlemidir.

Dependency Injection baðýmlýlýklarý soyutlamak demektir.
 
 
 */

#region IoC Nedir

/*

Sýnýflarýmýzýn baðýmlýlýðýný azaltmak için baðýmlýlýklarý Dependency Injection ile dýþarýdan alabiliriz demiþtik.

Ancak bazý durumlarda sýnýfýmýz içerisinde çok sayýda arayüze referans vermemiz gerekebilir.

Bu durumda her biri için dependency injection kodu yazmamýz gerekecektir ki bu durum sonunda bir kod karmaþasýna neden olacaktýr.

Bunun için bu iþlemi otomatikleþtirecek bir yapý kurmamýz gerekecektir.

 IoC Çalýþma Mantýðý 

Dependency Injection kullanýlarak enjekte edilecek olan tüm deðerler/nesneler IoC Container dediðimiz bir sýnýfta tutulurlar
ve ihtiyaç doðrultusunda bu deðerler/nesneler çaðýrýlarak elde edilirler.
 
 */

#region Asp.NET Core'da IoC Yapýlanmasý

/*
 
 .NET uygulamalarýnda IoC yapýlanmasýný saðlayan third party frameworkler mevcuttur.

Structuremap, AutoFac, Ninject...

 
Built-in IoC Container: Built-in IoC Container içerisinde koyulacak deðerleri nesleleri üc farklý davranýþla alabilmektedir.

Singleton: Uygulamada bazý tekil nesne oluþturur. Tüm taleplere o nesneyi gönderir.

Scoped: Her request baþýan bir nesne üretir ve o request pipeline'ýnda tüm istekler o nesneyi gönderir.

Transient: Her request'in talebine karþýlýk bir nesne üretir ve gönderir.

 */

#endregion

#endregion

#endregion

#region Area Nedir

/*
 
Web uygulamasýnda farklý iþlevsellikleri ayýrmak için kullanýlan arayüzdür.
 
Bu farklý iþlevsellikler için farklý katmanda bir route ayarlamamýzý saðlayan ve bu katmanda o iþleve özel yönetim sergileyen bir yapýlanmadýr.
 
Her bir area içerisindeki controller'laraq eriþim için farklý bir route saðlamaktadýr.

Dolayýsýyla bu route'larýn tarafýmýzca tasarlanmasý gerekmektedir.



MapAreaControllerRoute Fonksiyonu

MapControllerRoute Default area rotasý belirlememizi saðlar.

MapAreaControllerRoute ise bir areya ait özel rota belirlememizi saðlar.


 */

#endregion
