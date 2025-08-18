using System.Threading.Tasks.Sources;

internal class Program
{
    static int[] score = new int [6];
    

    private static void Main(string[] args)
    {


        Console.WriteLine("Sports Score");
        while (true)
        {
            Console.WriteLine("\n1.Enter the scores\n2.View Scores\n3.Total Score & Average\n4.Highest Score\n5.Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    enterNumber();
                    break;
                case "2":
                    showNumbers();
                    break;
                case "3":
                    avgNum();
                    break;
                case "4":
                    highestScore();
                    break;
                case "5":
                    Console.WriteLine("\nThank You!!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
        static void enterNumber()
        {
            Console.WriteLine("Enter the scores: ");
            for (int i = 0; i < score.Length; i++)
            {
                score[i] = Convert.ToInt32 (Console.ReadLine());
            }
        }

    static int a=0;
        static void showNumbers()
        {
        
        int count = 1;
        Console.WriteLine("\nEntered Scores are: ");
            foreach(int sn in score)
            {
            Console.WriteLine($"Match {count} " + sn);
            count++;
            
            
            }
    }


         static int sum = 0;
         static int avg = 0;
        static void avgNum()
        {
            for(int i=0;i<score.Length;i++)
            {
                sum += score[i];
                avg = sum / 6;
            }
            Console.WriteLine($"\nSum of scores: {sum} scores");
            Console.WriteLine($"Average of scores: {avg}");

        }



        static void highestScore()
        {
            int largest=score[0];
        int count = 1;

            for(int i=1;i<score.Length;i++)
            
        {
            count++;
            if (score[i]>largest)
            {
                largest = score[i];
                
  
                Console.WriteLine($"\nMatch {count} has Highest Score  {largest}");
          
            }
            


        }
        


    }

    
    
}