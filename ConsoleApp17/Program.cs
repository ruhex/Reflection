using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            

            Barsik barsik = new Barsik();
            barsik.test_1 = "barsik test 1";
            barsik.barsik_test_2 = "barsik test 2";

            Myrzik myrzik = new Myrzik();
            myrzik.test_1 = "myrzik test 1";

            GetProp<Barsik>(barsik);
            GetProp<Myrzik>(myrzik);

            myrzik = (Myrzik)Map<Myrzik, Barsik>(myrzik, barsik);
            Console.WriteLine(myrzik.test_1);

        }

        static object Map<T, J>(T obj1, J obj2)
        {
            PropertyInfo[] propertyInfos1 = typeof(T).GetProperties();
            PropertyInfo[] propertyInfos2= typeof(J).GetProperties();


            foreach (PropertyInfo pro1 in propertyInfos1)
                foreach (PropertyInfo pro2 in propertyInfos2)
                    if (pro1.Name == pro2.Name)
                        pro1.SetValue(obj1, pro2.GetValue(obj2));
            return obj1;
        }
        
        static void GetProp<T>(T obj)
        {
            Console.WriteLine("--------------------------------------------");
            foreach (PropertyInfo field in typeof(T).GetProperties())
                Console.WriteLine(field.Name + " : " + field.GetValue(obj));
            Console.WriteLine("--------------------------------------------");
        }
    }

    class Barsik
    {
        public string test_1 { get; set; }
        public string barsik_test_2 { get; set; }
    }

    class Myrzik
    {
        public string test_1 { get; set; }
        public string myrzik_test_2 { get; set; }
    }
}
