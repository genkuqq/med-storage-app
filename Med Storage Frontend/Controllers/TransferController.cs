using Med_Storage_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Med_Storage_Frontend.Controllers
{
    public class TransferController : Controller
    {
        Uri address = new Uri("https://localhost:7138/api");
        private readonly HttpClient _httpClient;

        public TransferController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = address;
        }
        [HttpGet]
        public ActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/transfer").Result;
            if (response != null)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                List<TransferModel>? transfers = JsonConvert.DeserializeObject<List<TransferModel>>(data);
                return View(transfers);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/transfer/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    TransferModel? transfer = JsonConvert.DeserializeObject<TransferModel>(data);
                    return View(transfer);
                }
                TempData["errorMessage"] = responseMessage.Content.ReadAsStringAsync().Result; // Corrected error message extraction
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/transfer/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    TransferModel? transfer = JsonConvert.DeserializeObject<TransferModel>(data);
                    Console.WriteLine(transfer);
                    return View(transfer);
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

    }
}
