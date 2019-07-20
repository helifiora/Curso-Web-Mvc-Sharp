using System.Collections.Generic;

namespace WebAppSalesMVC.Models.ViewModels
{
    public class SellerModelViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}