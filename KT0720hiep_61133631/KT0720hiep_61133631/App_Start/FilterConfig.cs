﻿using System.Web;
using System.Web.Mvc;

namespace KT0720hiep_61133631
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
