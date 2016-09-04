using System;
using System.ComponentModel.DataAnnotations;

namespace AzureWorkshop.Models
{
    public class CnbExchange : Exchange
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}