using JewelryProductionOrder.Data;
using JewelryProductionOrder.Repositories.IRepository;
using JewelryProductionOrder.Models;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JewelryProductionOrder.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Comment comment)
        {
            _db.Comments.Update(comment);
        }
    }
}
