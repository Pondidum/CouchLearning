using System;
using Dashboard.Features.Home;
using FubuMVC.Core;

namespace Dashboard
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // As is, this will be using all the default conventions and policies
            Actions.FindBy(x =>
            {
                x.Applies.ToThisAssembly();
                x.IncludeClassesSuffixedWithController();
            });

            Routes.HomeIs<HomeInputModel>()
                .ConstrainToHttpMethod(x => x.Method.Name.Equals("Get", StringComparison.OrdinalIgnoreCase), "GET")
                .IgnoreControllerNamesEntirely();
        }
    }
}
