using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sales
{
    public class OrderH
    {
        public int BranchCode { get; set; }
        public string ProcessType { get; set; }
        public int Year { get; set; }
        public int Serial { get; set; }
        public int Type { get; set; }
        public DateTime?Date {get;set;}
    public int? TargetCode { get; set; }
    public int? TargetKey { get; set; }
    public int? PaymentTerm { get; set; }
    public int? RepCode { get; set; }
    public int? ShipTo { get; set; }
    public int? StoreCode { get; set; }
    public int? CurrencyCode { get; set; }
    public double? ExchangeRate { get; set; }
    public bool? Printed { get; set; }
    public int? PrintNo { get; set; }
    public bool? TransFlag { get; set; }
    public int? Approved { get; set; }
    public string? ReviewNotes { get; set; }
    public DateTime? ReviewDate { get; set; }
    public string? GeneralNotes { get; set; }
    public double? POStatus { get; set; }
    public string? FinancialNotes { get; set; }
    public bool? ChkClose { get; set; }
    public double? OtherDisc { get; set; }
    public double? VATTax { get; set; }
    public double? EqVATTax { get; set; }
    public double? OpenOtherDisc { get; set; }
    public string? TenDProcessType { get; set; }
    public int? TenderYear { get; set; }
    public int? TenderSerial { get; set; }
    public int? QuotationType { get; set; }
    public int? QuotationYear { get; set; }
    public int? QuotationSerial { get; set; }
    public string? ReqProcessType { get; set; }
    public int? ReqYear { get; set; }
    public int? ReqSerial { get; set; }
    public int? M500_ContractTBranchCode { get; set; }
    public int? M500_ContractType { get; set; }
    public int? M500_ContractYear { get; set; }
    public int? M500_ContractCode { get; set; }
    public string? UserId { get; set; }
    public DateTime? DateAndTime { get; set; }
    public DateTime? CreateDateAndTime { get; set; }
    public string? CreateUserid { get; set; }
    public int? StoreBranch { get; set; }
    public int? ContractCode { get; set; }
    public int? ContractType { get; set; }
    public int? ContractYear { get; set; }
    public int? M180_RequestHYear { get; set; }
    public int? M180_RequestHSerial { get; set; }
    public string? TransferReqProcessType { get; set; }
    public int? TransferReqYear { get; set; }
    public int? TransferReqSerial { get; set; }
      public ICollection<OrderD> orderd { get; set; }
    }
}
