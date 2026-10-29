using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LambdaJoining
{

    class LambdaJoins
    {
        internal class Buyer
        {
            public string Distict { get; set; }
            public string Name { get; set; }

            public int Age { get; set; }

        }

        internal class Supplier
        {
            public string Distict { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }


        }

        static void Main()
        {

            List<Buyer> buyer = new();
            List<Supplier> supplier = new();

            buyer.Add(new Buyer() { Distict = "Fantasy District", Name = "Johny" , Age = 30});
            buyer.Add(new Buyer() { Distict = "Fantasy District", Name = "Paul" , Age = 30});
            buyer.Add(new Buyer() { Distict = "Fantasy District", Name = "Pierce", Age = 20 });
            buyer.Add(new Buyer() { Distict = "Developers District", Name = "Sylvia", Age = 20 });
            buyer.Add(new Buyer() { Distict = "Developers District", Name = "Jaime", Age = 19 });
            buyer.Add(new Buyer() { Distict = "Scientist District", Name = "Peter", Age = 35 });
            buyer.Add(new Buyer() { Distict = "Scientist District", Name = "Maria", Age = 35 });
            buyer.Add(new Buyer() { Distict = "Scientist District", Name = "Johsue", Age = 40 });
            buyer.Add(new Buyer() { Distict = "Scientist District", Name = "Rebecca", Age = 40 });

            supplier.Add(new Supplier() { Distict = "Fantasy District", Name = "Harrison" , Age = 30});
            supplier.Add(new Supplier() { Distict = "Fantasy District", Name = "Harrison", Age = 20 });
            supplier.Add(new Supplier() { Distict = "Scientist District", Name = "Charles40", Age = 40 });

            supplier.Add(new Supplier() { Distict = "Scientist District", Name = "Charles", Age = 35});
            supplier.Add(new Supplier() { Distict = "Developers District", Name = "Hailee", Age = 20 });
            supplier.Add(new Supplier() { Distict = "Developers District", Name = "Hailee19", Age = 19 });



            var innerJoin = (supplier.Join(buyer, s => s.Distict, b => b.Distict,
                (s, b) => new
                {
                    SupplierName = s.Name,
                    BuyerName = b.Name,
                    District = s.Distict
                })).ToList();



            var innerJoinSelect = (from b in buyer
                                  orderby b.Distict
                                  join s in supplier on b.Distict equals s.Distict
                                  select new
                                  {
                                      Supplier = s.Name,
                                      Buyer = b.Name,
                                      District = s.Distict
                                  }).ToList();

            var innerJoinSelect2 = (from b in buyer
                                   orderby b.Distict
                                   join s in supplier on new { b.Distict, b.Age } equals new { s.Distict, s.Age }
                                   select new
                                   {
                                       Supplier = s.Name,
                                       Buyer = b.Name,
                                       District = s.Distict,
                                       Age = s.Age
                                   }).ToList();

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"District: {item.District}, Supplier Name: {item.SupplierName}, Buyer Name: {item.BuyerName}");
            }

            var compositJoin = supplier.Join(buyer,
                s => new { s.Distict, s.Age},
                b => new { b.Distict, b.Age },
                (s, b) => new
                {
                    SupplierName = s.Name,
                    BuyerName = b.Name,
                    District = s.Distict,
                    s.Age
                }
                );

            foreach (var item in compositJoin)
            {
                Console.WriteLine($"Age: {item.Age}, District: {item.District}, Supplier Name: {item.SupplierName}, Buyer Name: {item.BuyerName}");
            }

            var joinedvalue = (from s in supplier
                              join b in buyer on s.Distict equals b.Distict
                              select new
                              {
                                  District = s.Distict,
                                  BuyerName = b.Name,
                                  SupplierName = s.Name,
                                  s.Age
                              }).ToList();


            //foreach (var item in joinedvalue)
            //{
            //    Console.WriteLine($"Age: {item.Age}, District: {item.District}, Supplier Name: {item.SupplierName}, Buyer Name: {item.BuyerName}");
            //}

            foreach (var item in joinedvalue)
            {
                Console.WriteLine(item);
            }

            var singSelectJoin = (from b in buyer
                                 join s in supplier on b.Distict equals s.Distict
                                 select b.Name).ToList();

            singSelectJoin.ForEach(value => Console.WriteLine($"Name -- {value}"));
        }






    }








}
