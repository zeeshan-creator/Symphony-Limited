﻿using System.Web;
using System.Web.Mvc;

namespace Symphony_Limited
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
