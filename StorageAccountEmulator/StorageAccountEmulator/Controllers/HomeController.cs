using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StorageAccountEmulator.Models;

namespace StorageAccountEmulator.Controllers
{
    public class HomeController : Controller
    {
        private CloudStorageAccount storageAccount;
        private CloudTableClient tableClient;
        private CloudTable table;

        public HomeController()
        {
            storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");
            tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference("people");
            table.CreateIfNotExists();

            Model entity = new Model();
        }

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Model info)
        {
            Model entity = new Model("abc", Guid.NewGuid().ToString()) { FirstName = info.FirstName, LastName = info.LastName, Message = info.Message };

            TableOperation insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);

            return View("Thanks");
        }
        public ActionResult Thanks()
        {
            return View();
        }
    }
}