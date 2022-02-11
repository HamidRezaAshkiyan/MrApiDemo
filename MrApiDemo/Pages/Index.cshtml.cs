using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MrApiDemo.Pages
{
    public class ApiRequest
    {
        public string PhoneNumber { get; set; }
        public string PatternID { get; set; } = "5bc1f3e6-fd7b-4300-aa89-514a299a4e97";
        public string Token { get; set; } = "c2FuZGJveGFIUjBjRG92TDIxeVlYQnBMbWx5";
        public string ProjectType { get; set; } = "1";

        public ApiRequest(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }    

    public class IndexModel : PageModel
    {
        static HttpClient client = new HttpClient();
        public const string APIURL = "http://api.mrapi.ir/sandbox/send";
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string phoneNumber)
        {

        }

        public async Task<IActionResult> OnPost(string phoneNumber)
        {
            
            if (ModelState.IsValid)
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authentication", "1MWOwEGOmNjN1UWNmFGOhdDM1MTYhBDZ4IWZ0MDNlRjOEVzNxUTQGJjM");

                var response = await client.PostAsJsonAsync(
                    APIURL, new ApiRequest(phoneNumber));
                response.EnsureSuccessStatusCode();


                return RedirectToPage("Index", phoneNumber);
            }
            else
            {
                return Page();
            }
        }

        
    }
}
