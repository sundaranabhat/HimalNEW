using DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
   public interface IvPersonnalService
    {
        List<vPersonnalViewModel> viewPersonnalList();
    }
}
