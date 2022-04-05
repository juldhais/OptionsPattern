using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OptionsPattern.Options;
using OptionsPattern.Resources;

namespace OptionsPattern.Controllers;

[ApiController]
[Route("medicine")]
public class MedicineController : ControllerBase
{
    private readonly HttpClient _client;
    private readonly HalodocUrlOptions _options;

    // inject HttpClient service and IOptions to the constructor
    public MedicineController(HttpClient client, IOptions<HalodocUrlOptions> options)
    {
        _client = client;
        
        // set options value
        _options = options.Value; 
        
        // get "BaseUrl" value from options
        // "https://www.halodoc.com/api/v1/buy-medicine/categories/"
        _client.BaseAddress = new Uri(_options.BaseUrl);
    }

    // method to make a request and get the response from Halodoc API
    private async Task<MedicineResource?> GetResponse(string route)
    {
        var httpResponse = await _client.GetAsync(route);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<MedicineResource>(json);
        return resource;
    }
    
    [HttpGet("batuk-dan-flu")]
    public async Task<ActionResult> GetObatBatukDanFlu()
    {
        // get "BatukDanFlu" value from options
        // "batuk-dan-flu/products"
        var resource = await GetResponse(_options.BatukDanFlu);
        return Ok(resource);
    }

    [HttpGet("mata")]
    public async Task<ActionResult> GetObatMata()
    {
        // get "Mata" value from options
        // "mata/products"
        var resource = await GetResponse(_options.Mata);
        return Ok(resource);
    }
    
    [HttpGet("jantung")]
    public async Task<ActionResult> GetObatJantung()
    {
        // get "Jantung" value from options
        // "jantung/products"
        var resource = await GetResponse(_options.Jantung);
        return Ok(resource);
    }
}