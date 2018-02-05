using DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.ViewModel;
using System.Diagnostics;

namespace DataAccessLayer.Implementation
{
    public class vPersonnalService : IvPersonnalService
    {
        public List<vPersonnalViewModel> viewPersonnalList()
        {
            //Mapping
            using (var entity = new HimalDbEntities())
            {
                var viewData = entity.vPersonnels;
                var ListModel = new List<vPersonnalViewModel>();
                foreach (var item in ListModel)
                {
                    var model = new vPersonnalViewModel();
                    model.ProfileID = item.ProfileID;
                    model.DOB = item.DOB;
                    model.DODID = item.DODID;
                    model.eligibility = item.eligibility;
                    model.EligibilityDate = item.EligibilityDate;
                    model.FirstName = item.FirstName;
                    model.InvestigationType = item.InvestigationType;
                    model.LastName = item.LastName;
                    model.NDA = item.NDA;
                    model.NonSCIAccesses = item.NonSCIAccesses;
                    model.PersonalCategory = item.PersonalCategory;
                    model.POB = item.POB;
                    model.PositionSensitivity = item.PositionSensitivity;
                    model.PrevInvestigationCloseDate = item.PrevInvestigationCloseDate;
                    model.SMORelationship = item.SMORelationship;
                    model.MiddleName = item.MiddleName;

                    ListModel.Add(model);
                }
                return ListModel;
              
            }
        }

       
    }
}
