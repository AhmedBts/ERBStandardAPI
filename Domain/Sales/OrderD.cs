using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sales
{
    public class OrderD
    {
        public int BranchCode { get; set; }
        public string ProcessType { get; set; }
        public int Type { get; set; }
        public int Year { get; set; }
        public int Serial { get; set; }
        public int LineNo { get; set; }
        public string? ItemCode { get; set; }
        public int? UOMCode { get; set; }
        public string? Location { get; set; }
        public string? ToLocation { get; set; }
        public double? UOMConvFactor { get; set; }
        public double? DisplayQty { get; set; }
        public double? Qty { get; set; }
        public double? OpenDisplayQty { get; set; }
        public double? OpenProdQty { get; set; }
        public double? DisplayPrice { get; set; }
        public double? Price { get; set; }
        public double? EqPrice { get; set; }
        public double? DiscAmount { get; set; }
        public double? DiscPercent { get; set; }
        public double? EqDiscAmount { get; set; }
        public double? SalesTaxAmount { get; set; }
        public int? SalesTaxPercent { get; set; }
        public double? EqSalesTaxAmount { get; set; }
        public string? Notes { get; set; }
        public string? Reference { get; set; }
        public string? ItemDescription { get; set; }
        public string? UserId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public DateTime? CreateDateAndTime { get; set; }
        public string? CreateUserid { get; set; }
        public int? IssueStoreCode { get; set; }
        public int? Branch { get; set; }
        public string? SerialNo { get; set; }
        public double? Qty2 { get; set; }
        public double? DiscAmount1 { get; set; }
        public double? DiscPercent1 { get; set; }
        public double? EqDiscAmount1 { get; set; }
        public string? BarCode { get; set; }
        public double? DiscAmount2 { get; set; }
        public double? DiscPercent2 { get; set; }
        public double? EqDiscAmount2 { get; set; }
        public OrderH? orderh { get; set; }

        public static explicit operator List<object>(OrderD v)
        {
            throw new NotImplementedException();
        }
    }
}
