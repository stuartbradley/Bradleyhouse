namespace BradleyHouse.Services
{
    public class CatService
    {
        private string _baseUrl => "www.Cataas.com/cat";

        public string GetHelloMessage()
        {
            string day = DateTime.Now.DayOfWeek.ToString();
            return $"https://cataas.com/cat/says/Happy%20{day}?font=Impact&fontSize=30&fontColor=%23f0f0f0&fontBackground=none&position=center&width=400&height=400";
        }
    }
}
