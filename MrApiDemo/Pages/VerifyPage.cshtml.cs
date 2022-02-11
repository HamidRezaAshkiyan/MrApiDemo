using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MrApiDemo.Controllers;
using MrApiDemo.Models;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MrApiDemo.Pages
{
    public class VerifyPageModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string phoneNumber, string verificationCode)
        {
            HomeController.client.DefaultRequestHeaders.Clear();
            HomeController.client.DefaultRequestHeaders.Add("Authentication", HomeController.SandboxSecret);

            var response = await HomeController.client.PostAsJsonAsync(
                HomeController.SandboxVerifyAPI,
                new VerifyCodeModel(phoneNumber, verificationCode)
                );
            response.EnsureSuccessStatusCode();

            Console.WriteLine(response);
            return null;
            //return RedirectToPage("Index", response);
        }
    }
}
