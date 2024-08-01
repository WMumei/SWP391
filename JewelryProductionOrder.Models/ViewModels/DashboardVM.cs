using JewelryProductionOrder.Models;

public class DashboardVM
{
    public List<ProductionRequest> ProductionRequests { get; set; }
    public List<Delivery> Deliveries { get; set; }
    public List<QuotationRequest> QuotationRequests { get; set; }

}