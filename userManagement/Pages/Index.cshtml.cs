using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using userManagement.Dtos;
using System.Net;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly string baseUrl = "https://localhost:7130/User";


    public IndexModel()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        _httpClient = new HttpClient(handler);
    }

    public List<UserDto> Users { get; set; } = new();
    [BindProperty]
    public AddUserDto NewUser { get; set; }
    [BindProperty]
    public UpdateUserDto EditUser { get; set; } = new();
    [BindProperty] public int DeleteUserId { get; set; }
    public string DebugInfo { get; set; }

    public async Task OnGetAsync()
    {
        Users = await _httpClient.GetFromJsonAsync<List<UserDto>>($"{baseUrl}/GetUsers") ?? new();
    }

    public async Task<IActionResult> OnPostAddUserAsync()
    {
        var response = await _httpClient.PostAsJsonAsync($"{baseUrl}/AddNewUsers", NewUser);

        if (!response.IsSuccessStatusCode)
        {
            return Page();
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostEditUserAsync()
    {
        var response = await _httpClient.PutAsJsonAsync($"{baseUrl}/UpdateUsers", EditUser);

        if (!response.IsSuccessStatusCode)
        {
            return Page();
        }
        return RedirectToPage();
    }


    public async Task<IActionResult> OnPostDeleteUserAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/DeleteUsers?userId={DeleteUserId}");
        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return Page();
        }

        return RedirectToPage();
    }

}
