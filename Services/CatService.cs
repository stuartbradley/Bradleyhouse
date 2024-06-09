namespace BradleyHouse.Services
{
    public class CatService
    {
        private string _baseUrl => "Cataas.com/cat";

        public string GetHelloMessage()
        {
            string day = DateTime.Now.DayOfWeek.ToString();
            return $"/says/Happy%20{day}?y?fontSize=30&fontColor=%23f0f0f0&fontBackground=none&position=bottom";
        }
    }
}
