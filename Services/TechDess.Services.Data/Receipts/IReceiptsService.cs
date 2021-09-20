namespace TechDess.Services.Data.Receipts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TechDess.Data.Models;

    public interface IReceiptsService
    {
        Task<int> CreateReceipt(string recipientId);

        IEnumerable<T> GetAll<T>(int id);

        IEnumerable<T> GetAllByRecipientId<T>(string receiptId);
    }
}
