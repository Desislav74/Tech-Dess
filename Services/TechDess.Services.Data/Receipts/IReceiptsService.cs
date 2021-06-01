namespace TechDess.Services.Data.Receipts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReceiptsService
    {
        Task<int> CreateReceipt(string recipientId);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllByRecipientId<T>(string receiptId);
    }
}
