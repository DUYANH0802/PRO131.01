using PRO131_01.Models;
using PRO131_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRO131_01.Services
{
    public class NhanVienServices
    {
        private readonly GenericRepository<NhanVien> _repository;

        public NhanVienServices()
        {
            _repository = new GenericRepository<NhanVien>();
        }

        public List<NhanVien> GetNhanViens()
        {
            return _repository.GetAll().ToList();
        }

        public List<NhanVien> GetNhanViensWithInclude(params string[] includes)
        {
            return _repository.GetAllWithInclude(includes).ToList();
        }

        public void Them(NhanVien nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv));

            _repository.Add(nv);            
        }

        public void Sua(NhanVien nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv));

            _repository.Update(nv);            
        }

        public void Xoa(NhanVien nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv));

            _repository.Remove(nv);            
        }
      
        public NhanVien GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}