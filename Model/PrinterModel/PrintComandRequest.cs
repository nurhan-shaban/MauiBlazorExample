namespace MauiBlazorExample.Model.PrinterModel
{
    public class PrintComandRequest<T>
    {
        public int Id { get; set; } = 1;
        public string Jsonrpc { get; set; } = "2.0";
        public string Method { get; set; } = string.Empty;
        public T Params { get; set; } = default;
    }
}
