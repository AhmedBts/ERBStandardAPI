using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sales
{
    public class TrxD
    {
        public int BranchCode { get; set; }
        public int Type { get; set; }
        public int Year { get; set; }
        public int Serial { get; set; }
        public int LineNum1 { get; set; }
        public int LineNum2 { get; set; }
        //
        public string? Location { get; set; }
        public string? ToLocation { get; set; }
        public string? ItemCode { get; set; }
        public int? UOMCode { get; set; }
        public double? UOMConvFactor { get; set; }
        public double? DisplayQty { get; set; }
        public double? Qty { get; set; }
        public double? Qty2 { get; set; }
        public int? SalesRepCode { get; set; }
        public double? DisplayPrice { get; set; }
        public double? EqPrice { get; set; }
        public double? Price { get; set; }
        public double? DiscPercent { get; set; }
        public double? DiscAmount { get; set; }
        public double? EqDiscAmount { get; set; }
        public double? SalesTaxPercent { get; set; }
        public double? SalesTaxAmount { get; set; }
        public double? EqSalesTaxAmount { get; set; }
        public DateTime? ExpireDate { get; set; }
        public decimal? LotNo { get; set; }
        public double? CostAverage { get; set; }
        public double? CostFIFO { get; set; }
        public bool? WithLot { get; set; }
        public string? SerialNo { get; set; }
        public bool? TemprorySerialYN { get; set; }
        public string? SerialNoMemo { get; set; }
        public string? ItemDescription { get; set; }
        public int? YearsWarantyCertificate { get; set; }
        public int? AssetCode { get; set; }
        public int? AssetTrxSerial { get; set; }
        public int? CostCenterCode { get; set; }
        public string? AnotherUOMCode { get; set; }
        public double? DiscPercent1 { get; set; }
        public double? DiscAmount1 { get; set; }
        public double? EqDiscAmount1 { get; set; }
        public double? DiscPercent2 { get; set; }
        public double? DiscAmount2 { get; set; }
        public double? EqDiscAmount2 { get; set; }
        public double? StandardCost { get; set; }
        public int? PackageYear { get; set; }
        public int? PackageSerial { get; set; }
        public string? PackageSource { get; set; }
        public string? BarCode { get; set; }
        public double? VATPercent { get; set; }
        public double? VATAmount { get; set; }
        public double? EqVATAmount { get; set; }
        public TrxH trxh { get; set; }
    }
}
