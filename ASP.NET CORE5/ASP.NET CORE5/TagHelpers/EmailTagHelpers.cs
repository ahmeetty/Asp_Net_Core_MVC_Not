using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASP.NET_CORE5.TagHelpers
{
	//public class EmailTagHelpers : TagHelper
	//{

 //       public string Mail { get; set; }
 //       public string Display { get; set; }

 //       public override void Process(TagHelperContext context, TagHelperOutput output)
	//	{
	//		output.TagName = "a";
	//		output.Attributes.Add("href", $"Mailto:{Mail}");
	//		output.Content.Append(Display);
	//		//base.Process(context, output);
	//	}

		// Yukarıda bir tag helper ve içine property koydum çalısması için Process'in olması gerekmektedir.
		// Bir sınıfın taghelper olabilmesi için taghelper sınıfından türemesi kalıtım alması gerekmektedir.
		// TagHelper;'ın işlevsellik gösterebilmesi yani operayonu gerçekleştirebilmesi için Process metodunun override edilmesi gerekmektedir.
	//}
}
