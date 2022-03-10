using System;
using System.Collections.Generic;
using System.Dynamic;

namespace solver_engine
{
    public class SolverReqest
    {
        public VehicleWithOrders VehicleWithOrdersData { get; set; }
    }

    public class VehicleWithOrders
    {
        public string Registration { get; set; }
        public decimal Capacity { get; set; }
        public string Make { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public string Identifier { get; set; }
        public string PickupLocation { get; set; }
        public string DeliveryLocation { get; set; }
    }
    public class SolverEngine1
    {
        public SolverEngine1(string url, string port)
        {

        }

        public dynamic GetCost(dynamic request)
        {
            //makes a call to an engine service1            

            dynamic response = new ExpandoObject();
            response.Cost = 120;
            response.IsSuccess = true;

            return response;
        }
    }

    public class SolverEngine2
    {
        public SolverEngine2(string url, string port, dynamic request)
        {

        }

        public dynamic GetCost()
        {
            //makes a call to solver engine  service1
         
            dynamic response = new ExpandoObject();
            response.Cost = 234.56;            
            response.Name = "engine2";
            response.IsSuccess = true;


            return response;
        }
    }    

    public class SolverEngine
    {
        //pass request with vehiclewithorders return the best cost retrieved from 2 different types of  engines
        public static SearchResult GetCost(SolverReqest request)
        {
            //initialise return variables
            SearchResult eng1result = new SearchResult();
            SearchResult eng2result = new SearchResult();
            bool isEng1CallValid = false;

            //validation
            if (request.VehicleWithOrdersData == null)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(request.VehicleWithOrdersData));
            }
            else if (String.IsNullOrEmpty(request.VehicleWithOrdersData.Registration))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(request.VehicleWithOrdersData.Registration));
            }
            else if (request.VehicleWithOrdersData.Orders == null || request.VehicleWithOrdersData.Orders.Count < 1)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(request.VehicleWithOrdersData.Orders));
            }

            //solver engine 1 requires Make to be specified
            if (request.VehicleWithOrdersData.Make != null)
            {
                SolverEngine1 system1 = new SolverEngine1("http://solver-system-1.com", "1234");

                VehicleWithOrders request1 = new VehicleWithOrders()
                {
                    Registration = request.VehicleWithOrdersData.Registration,
                    Capacity = request.VehicleWithOrdersData.Capacity,
                    Make = request.VehicleWithOrdersData.Make,
                    Orders = request.VehicleWithOrdersData.Orders
                };

                dynamic system1Response = system1.GetCost(request1);
                if (system1Response.IsSuccess)
                {
                    eng1result = new SearchResult()
                    {
                        Cost = system1Response.Cost,
                        Name = system1Response.Name
                    };
                }
                isEng1CallValid = true;
            }

            //engine 2 is always called

            dynamic request2 = new VehicleWithOrders()
            {
                Registration = request.VehicleWithOrdersData.Registration,
                Capacity = request.VehicleWithOrdersData.Capacity,
                Make = request.VehicleWithOrdersData.Make,
                Orders = request.VehicleWithOrdersData.Orders
            };
            SolverEngine2 system2 = new SolverEngine2("http://solver-system-2.com", "1234", request2 );

               

            dynamic system2Response = system2.GetCost();
            if (system2Response.IsSuccess)
            {
                eng2result = new SearchResult()
                {
                    Cost = system2Response.Cost,
                    Name = system2Response.Name,
                };
            }

            return isEng1CallValid ? (eng2result.Cost < eng1result.Cost ? eng2result : eng1result) : eng2result;
        }
    }
}
