using DataAccessLayer.Implementation;
using DataAccessLayer.Service;
using DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Controller
{
   public  class vPersonnalCtrl
    {

        private IvPersonnalService personnalService;

        //constructor
        public vPersonnalCtrl()
        {
            personnalService = new vPersonnalService();
        }
        public List<vPersonnalViewModel> GetList()
        {
            var model = new PersonnalListModel();
            model.vPersonnalList = personnalService.viewPersonnalList();
            return model.vPersonnalList;
        }

    }
}
