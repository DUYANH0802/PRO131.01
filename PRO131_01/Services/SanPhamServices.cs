using PRO131_01.Models;
using PRO131_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO131_01.Services
{
    public class SanPhamServices
    {
        GenericRepository<SanPham> _repository;

        public SanPhamServices() 
        {
            _repository = new GenericRepository<SanPham>();
        }
        public List<SanPham> GetProducts() 
        {
            return _repository.GetAll();
        }
        public List<SanPham> GetProductsWithInclude(params string[] includes) 
        {
            return _repository.GetAllWithInclude(includes);
        }
        public void Them(SanPham sp) 
        {
            _repository.Add(sp);    
        }

        public void Sua(SanPham sp) 
        {
            _repository.Update(sp);
        }
        public void Xoa(SanPham sp)
        {
            _repository.Remove(sp);
        }
    }
}
