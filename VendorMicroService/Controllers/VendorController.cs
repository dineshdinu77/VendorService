﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorMicroService.Provider;
using VendorMicroService.Repository;

namespace VendorMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {

        private readonly IVendorProvider venprovider;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(VendorController));
        public VendorController(IVendorProvider _venderProvider)
        {

            venprovider = _venderProvider;
        }

        [HttpGet]
        [Route("GetVendorDetails/{ProductId}")]
        public IActionResult GetVendorDetails(int ProductId)
        {


            _log4net.Info(" Http GET in controller is accesed");

            var result = venprovider.GetDetailsOfVendor(ProductId);
             _log4net.Info("method execution in controller completed");

             if (result == null)
                {
                  _log4net.Info("method returns a null value");
                    return null;
                }
              _log4net.Info("available vendors for product with id "+ProductId+" is "+result );
                return Ok(result);
            
           
        }

    
    }
}
