using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddFluentValidation(config =>
	{
		// FluentValidation'� assembly'deki t�m validator'lar� bulup eklemesi i�in ayarla
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

// Default route tan�m� ekle
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"); // Default: Home controller, Index action

app.Run();








#region MVC ALT YAPISI OLU�TURMA

/*
 
 * MVC'de gelen iste�i kar��layan controller vard�r.  Bu Controller ihtiyaca g�re MODELE gidiyordu. Modelden ilgili veriyi al�yordu
  e�er ki varsa g�rselle�tirilme View'e gidiyordu View'den veriyi al�p tekrardan request edip client'a g�nderiyordu. Temel MVC sistemi budur.
 
 */

#endregion

#region Controller

// Uygulamaya gelen istekleri kar��layabilmek i�in kulland���m� s�n�flard�r.

// Controller s�n�flar� genellikle Contorllers klas�r� alt�nda tutulurlar.

// Controller s�n�flar�n�n isimlerinin sonuna Controller eki konulmas� gelenekseldir. Home.Contoller.cs

// Controller s�n�flar� i�erisinde istekleri kar��layan metodlara action metot denir.

// Controller s�n�flar� i�erisinde tan�mlanan t�m metodlar art�k action metod olarak neticelendirelecektir.

#endregion

#region View

// View dosyalar� .cshtml uzant�l� doyalard�r.

// cs + html + cshtml ==> Razor (Html i�erisinde C# kodlar�n� yazmam�z� sa�layan bir teknolojidir.)

#endregion

#region Action T�rleri

#region ViewResult

// Response olarak bir view dosyas�n� (.cshtml) render etmemizi sa�layan action t�r�d�r.

// Kullan�m�;

//public ViewResult GetProducts()
//{
//    ViewResult result = new ViewResult();
//    return result;

//}

// Bunun haricinde bir view result de�eri g�ndermek i�in yap�lacak harici bir i�lem yoktur.

#endregion

#region PartialViewResult

// Yine bir view dosyas�n� (.cshtml) render etmemizi sa�layan bir action t�r�d�r.

// ViewResult'tan temel fark�, client yap�lan Ajax isteklerinde kullan�ma yatk�n olmas�d�r.

// Bir sayfay� d���nelim sayfan�n tamam� ViewResult'tur. PartialViewResult'sa bir sayfan�n i�indeki par�an�n yap�s� olarak �rneklendirilebilir.

// Teknik fark ise ViewResult_ViewStart.cshtml dosyas�n� baz al�r. Lakin PartialViewResult ise ilgili dosyay� baz almadan render edilir.

// Kullan�m�;

//public PartialViewResult GetProducts()
//{

//    PartialViewResult result = PartialView();
//    return result;
//}


#endregion

#region JsonResult

// �retilen datay� JSON t�r�ne d�n��t�r�p  d�nd�ren bir action t�r�d�r.

// Kullan�m�;

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

// Bazen gelen istekler neticesinde herhangi bir �ey d�nd�rmek istemeyebiliriz. B�yle bir durumda EmptyResult kullan�l�r.

// Kullan�m�;
//public EmptyResult GetProducts()
//{
//    return new EmptyResult();
//}

#endregion

#region ContentResult

// �stek neticesinde cevap olarak metinsel bir de�er d�nd�rmemizi sa�layan action t�r�d�r.

//Kullan�m�;
//public ContentResult GetProducts()
//{

//    ContentResult result =  Content("falan filan k�d�wqif�wqg�q");
//    return result;
//}

#endregion

#region ActionResult

// Gelen bir istek neticesinde geriye d�nd�r�ecek action t�rleri de�i�kenlik g�sterebildi�i durumlarda kullan�ld��� action t�r�d�r.

// B�t�n result de�erlerinin base class'�d�r.

// Kullan�m� �u �ekildedir bir durumu kontrol ederken kullan�m�;
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

// Kullan�m� ve notu;

//public class ProductController : Controller
//{

//    public IActionResult Index()
//    {
//        X();
//        return View();
//    }
//    [NonAction] // Contoller i�erisinde NonAction attribute ile i�aretlenen fonskiyonlar d��ar�dan request kar��lamazlar. Sadece operatif yani algoritma bar�nd�ran/i� mant��� y��r�ten metottur.
//    public void X()
//    {
//        {


//        }
//    }

//}


#endregion

#region NonController Attribute

//Kullan�m� ve notu ;

//[NonController] // ProductController bir controller olmad���n� ifade eder. D��ardan request almaz normal bir s�n�f haline d�ner i�levsel controller olmaktan ��kar. Yani taray�c� �zerinden istek g�nderip �a��ramay�z.
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

#region Tuple Nesnesi Kullan�m� 

//var userProduct = (user, product); //Controller yerine

// @model (ASP.NET_CORE1.Models.Product, ASP.NET_CORE1.Models.User) //Bunuda cshtml yerine yazarak tuple nesnesi kullanarak birden �ok nesneyi g�ndeririz.


#endregion

#region Razor Nedir?
/*
 

* ASP.NET Core mimarisinde  cshtml dosyas�nda c# kodlar�n� yazmam�z� sa�layan bir teknolojidir.

* @ Operat�r� Razor operat�r�d�r.

*  Razor teknolojisinde yorum sat�r� �u �ekildedir; @* *@

* Razor ile de�i�ken olu�turma; 
 
string metin = "fkqpgwqpg�mkwqgq";


* Razor ile de�i�ken okuma;
 
int a =5;
Console.WriteLine(a);

* Razor �le Par�al� Scope Yap�s�
 
@{

             Par�al� scope yap�s�: B�t�n scopeler bir scope alt�ndaym�� gibi g�r�n�r.

}

* Razor ��erisinde HTML Kullan�m�

@{

<div></div> //Html kullanabilmekteyiz.

}

* Razor �le <text> Etiketi


if(true)
{

<text>Evet</text>

}
else
{

<text>Hay�r</text>


}


* Say�sal ��lemler 

<h3> @(5+4)</h3>
<h3> @(metin)</h3>
<h3> @metin</h3>


* Ternary Operat�r�


<h3> @(33 % 5 == 3 ? "Evet" : "Hay�r")</h3>



* Kou� yap�lar� 


@{
 int sayi = 5;
if(sayi == 5)
{
<h3>a�f�aig�ag�a</h3>

}
else
{

}


}



* D�ng�ler 


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
// Asp.NET Core MVC uygulamalar�nda url olu�turmak i�in yard�mc� metotlar i�eren  ve o anki url'e dair bizlere bilgi veren s�n�ft�r.

/*
 Metotlar: Action,ActionLink,Content,RouteUrl

Property: ActionContext

 */

#region Metotlar

/*
 
 * Action Metodu: Verilen Controller ve Action'a ait url olu�turmay� sa�layan metottur

 Kullan�m�;  Url.Action(" index ", "product", new {id = 5})
 
 
* ActionLink Metodu : Verilen Controller ve Action'a ait url olu�turmay� sa�layan metottur.
 Kullan�m� : Url.ActionLink(" index ", "product", new {id = 5})


* Content Metodu: Genellikle CSS ve Script gibi dosya diszinlerini programatik olarak tarif etmek i�in kullanmaktay�z.

Kullan�m�: Url.Content("~/site.css")

* UseStaticFiles middleware ile gelen static dosya yap�lanmas� bu metodun i�levselli�ini daha efektif �stlenmektedir.


* RouteUrl Metodu: Mimaride tan�ml� olan Route isimlerine uygun bir �ekilde url olu�turan bir metottur.
  Kullan�m�: Url.RouteUrl ("Default")
 
 
 * ActionContext Property: O anki url'e dair t�m bilgilere eri�ebilmemizi sa�layan bir propertydir.
 Kullan�m�; Url.ActionContext;  burda buna dair bilgileri vericektir.

 
 
 
 */

#endregion

#endregion

#region HtmlHelpers 


// Html etikerlerini server tabanl� olu�turmam�z� sa�layan s�zde yard�mc� bar�nd�rmakta.

// Hedeflenen .cshtml dosyalar�n� render etmemizi sa�lamakta.

// O anki context'e dait bilgiler edinmemizi sa�lamakta.

// Veri ta��ma kontrollerine eri�memizi sa�lamaktad�r.

/*

Metotlar�: Html.Partial,Html.RenderPartial,HtmlActionLink,Html Form Metotlar�

Propertyleri: ViewContext,TempData,ViewData,ViewBag
 
 */

#region Metotlar

/*
 
* Html.Partial Metodu: Hedef view'i render etmemizi sa�layan bir fonksiyondur.  
 Kullan�m�: @Html.Partial ("~/Views/Product/Index.cshtml")


* Html.RenderPartial: Hedef view'i render etmemizi sa�layan bir metottur.
 
Kullan�m�: @{Html.RenderPartial ("~/Views/Product/Index.cshtml");}


* Html.ActionLink Metodu: Url olu�turur.

Kullan�m�: @Html.ActionLink ("Anasayfa","Index","Home")

* Html Form Metotlar�

Kullan�c�yla etkile�ime girmemizi sa�layan form ve input nesneleri olu�turmam�z� sa�layan metotlard�r.





 */

#endregion


#endregion


#region TagHelper Nedir ?

/*
 
* Tag Helpers, daha okunabilir anla��labilir ve kolay geli�tirilebilir bir view in�a etmemizi sa�layan Asp.NET Core ile birlikte
HtmlHelpers'lar�n yerine gelen yap�lard�r.
 
* TagHelper'lar view'lerde ki kod maliyetini oldukca d���rmektedir.

 * HtmlHelpers'lar�n html nesnelerinin generate edilmesini server'a y�klemesini getirdi�i maliyetide ortadan kald�rmaktad�r.

 * HtmlHelpers'lar da ki programatik yap�lanma programlama bilmeyen tasar�mc�lar�n �al��mas�n� imkans�z hale getirmektedir.
TagHelpers'lar ile buradaki kusur giderildi ve tasar�mc�lar a��s�ndan programlama bilgisine ihtiya� duyulmaks�z�n �al��ma yap�labilir nitelik kazand�rd�.
 
 */

#endregion

#endregion

#region View Kullan�m� ve Viewe veri ta��ma 

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
//		#region Model Bazl� veri Ta��ma
//		//return View(products);
//		#endregion

//		#region Veri Ta��ma Controlleri
//		#region ViewBag
//		// View'e g�nderilecek ta��nacak datay� dynamic �ekilde tan�mlanan bir de�i�kenle ta��mam�z� sa�layan bir ta��ma kontrol�d�r.

//		ViewBag.Products = products;

//		#endregion

//		#region ViewData
//		// ViewBag'de oldu�u gibi acitondaki datay� view'e ta��mam�z� sa�layan bir kontrold�r.
//		ViewData["products"] = products;


//		#endregion

//		#region TempData
//		// ViewData'de oldu�u gibi acitondaki datay� view'e ta��mam�z� sa�layan bir kontrold�r.
//		TempData["products"] = products;
//		#endregion



//		#endregion

//		return View();
//	}
//}
#endregion

#region Kullan�can Veri Alma Y�ntemleri

#region Query String

// G�venlik gerektirmeyen bilgilerin url �zerinde ta��nmas� i�in kullan�lan yap�lanmalard�r.

// Yap�lan request'in her ne olursa olsun query string de�erleri ta��nabilir. 

// Taray�c� �zerinden domain girildikten sonra ?a= 5 diye tan�mlan�r.

#endregion

#endregion

#region Kullan�can Gelen Verilerin Do�rulanmas�

#region Validations

/*
 
Bir de�erin i�inde bulundu�u sartlara uygun olmas� durumudur.

Beklenen kosullra ve amaca uygun olup olmama durumunu kontrol edilmesidir. Bu kontrollere g�re verinin i�leme tabi tutulmas� durumudur. 
 
 Validation client ve server taban�nda paralel bir �ekilde uygulanmal�d�r. BU kesinlikle yap�lmal�d�r. �rne�in bir bankacal�k uygulamas�na girerken client'ta her ne kadar bir do�rulama sistemi varsa server bazl� da olmal�d�r.
 
 */


#endregion

#endregion

#region Layout Nedir?

/*
 
 * Web sayfalar�n olmazsa olmaz�d�r.
 * Sayfadan sayfaya gezinirken kullan�c�ya tutarl� bir deneyim sa�layan ortak sayfa tasla��d�r.
 * Tutarl� bir d�zene sahip web sitesi olu�turmak i�in kullan�l�r.
 * Layout dosyaas� �z�nde bir .cshtml dosyas�d�r.
 * Olu�turulma s�reci views alt�nda shared dosyas� i�erisinde olu�turulur.
 * RenderBody() ile sabit de�erler belirlenir.  Layout �zerinde o an ki render edilenView'�n resultunu nereye bas�laca��n� ifade eden fonksiyondur.
 * RenderSeciton() : Layout i�erisinde isimsel b�l�mler olu�turmam�z� sa�lar. �htiya� do�rultusunda bu b�l�mler render edilen viewlerden de i�erikler atanabilir.
 
 
 */

#region _ViewStart Dosyas� Nedir

/*
 
 As�l amac� t�m viewler de kullan�lmas� yap�lmas� gereken otak �al��malar�n yap�ld��� viewdir.

Bir nevi t�m viewlerin atas�d�r diyebiliriz.

Views klas�r� alt�nda _ViewStart.cshtml olarak olu�turulmas� gerekir.

Genellikle t�m viewlerin ortak kullanaca�� Layout tan�mlamas� bu dosya i�erisinde ger�ekle�tirilir.
 
 */



#endregion

#region _ViewImports Dosyas� Nedir

/*
 
 Razor sayfalar� i�in k�t�phane ve namespace tan�mlamalar�n� sayfa sayfa farkl tan�maktansa ortak merkezi olarak tan�mlamam�z� sa�layan bir dosyad�r.

Views klas�r� alt�nda _ViewImports.cshtml isminde olu�turulmal�d�r.
 
 
 */

#endregion

#endregion

#region PartialView Nedir?


/*
 
Mod�ler tasar�mda mod�l�n ayr� bir .cshtml par�a olarak tasarlanmas�n� ve ihtiya� 
do�rultusunda ilgili par�an�n �a��r�l�p kullan�lmas�n� sa�layan bir y�ntemdir.
 
 
 */

#endregion

#region ViewCompenent Nedir ?

/*
 
PartialView yap�lanmas� ihtiyac� olan datalar� Controller �zerinden elde edece�i 
i�in Controller'daki maliyeti artt�rmakta ve SOL�D prensiplerine ayk�r� davran�lmas�na sebebiyet vermektedir.


ViewCompenent ihtiyac� olan datalar� controller �zerinden de�il direkt olarak kendi cs dosyas�ndan elde edebilmektedir. B�ylece controllerdaki l�zumsuz
maliyeti ortadan kald�rm�s olmaktay�z.


Tasarlanan VC. �a��r�l�p render edildi�inde i�erisinde �al��mas�n� istedi�imiz kodlar� a�a��daki imza ile tan�mlamal�y�z.

public IViewCompenentResult Invoke()
{

}
 
 
 
 */

#endregion

#region Middleware Nedir ?

/*
 
Web uygulamas�nda client'tan gelen request'e kar��l�k verilecek response'a kadar arada farkl� i�lemler ger�kel�tirmek ve s�recin
gidi�at�na farkl� y�n vermek isteyebiliriz.

Middleware sarmal bir �ekilde tetiklenirler. Heryerde ayn� �al��ma mekanizmas�na sahiptir sadece Asp.Net Core i�in ge�erli de�ildir.

Configure metodu i�erisinde middleware'ler �a��r�l�r.

Asp.Net Core mimarisinde t�m mmiddlewareler Use ad�yla baslar.

Middleware'lerde tetiklenme s�ras� �nemlidir.
 
 */

#region Haz�r Middleware'ler

/*
 Run   Use   Map    MapWhen
 
 */

#region Run

// Run fonksiyonu kendisinden sonra gelen middleware'i tetiklemez.

#endregion

#region Use

// Run metoduna nazaran devreye girdikten sonra s�re�te s�radaki middleware'i �a��rmakta ve normal biddleware i�levi bikttikten sonra geriye d�n�p devam edilebilen bir yap�ya sahiptir.

#endregion

#region Map
// Bazen �iddleware'i talep g�nderen path'e g�re filtrelemek isteyebiliriz. Bunun i�in Use ya da Run fonksiyonlar�nda if kontrol� sa�layabilir yahut Map Metodu ile daha profesyonel i�lem yapabiliriz.

#endregion

#region MapWhen

// Map metodu ile sadece rquest'in yap�ld��� path'e g�re filtreleme yap�l�rken MapWhen metodu ile gelen request'in herhangi bir �zelli�ine g�re bir filtreleme i�lemi ger�ekle�tirilebilir.

#endregion

#endregion

#endregion

#region Dependency Injection Nedir

/*
 
Ba��l�l�k olu�turacak par�alar�n ayr�l�p bunlar�n d��ar�dan verilmesiyle sistem i�erisine minmize etme i�lemidir.

Dependency Injection ba��ml�l�klar� soyutlamak demektir.
 
 
 */

#region IoC Nedir

/*

S�n�flar�m�z�n ba��ml�l���n� azaltmak i�in ba��ml�l�klar� Dependency Injection ile d��ar�dan alabiliriz demi�tik.

Ancak baz� durumlarda s�n�f�m�z i�erisinde �ok say�da aray�ze referans vermemiz gerekebilir.

Bu durumda her biri i�in dependency injection kodu yazmam�z gerekecektir ki bu durum sonunda bir kod karma�as�na neden olacakt�r.

Bunun i�in bu i�lemi otomatikle�tirecek bir yap� kurmam�z gerekecektir.

 IoC �al��ma Mant��� 

Dependency Injection kullan�larak enjekte edilecek olan t�m de�erler/nesneler IoC Container dedi�imiz bir s�n�fta tutulurlar
ve ihtiya� do�rultusunda bu de�erler/nesneler �a��r�larak elde edilirler.
 
 */

#region Asp.NET Core'da IoC Yap�lanmas�

/*
 
 .NET uygulamalar�nda IoC yap�lanmas�n� sa�layan third party frameworkler mevcuttur.

Structuremap, AutoFac, Ninject...

 
Built-in IoC Container: Built-in IoC Container i�erisinde koyulacak de�erleri nesleleri �c farkl� davran��la alabilmektedir.

Singleton: Uygulamada baz� tekil nesne olu�turur. T�m taleplere o nesneyi g�nderir.

Scoped: Her request ba��an bir nesne �retir ve o request pipeline'�nda t�m istekler o nesneyi g�nderir.

Transient: Her request'in talebine kar��l�k bir nesne �retir ve g�nderir.

 */

#endregion

#endregion

#endregion

#region Area Nedir

/*
 
Web uygulamas�nda farkl� i�levsellikleri ay�rmak i�in kullan�lan aray�zd�r.
 
Bu farkl� i�levsellikler i�in farkl� katmanda bir route ayarlamam�z� sa�layan ve bu katmanda o i�leve �zel y�netim sergileyen bir yap�lanmad�r.
 
Her bir area i�erisindeki controller'laraq eri�im i�in farkl� bir route sa�lamaktad�r.

Dolay�s�yla bu route'lar�n taraf�m�zca tasarlanmas� gerekmektedir.



MapAreaControllerRoute Fonksiyonu

MapControllerRoute Default area rotas� belirlememizi sa�lar.

MapAreaControllerRoute ise bir areya ait �zel rota belirlememizi sa�lar.


 */

#endregion
