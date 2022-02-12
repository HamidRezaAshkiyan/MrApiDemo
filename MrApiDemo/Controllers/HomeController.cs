using Microsoft.AspNetCore.Mvc;
using MrApiDemo.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MrApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public static HttpClient client = new HttpClient();
        public const string SandboxVerifyAPI = "http://api.mrapi.ir/sandbox/verify";
        public const string SandboxSendAPI = "http://api.mrapi.ir/sandbox/send";
        public const string SandboxSecret = "1MWOwEGOmNjN1UWNmFGOhdDM1MTYhBDZ4IWZ0MDNlRjOEVzNxUTQGJjM";

        public IActionResult Index()
        {
            return View();
        }

        [Route("send")]
        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> Get(string phoneNumber)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authentication", SandboxSecret);

            var response = await client.PostAsJsonAsync(
                SandboxSendAPI, new SendVerificationCodeModel(phoneNumber));
            response.EnsureSuccessStatusCode();

            return RedirectToPage("Index", response);
        }

        [Route("verify")]
        [HttpGet("{verificationCode}")]
        public async Task<IActionResult> Get(string phoneNumber, string verificationCode)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authentication", SandboxSecret);

            var response = await client.PostAsJsonAsync(
                SandboxVerifyAPI, new VerifyCodeModel(phoneNumber, verificationCode));
            response.EnsureSuccessStatusCode();

            return RedirectToPage("Index", response);
        }

        /*public async Task<HttpResponseMessage> SendSandboxRequest<T>(string apiUrl, T content)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authentication", SandboxSecret);

            var response = await client.PostAsJsonAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();

            return response;
        }*/
    }
}
