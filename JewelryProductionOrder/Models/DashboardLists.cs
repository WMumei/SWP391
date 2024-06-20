using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Models;

public class DashboardLists
{
    public List<ProductionRequest> ProductionRequests { get; set; }
    public List<Delivery> Deliveries { get; set; }
    public List<QuotationRequest> QuotationRequests { get; set; }
}