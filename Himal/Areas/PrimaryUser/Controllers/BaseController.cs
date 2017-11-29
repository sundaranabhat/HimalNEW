using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Himal.Areas.PrimaryUser.Controllers
{
    [Authorize(Roles ="PrimaryUsers")]
    public class BaseController : Controller
    {
        // GET: PrimaryUser/Base
       
    }
}