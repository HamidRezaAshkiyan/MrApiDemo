using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MrApiDemo.Controllers;
using MrApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MrApiDemo.Pages
{

    public class IndexModel : PageModel
    {
        //static HttpClient client = new HttpClient();
        //public const string APIURL = "http://api.mrapi.ir/sandbox/send";
        //private const string pNumber = "989389283165";
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(string phoneNumber)
        {
            if (phoneNumber == null)
                return Page();

            HomeController.client.DefaultRequestHeaders.Clear();
            HomeController.client.DefaultRequestHeaders.Add("Authentication", HomeController.SandboxSecret);

            var response = await HomeController.client.PostAsJsonAsync(
                HomeController.SandboxSendAPI,
                new SendVerificationCodeModel(phoneNumber)
                );
            response.EnsureSuccessStatusCode();


            return RedirectToPage("VerifyPage", phoneNumber);
        }
    }
}
