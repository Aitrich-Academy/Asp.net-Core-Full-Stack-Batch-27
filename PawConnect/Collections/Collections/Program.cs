using System.Collections;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList list = new ArrayList();

            //list.Add(1);
            //list.Add("RajishaRajisha");



            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}


            //int n = 10;
            //List<string> list = new List<string>();

            //list.Add("aiswarya");
            //list.Add("sanjay");
            //list.Add(Convert.ToString(1000));
            ////list.Add(n.ToString());


            //foreach (string item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //Hashtable list = new Hashtable();

            //list.Add("name:", "Karthik");
            //list.Add(1000 , 10000);
            //list.Add("salary:", 100);

            //foreach (DictionaryEntry item in list)
            //{
            //    Console.WriteLine(item.Key +""+ item.Value);
            //}

            Dictionary<int, string> stud = new Dictionary<int, string>();

            stud.Add(1, "karthik");
            stud.Add(2, "rajisha");
            stud.Add(3, "Sanjay");
            stud.Add(4, "resna");
            //stud.Add("ytdfyuh", 123);

            foreach (var item in stud)
            {
                Console.WriteLine(item.Key +":" +item.Value);
            }



        }
    }
}
