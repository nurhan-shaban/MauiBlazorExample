using MauiBlazorExample.Model.WebModel;

namespace MauiBlazorExample.Service
{
    internal interface IReceiptService
    {
        Task<GlobalResponse<bool>> LoginRequestAsync(string pass, string userName);
        Task<GlobalResponse<IEnumerable<StoreResponse>>> GetStoreAsync();
        Task<GlobalResponse<IEnumerable<TerminalResponse>>> GetTerminalAsync();
        Task<GlobalResponse<IEnumerable<PaymentsResponse>>> GetPaymentsAsync();
        Task<string> ReceiptsPostAsync(ReceiptsRequest receiptsRequest);
        Task<GlobalResponse<IEnumerable<DownloadItemResponse>>> DownloadItemsAsyc();
        Task<GlobalResponse<IEnumerable<VatResponse>>> VatsAsync();
    }
}
