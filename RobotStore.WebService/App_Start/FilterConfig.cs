﻿using System.Web;
using System.Web.Mvc;

namespace RobotStore.WebService
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters != null)
            {
                filters.Add(new HandleErrorAttribute());
            }            
        }
    }
}