namespace OpenseaBlzui.Pages
{
    public partial class Main
    {
        private string menuNumber = "1";

        void OnTabChange(string key)
        {
            Console.WriteLine($"tab change:{key}");
        }
    }
}
