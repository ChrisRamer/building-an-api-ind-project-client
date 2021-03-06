using AnimalShelterClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AnimalShelterClient.Controllers
{
	public class HomeController : Controller
	{
		static List<string> apiVersions = new List<string>()
		{
			"1.0",
			"2.0",
			"3.0",
			"4.0",
			"5.0",
			"6.0"
		};

		[HttpGet("/")]
		public ActionResult Index()
		{
			List<SelectListItem> versions = apiVersions.ConvertAll(v => new SelectListItem
			{
				Text = v,
				Value = v,
			});
			ViewBag.VersionList = versions;
			return View();
		}

		[HttpPost("/")]
		public ActionResult Index(SelectListItem test)
		{
			double version = double.Parse(Request.Form["VersionList"]);
			ApiHelper.ApiVersion = version;

			if (version == 6) return RedirectToAction("Egg", "Animals");

			return RedirectToAction("Index", "Animals", new { version = version });
		}
	}
}