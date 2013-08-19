using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Features.Home
{
    public class HomeController
    {
        public HomeViewModel Get(HomeInputModel input)
        {
            return new HomeViewModel { Message = "Dave" };
        }
    }
}
