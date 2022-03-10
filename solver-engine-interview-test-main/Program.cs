using System;

namespace solver_engine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solver engine");

            var request = new SolverReqest()
            {
                VehicleWithOrdersData = new VehicleWithOrders() //hardcoded here, but would normally be from user input above
                {
                    
                    Registration = "LS07OTC",                   
                    Capacity = 1000,
                    Orders = new System.Collections.Generic.List<Order>()
                    {
                        new Order() { Identifier ="Order 1", PickupLocation ="West Kensington", DeliveryLocation = "Uxbridge" },
                        new Order() { Identifier ="Order 2", PickupLocation ="West Kensington", DeliveryLocation = "Hounslow" },
                        new Order() { Identifier ="Order 1", PickupLocation ="West Kensington", DeliveryLocation = "Nottingham" }
                    }
                }
            };

            SearchResult result = new();

            var solverEngine = new SolverEngine();
            try
            {
                result = SolverEngine.GetCost(request);
                Console.WriteLine(String.Format("You cost is {0}, from engine: {1}", result.Cost, result.Name));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
