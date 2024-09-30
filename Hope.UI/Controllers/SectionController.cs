using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;



    namespace Hope.UI.Controllers
    {
        public class SectionController : Controller
        {
            public async Task<IActionResult> Index()
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://localhost:44386/api/Sections/GetAllSections");
                string apiresponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a list of costumedepartment objects
                var result = JsonConvert.DeserializeObject<List<costumedepartment>>(apiresponse);
                return View(result); // Pass the list to the view
            }

            public class costumedepartment
            {
                public int id { get; set; }
                public string name { get; set; }
            }
        }
    }