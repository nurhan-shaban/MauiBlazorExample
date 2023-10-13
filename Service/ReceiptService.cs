using MauiBlazorExample.Model;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.SessionStorage;
using System.Net;

namespace MauiBlazorExample.Service
{
    internal class ReceiptService : IReceiptService
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorageService;
        public ReceiptService(HttpClient httpClient, ISessionStorageService sessionStorageService)
        {
            _httpClient = httpClient;
            _sessionStorageService = sessionStorageService;
        }

        public async Task<GlobalResponse<IEnumerable<DownloadItemResponse>>> DownloadItemsAsyc()
        {
            try
            {
                string token = await _sessionStorageService.GetItemAsync<string>("token");
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var http = await _httpClient.GetAsync("Download/Items");
                http.EnsureSuccessStatusCode();

                var res = new GlobalResponse<IEnumerable<DownloadItemResponse>>();
                res.response = await http.Content.ReadFromJsonAsync<IEnumerable<DownloadItemResponse>>();
                res.message = "Ok";
                return res;
            }
            catch (Exception ex)
            {
                var error = new GlobalResponse<IEnumerable<DownloadItemResponse>>();
                error.message = ex.Message;
                return error;
            }
        }
        public async Task<GlobalResponse<IEnumerable<PaymentsResponse>>> GetPaymentsAsync()
        {
            try
            {
                string token = await _sessionStorageService.GetItemAsync<string>("token");
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var result = new GlobalResponse<IEnumerable<PaymentsResponse>>();

                var http = await _httpClient.GetAsync("/Payments");
                if(http.StatusCode == HttpStatusCode.OK)
                {
                    var res = await http.Content.ReadFromJsonAsync<IEnumerable<PaymentsResponse>>();

                    result.response = res;
                    result.message = "OK";
                    return result;
                }
                else
                {
                    result.response = default(IEnumerable<PaymentsResponse>);
                    result.message = await http.Content.ReadAsStringAsync();
                    return result;
                }

            }
            catch (Exception e)
            {
                var res = new GlobalResponse<IEnumerable<PaymentsResponse>>();
                res.message = e.Message;
                return res;
            }
        }
        public async Task<GlobalResponse<IEnumerable<StoreResponse>>> GetStoreAsync()
        {
            try
            {
                string token = await _sessionStorageService.GetItemAsync<string>("token");
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var http = await _httpClient.GetAsync("/Stores");
                http.EnsureSuccessStatusCode();

                var res = new GlobalResponse<IEnumerable<StoreResponse>>();
                res.response = await http.Content.ReadFromJsonAsync<IEnumerable<StoreResponse>>();
                res.message = "Ok";
                return res;
            }
            catch(Exception e)
            {
                var res = new GlobalResponse<IEnumerable<StoreResponse>>();
                res.message = e.Message;
                return res;
            }
        }
        public async Task<GlobalResponse<IEnumerable<TerminalResponse>>> GetTerminalAsync()
        {
            try
            {
                string token = await _sessionStorageService.GetItemAsync<string>("token");
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var http = await _httpClient.GetAsync("/Terminals/All");
                http.EnsureSuccessStatusCode();

                var res = new GlobalResponse<IEnumerable<TerminalResponse>>();
                res.response = await http.Content.ReadFromJsonAsync<IEnumerable<TerminalResponse>>();
                res.message = "Ok";
                return res;
            }
            catch(Exception e)
            {
                var res = new GlobalResponse<IEnumerable<TerminalResponse>>();
                res.message = e.Message;
                return res;
            }
        }
        public async Task<GlobalResponse<bool>> LoginRequestAsync(string pass, string userName)
        {
            try
            {
                var request = new LoginRequest { email=userName,password=pass };
                var http = await _httpClient.PostAsJsonAsync<LoginRequest>("/Identity/Login", request);
                http.EnsureSuccessStatusCode();

                var res = await http.Content.ReadFromJsonAsync<LoginResponse>();
                string token = res.token.Replace("\"", "");
                await _sessionStorageService.SetItemAsync("token", token);

                var result = new GlobalResponse<bool>();
                result.message = "OK";
                result.response = true;

                return result;
            }
            catch(Exception e)
            {
                var result = new GlobalResponse<bool>();
                result.message = e.Message;
                result.response = false;
                return result;
            }
        }
        public async Task<string> ReceiptsPostAsync(ReceiptsRequest receiptsRequest)
        {
            try
            {
                string token = await _sessionStorageService.GetItemAsync<string>("token");
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var http = await _httpClient.PostAsJsonAsync<ReceiptsRequest>("/Receipts", receiptsRequest);

                if(http.IsSuccessStatusCode)
                {
                    return "OK";
                }
                else
                {
                    return await http.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<GlobalResponse<IEnumerable<VatResponse>>> VatsAsync()
        {
            try
            {
                string token = await _sessionStorageService.GetItemAsync<string>("token");
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var res = new GlobalResponse<IEnumerable<VatResponse>>();

                var http = await _httpClient.GetAsync("Vats/MinimalAll");
                http.EnsureSuccessStatusCode();
                res.message = "Ok";
                res.response = await http.Content.ReadFromJsonAsync<IEnumerable<VatResponse>>();
                return res;
            }
            catch( Exception e )
            {
                var error = new GlobalResponse<IEnumerable<VatResponse>>();
                error.message = e.Message;
                return error;
            }
        }
    }
}
