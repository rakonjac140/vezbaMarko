using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RestoranBusiness
    {
        private readonly RestoranRepository restoranRepository;

        public List<Restoran> GetAllMenuItems()
        {
            return this.restoranRepository.GetAllMenuItems();
        }

        public bool InsertItem(Restoran r)
        {
            if (this.restoranRepository.InsertMenuItem(r) > 0)
                return true;
            return false;
        }

        public List<Restoran> GetStudentsBetween(double min, double max)
        {
            this.restoranRepository.GetAllMenuItems().Where( r => Convert.ToDouble(r.Price) > min && Convert.ToDouble(r.Price) < max).ToList();
        }


    }


}
