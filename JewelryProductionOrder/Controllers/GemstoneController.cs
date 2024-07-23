using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

namespace JewelryProductionOrder.Areas.Staff.Controllers
{
    public class GemstoneController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
    }
}
