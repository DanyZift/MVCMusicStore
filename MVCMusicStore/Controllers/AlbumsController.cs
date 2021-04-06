using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCMusicStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCMusicStore.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //Call our web api here
            // URL: https://localhost:5001/api/album
            IEnumerable<Album> albums = null;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = client.GetAsync("album");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<Album>>();
                    readJob.Wait();
                    albums = readJob.Result;
                }else
                {
                    //return error or empty value
                    albums = Enumerable.Empty<Album>();
                    ModelState.AddModelError(string.Empty, "No Albums were found!");
                }

            }

            return View(albums);

        }
    }
}
