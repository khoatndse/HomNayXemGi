using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayXemGi.Models;

namespace HomNayXemGi.DAL
{
    public class TicketDAO :DAO<Models.Scheduler>
    {
        public List<RapChieu> GetAllRapChieu()
        {
            return GetAll().Select(sche => sche.RapChieu).Distinct().ToList();
        }

        public List<Scheduler> GetLichChieu(RapChieu Rap)
        {
            return GetAll().Where(sche => sche.RapChieu == Rap).ToList();
        }
    }
}