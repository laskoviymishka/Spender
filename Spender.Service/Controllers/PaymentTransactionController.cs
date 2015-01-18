using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Spender.Service.DataObjects;
using Spender.Service.Models;

namespace Spender.Service.Controllers
{
	public class PaymentTransactionController : TableController<PaymentTransaction>
	{
		protected override void Initialize(HttpControllerContext controllerContext)
		{
			base.Initialize(controllerContext);
			var context = new MobileServiceContext();
			DomainManager = new EntityDomainManager<PaymentTransaction>(context, Request, Services);
		}

		// GET tables/PaymentTransaction
		public IQueryable<PaymentTransaction> GetAllPaymentTransaction()
		{
			return Query();
		}

		// GET tables/PaymentTransaction/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public SingleResult<PaymentTransaction> GetPaymentTransaction(string id)
		{
			return Lookup(id);
		}

		// PATCH tables/PaymentTransaction/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task<PaymentTransaction> PatchPaymentTransaction(string id, Delta<PaymentTransaction> patch)
		{
			return UpdateAsync(id, patch);
		}

		// POST tables/PaymentTransaction
		public async Task<IHttpActionResult> PostPaymentTransaction(PaymentTransaction item)
		{
			string storageAccountName;
			string storageAccountKey;

			// Try to get the Azure storage account token from app settings.  
			if (!(Services.Settings.TryGetValue("STORAGE_ACCOUNT_NAME", out storageAccountName) |
			      Services.Settings.TryGetValue("STORAGE_ACCOUNT_ACCESS_KEY", out storageAccountKey)))
			{
				Services.Log.Error("Could not retrieve storage account settings.");
			}

			// Set the URI for the Blob Storage service.
			var blobEndpoint = new Uri(string.Format("https://{0}.blob.core.windows.net", storageAccountName));

			// Create the BLOB service client.
			var blobClient = new CloudBlobClient(blobEndpoint,
				new StorageCredentials(storageAccountName, storageAccountKey));

			if (item.ContainerName != null)
			{
				// Set the BLOB store container name on the item, which must be lowercase.
				item.ContainerName = item.ContainerName.ToLower();

				// Create a container, if it doesn't already exist.
				var container = blobClient.GetContainerReference(item.ContainerName);
				await container.CreateIfNotExistsAsync();

				// Create a shared access permission policy. 
				var containerPermissions = new BlobContainerPermissions();

				// Enable anonymous read access to BLOBs.
				containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;
				container.SetPermissions(containerPermissions);

				// Define a policy that gives write access to the container for 5 minutes.                                   
				var sasPolicy = new SharedAccessBlobPolicy
				{
					SharedAccessStartTime = DateTime.UtcNow,
					SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
					Permissions = SharedAccessBlobPermissions.Write
				};

				// Get the SAS as a string.
				item.SasQueryString = container.GetSharedAccessSignature(sasPolicy);

				// Set the URL used to store the image.
				item.ImageUri = string.Format("{0}{1}/{2}", blobEndpoint,
					item.ContainerName, item.ResourceName);
			}

			var current = await InsertAsync(item);
			return CreatedAtRoute("Tables", new {id = current.Id}, current);
		}

		// DELETE tables/PaymentTransaction/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task DeletePaymentTransaction(string id)
		{
			return DeleteAsync(id);
		}
	}
}