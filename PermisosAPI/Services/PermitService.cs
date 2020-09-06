using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PermisosAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;

namespace PermisosAPI.Services
{
    public class PermitService
    {
        private readonly PermitsDbContext _db;

        public int registers;
        public PermitService(PermitsDbContext db)
        {
            _db = db;
        }

        public List<Permit> GetAll()
        {
            return _db.Permit.Include( x => x.PermitType).ToList();
        }

        public Boolean CreatePermit(Permit newPermit)
        {
            try
            {
                _db.Permit.Add(newPermit);
                _db.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
            return false;
            } 
            
        }

        public Boolean UpdatePermit(Permit newPermit)
        {
            try
            {
                var permitFromDb = _db.Permit.Where(serch => serch.Id == newPermit.Id).FirstOrDefault();
                permitFromDb.EmployeeName = newPermit.EmployeeName;
                permitFromDb.EmployeeLastname = newPermit.EmployeeLastname;
                permitFromDb.PermitTypeId = newPermit.PermitTypeId;
                permitFromDb.FechaPermiso = newPermit.FechaPermiso;

                _db.SaveChanges();

                return true;
            }
            catch (Exception error)
            {
                return false;
            }


        }

        public Boolean Delete(int permitId)
        {
            try
            {
                var permitFromDb = _db.Permit.Where(serch => serch.Id == permitId).FirstOrDefault();
                _db.Permit.Remove(permitFromDb);
                _db.SaveChanges();

                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public Permit GetPermit(int permitId)
        {
            return _db.Permit.Where(serch => serch.Id == permitId).FirstOrDefault();
        }

        public List<PermitType> GetPermitTypes()
        {
            return _db.PermitType.ToList();
        }
    }
}
