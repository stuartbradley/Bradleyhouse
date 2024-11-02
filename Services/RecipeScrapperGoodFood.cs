using System.Net;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace BradleyHouse.Services
{
    public class RecipeScrapperGoodFood
    {

        public void Scrape(string url)
        {
            var web = new HtmlWeb();
            var document = web.Load("https://www.bbcgoodfood.com/recipes/easy-thai-prawn-curry");

            var nodes = document.DocumentNode.SelectNodes("/html/body/div[1]/div[4]/main/div[2]/div/div[3]/div[1]/div[1]/div[5]/div/div/section");
            var foods = nodes.Descendants("li");
            var list = new List<string>();
            foreach (var ingredient in foods)
            {
                list.Add(ingredient.InnerText);
            }
        }
    }
}
