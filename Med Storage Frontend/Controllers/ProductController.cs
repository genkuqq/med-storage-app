﻿using System.Net;
using System.Text;
using Med_Storage_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.ContentModel;

namespace Med_Storage_Frontend.Controllers
{
    public class ProductController : Controller
    {
        Uri address = new Uri("https://localhost:7138/api");
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = address;
        }
        [HttpGet]
        public ActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress+"/product").Result;
            if (response != null)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                List<ProductModel>? products = JsonConvert.DeserializeObject<List<ProductModel>>(data);
                return View(products);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            try
            {
                string productData = JsonConvert.SerializeObject(productModel);
                StringContent stringContent = new StringContent(productData, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = _httpClient.PostAsync(address + "/product/", stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Product Created.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/product/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    ProductModel? product = JsonConvert.DeserializeObject<ProductModel>(data);
                    return View(product);
                }
                return View();
            }
            catch(Exception ex) {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            
            
        }
        [HttpPost]
        public ActionResult Edit(int id, ProductModel productModel)
        {
            try
            {
                string productData = JsonConvert.SerializeObject(productModel);
                StringContent stringContent = new StringContent(productData, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = _httpClient.PutAsync(_httpClient.BaseAddress + "/product", stringContent).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Product updated successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Failed to update product.";
                    return View(productModel);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(productModel);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/product/" + id).Result;
                if (responseMessage.IsSuccessStatusCode) {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    ProductModel? product = JsonConvert.DeserializeObject<ProductModel>(data);
                    return View(product);
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id) {
            try
            {
                HttpResponseMessage responseMessage = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/product/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
