using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using BID_DLC.Models;
using System.Web.Http.Cors;

namespace BID_Service.Controllers{
    
    public class EmployeeController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GetEmployees()
        {

            HttpResponseMessage oResponse;

            Employee oEmployee = new Employee();
            oResponse = Request.CreateResponse(HttpStatusCode.OK, oEmployee.GetEmployees());
            return oResponse;

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GetEmployees(int id)
        {

            HttpResponseMessage oResponse;

            Employee oEmployee = new Employee();
            oResponse = Request.CreateResponse(HttpStatusCode.OK, oEmployee.GetEmployees(id));
            return oResponse;


        }

    }
}
