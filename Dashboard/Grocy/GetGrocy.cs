using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Dashboard.Grocy
{
    internal class GetGrocy
    {
        public static List<Item> Items { get; set; } = new();
        public static List<Item> GetItems()
        {
            var client = new RestClient("http://grocy.tim-u.me/api/objects/products");
            var request = new RestRequest();

            //TODO grocy key
            request.AddHeader("GROCY-API-KEY", "ulX6aty65YmwQCuwU8F7GEsmH8EWwGSG83pjBsCjGISWDplj4u");
            var result = client.Execute(request);

            List<GrocyJson> jsonItems = new();
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception();
            }

            jsonItems = JsonConvert.DeserializeObject<List<GrocyJson>>(result.Content);
            foreach (var jsonItem in jsonItems)
            {
                Item item = new()
                {
                    Name = jsonItem.name,
                    Id = int.Parse(jsonItem.id),
                    Description = jsonItem.description
                };
                
                Items.Add(item);
            }

            return Items;
        }

        public static List<ShoppingItem> GetShoppingItems()
        {
            var client = new RestClient("http://grocy.tim-u.me/api/objects/shopping_list");
            var request = new RestRequest();

            //TODO grocy key
            request.AddHeader("GROCY-API-KEY", "ulX6aty65YmwQCuwU8F7GEsmH8EWwGSG83pjBsCjGISWDplj4u");
            var result = client.Execute(request);

            List<GrocyShoppingJson> jsonitems = new();
            List<ShoppingItem> items = new();
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception();
            }

            jsonitems = JsonConvert.DeserializeObject<List<GrocyShoppingJson>>(result.Content);

            foreach (var item in jsonitems)
            {
                ShoppingItem shoppingItem = new()
                {
                    Id = int.Parse(item.id),
                    ProductId = int.Parse(item.product_id),
                    Amount = int.Parse(item.amount),
                };

                shoppingItem.Name = Items.First(x => x.Id == int.Parse(item.product_id)).Name;
                shoppingItem.Done = int.Parse(item.done) != 0;

                items.Add(shoppingItem);
            }
            
            return items;
        }
    }
}
