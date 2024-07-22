namespace JewelryProductionOrder.Models.ViewModels
{
	public class CheckQuotationVM
	{
		public bool checkStatus { get; set; }
		public bool checkCancel { get; set; }
		public List<QuotationRequest> QuotationRequests { get; set; }
	}
}
