public class Program
{
    public struct ratings
    {
        double movie1;
        double movie2;
        double movie3;
        double movie4;
        double movie5;



        public ratings(double movie1,double movie2,double movie3,double movie4,double movie5)
        {
            this.movie1=movie1;
            this.movie2=movie2;
            this.movie3=movie3;
            this.movie4=movie4;
            this.movie5=movie5;
 

        }
        public void display()
        {
            Console.WriteLine($"1st movie:{movie1},2nd movie:{movie2},3rd movie:{movie3},4th movie:{movie4},5th movie:{movie5}");
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Rating for ist movie");
        double a=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Rating for 2nd movie");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Rating for 3rd movie");
        double c = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Rating for 4th movie");
        double d = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Rating for 5th movie");
        double e = Convert.ToDouble(Console.ReadLine());

        ratings movies = new ratings(a,b,c,d,e);
        movies.display();


        double [] movie = {a,b,c,d,e};

        
        double max = movie[0];
        double min = movie[0];

        foreach(double r in movie)
        {
            if(r > max)
            { max = r; }
            else if(r < min) { min = r; }

        }
        Console.WriteLine($"the average rating is:{(a + b + c + d + e) / (5)}");
        Console.WriteLine($"the highest rated movie is:{max}");
        Console.WriteLine($"the lowest rated movie is:{min}");


    }
}