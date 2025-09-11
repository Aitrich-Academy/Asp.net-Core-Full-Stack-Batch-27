using HiringManagementSystem.Managers;

internal class Program
{
    private static void Main(string[] args)
    {
        JobManager jobManager = new JobManager();       // ✅ create JobManager
        PublicManager publicManager = new PublicManager(jobManager);  // ✅ inject JobManager
        publicManager.DisplayMenu();
    }
}
