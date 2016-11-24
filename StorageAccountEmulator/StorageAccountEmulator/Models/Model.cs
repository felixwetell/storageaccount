using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
using System.ComponentModel.DataAnnotations;

namespace StorageAccountEmulator.Models
{
    public class Model : TableEntity
    {

        public Model(){}

        public Model(string partiotionKey, string rowKey) : base(partiotionKey, rowKey)
        {
            this.PartitionKey = partiotionKey;
            this.RowKey = rowKey;
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a message:")]
        public string Message { get; set; }
    }
}