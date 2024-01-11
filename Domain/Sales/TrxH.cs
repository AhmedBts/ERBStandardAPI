using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sales
{
    public class TrxH
    {
        public int BranchCode { get; set; }
        public int Type { get; set; }
        public int Year { get; set; }
        public int Serial { get; set; }
        ///
        public string? ProcessType { get; set; }
        public byte? Shift { get; set; }
        public DateTime? Date { get;set;}
    public DateTime? ShiftDate { get; set; }
    public string? DeliverTime { get; set; }
    public int? TargetCode { get; set; }
    public int? TargetKey { get; set; }
    public int? ToBranch { get; set; }
    public int? ShipTo { get; set; }
    public int? StoreCode { get; set; }
    public int? CurrencyCode { get; set; }
    public double? ExchangeRate { get; set; }
    public int? SafeCode { get; set; }
    public int? PayType { get; set; }
    public int? BankCode { get; set; }
    public int? CostCenterDefualt { get; set; }
    public int? SalesRepCode { get; set; }
    public string? RefNo { get; set; }
    public string? CarNo { get; set; }
    public int? FarmCode { get; set; }
    public string? Notes { get; set; }
    public string? FinancialNotes { get; set; }
    public bool? Posted { get; set; }
    public bool? AutoGeneration { get; set; }
    public int? Approved { get; set; }
    public string? ReviewNotes { get; set; }
    public DateTime? ReviewDate { get; set; }
    public bool? Confirmed { get; set; }
    public bool? QualityYN { get; set; }
    public int? PrintNo { get; set; }
    public int? TransType { get; set; }
    public int? TransYear { get; set; }
    public int? TransSerial { get; set; }
    public int? QuotationType { get; set; }
    public int? QuotationYear { get; set; }
    public int? QuotationSerial { get; set; }
    public string? OrderProcessType { get; set; }
    public int? OrderType { get; set; }
    public int? OrderYear { get; set; }
    public int? OrderSerial { get; set; }
    public string? ReceiptProcessType { get; set; }
    public int? ReceiptType { get; set; }
    public int? ReceiptYear { get; set; }
    public int? ReceiptSerial { get; set; }
    public int? InvType { get; set; }
    public int? InvYear { get; set; }
    public int? InvSerial { get; set; }
    public int? RevInvType { get; set; }
    public int? RevInvYear { get; set; }
    public int? RevInvSerial { get; set; }
    public int? TypeProd { get; set; }
    public int? YearProd { get; set; }
    public int? SerialProd { get; set; }
    public int? ProductionOrderYear { get; set; }
    public int? ProductionOrderSerial { get; set; }
    public int? ProductionOrderNazlSerial { get; set; }
    public double? TotalPrice { get; set; }
    public double? EqTotalPrice { get; set; }
    public double? NetPrice { get; set; }
    public double? EqNetPrice { get; set; }
    public double? DiscPercent { get; set; }
    public double? DiscAmount { get; set; }
    public double? EqDiscAmount { get; set; }
    public double? OtherDisc { get; set; }
    public double? EqOtherDisc { get; set; }
    public double? TotalSalesTax { get; set; }
    public double? EqTotalSalesTax { get; set; }
    public double? VATTax { get; set; }
    public double? EqVATTax { get; set; }
    public decimal? WithHoldingTax { get; set; }
    public decimal? EqWithHoldingTax { get; set; }
    public int? BranchDocSerialCost { get; set; }
    public int? TrxYearCost { get; set; }
    public int? JournalCodeCost { get; set; }
    public int? TrxPeriodCost { get; set; }
    public int? TrxSerialCost { get; set; }
    public int? GL_SetupCodeCost { get; set; }
    public int? ProdOrderYear { get; set; }
    public int? ProdOrderSerial { get; set; }
    public bool? Loaded { get; set; }
    public bool? Delivered { get; set; }
    public int? GABranchDocSerial { get; set; }
    public int? GATrxYear { get; set; }
    public int? GAJournalCode { get; set; }
    public int? GATrxPeriod { get; set; }
    public int? GATrxSerial { get; set; }
    public int? GAGL_SetupCode { get; set; }
    public bool? GAPosted { get; set; }
    public int? TrxModule { get; set; }
    public string? TrxSource { get; set; }
    public int? TrxType { get; set; }
    public int? TrxYear { get; set; }
    public int? TrxSerial { get; set; }
    public int? DeliveryCode { get; set; }
    public int? DeliveryYear { get; set; }
    public int? DeliverySerial { get; set; }
    public int? M515_MonthNo { get; set; }
    public int? M515_CountDayNo { get; set; }
    public int? LocationContracCode { get; set; }
    public int? LocationContracSerial { get; set; }
    public DateTime? QualityAssuranceInspectionDate { get; set; }
    public int? QualityAssuranceType { get; set; }
    public int? QualityAssuranceYear { get; set; }
    public int? QualityAssuranceSerial { get; set; }
    public bool? TransferOrderStatus2 { get; set; }
    public bool? TransferOrderStatus3 { get; set; }
    public bool? TransferOrderStatus4 { get; set; }
    public double? StampOrdinary { get; set; }
    public double? StampRelative { get; set; }
    public double? StampSignature { get; set; }
    public int? MessengerCode { get; set; }
    public int? CardTypeCode { get; set; }
    public string? CardNumber { get; set; }
    public int? CardPOSCode { get; set; }
    public double? CardAdditionalFee { get; set; }
    public double? PartiallyPaidCash { get; set; }
    public int? ReturnOriginalVoucherType { get; set; }
    public int? ReturnOriginalVoucherYear { get; set; }
    public int? ReturnOriginalVoucherSerial { get; set; }
    public int? ReturnOriginalVoucherBranchCode { get; set; }
    public int? PackageYear { get; set; }
    public int? PackageSerial { get; set; }
    public string? UserId { get; set; }
    public DateTime? DateAndTime { get; set; }
    public string? CreateUserid { get; set; }
    public DateTime? CreateDateAndTime { get; set; }
    public int? POSDeliveryOrderStatus { get; set; }
    public decimal? DeliveryServiceValue { get; set; }
    public double? WithHoldingTaxAmount { get; set; }
        public ICollection<TrxD> trxds { get; set; }
    }
}
