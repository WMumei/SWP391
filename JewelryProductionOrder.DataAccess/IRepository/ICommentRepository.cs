using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void Update(Comment obj);
        void Save();
    }
}
