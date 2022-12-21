using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Grocy
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    internal class GrocyJson
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string product_group_id { get; set; }
        public string active { get; set; }
        public string location_id { get; set; }
        public string shopping_location_id { get; set; }
        public string qu_id_purchase { get; set; }
        public string qu_id_stock { get; set; }
        public string qu_factor_purchase_to_stock { get; set; }
        public string min_stock_amount { get; set; }
        public string default_best_before_days { get; set; }
        public string default_best_before_days_after_open { get; set; }
        public string default_best_before_days_after_freezing { get; set; }
        public string default_best_before_days_after_thawing { get; set; }
        public string picture_file_name { get; set; }
        public string enable_tare_weight_handling { get; set; }
        public string tare_weight { get; set; }
        public string not_check_stock_fulfillment_for_recipes { get; set; }
        public object parent_product_id { get; set; }
        public string calories { get; set; }
        public string cumulate_min_stock_amount_of_sub_products { get; set; }
        public string due_type { get; set; }
        public string quick_consume_amount { get; set; }
        public string hide_on_stock_overview { get; set; }
        public string default_stock_label_type { get; set; }
        public string should_not_be_frozen { get; set; }
        public string row_created_timestamp { get; set; }
        public string treat_opened_as_out_of_stock { get; set; }
        public string no_own_stock { get; set; }
        public string default_consume_location_id { get; set; }
        public string move_on_open { get; set; }
    }

    public class ShoppingItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Done { get; set; }
    }

    internal class GrocyShoppingJson
    {
        public string id { get; set; }
        public string product_id { get; set; }
        public string note { get; set; }
        public string amount { get; set; }
        public string row_created_timestamp { get; set; }
        public string shopping_list_id { get; set; }
        public string done { get; set; }
        public string qu_id { get; set; }
    }
}