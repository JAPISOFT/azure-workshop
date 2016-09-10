using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AzureWorkshop.Logging;
using AzureWorkshop.Services.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureWorkshop.Services
{
    public class CnbStorageService : CnbService, IExchangeService
    {
        private const string ExchangesUrl = "http://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_devizoveho_trhu/denni_kurz.txt?date={0}.{1}.{2}";

        protected override async Task<string> DownloadTextAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return await Task.FromResult(default(string));
            }

            // try search in azure storage
            string data;
            if (TryGetFromStorage(url, out data))
            {
                return await Task.FromResult(data);
            }

            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                data = await webClient.DownloadStringTaskAsync(new Uri(url));

                await SaveToStorage(url, data);

                return data;
            }
        }

        private bool TryGetFromStorage(string url, out string result)
        {
            result = null;

            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                CloudBlobContainer blobContainer = blobClient.GetContainerReference("demo-exchanges");
                if (blobContainer.CreateIfNotExists())
                {
                    Log.Event("Created new blob storage container demo-exchanges");
                }

                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(url);
                if (blob.Exists())
                {
                    result = blob.DownloadText();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return false;
        }

        private async Task SaveToStorage(string url, string data)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                CloudBlobContainer blobContainer = blobClient.GetContainerReference("demo-exchanges");
                if (await blobContainer.CreateIfNotExistsAsync())
                {
                    Log.Event("Created new blob storage container demo-exchanges");
                    Hub.Notify("ab");
                }

                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(url);
                try
                {
                    await blob.UploadTextAsync(data);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}