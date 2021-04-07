using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormatterCSharp
{
    class DeserializedJson
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class CampfireChoice
        {
            public string data { get; set; }
            public int floor { get; set; }
            public string key { get; set; }
        }

        public class DamageTaken
        {
            public int damage { get; set; }
            public string enemies { get; set; }
            public int floor { get; set; }
            public int turns { get; set; }
        }

        public class PotionsObtained
        {
            public int floor { get; set; }
            public string key { get; set; }
        }

        public class CardChoice
        {
            public List<string> not_picked { get; set; }
            public string picked { get; set; }
            public int floor { get; set; }
        }

        public class RelicsObtained
        {
            public int floor { get; set; }
            public string key { get; set; }
        }

        public class EventChoice
        {
            public int damage_healed { get; set; }
            public int gold_gain { get; set; }
            public string player_choice { get; set; }
            public int damage_taken { get; set; }
            public int max_hp_gain { get; set; }
            public int max_hp_loss { get; set; }
            public string event_name { get; set; }
            public int floor { get; set; }
            public int gold_loss { get; set; }
            public List<string> cards_upgraded { get; set; }
        }

        public class BossRelic
        {
            public List<string> not_picked { get; set; }
        }

        public class Event
        {
            public List<int> gold_per_floor { get; set; }
            public int floor_reached { get; set; }
            public int playtime { get; set; }
            public List<string> items_purged { get; set; }
            public int score { get; set; }
            public string play_id { get; set; }
            public string local_time { get; set; }
            public bool is_ascension_mode { get; set; }
            public List<CampfireChoice> campfire_choices { get; set; }
            public string neow_cost { get; set; }
            public long seed_source_timestamp { get; set; }
            public int circlet_count { get; set; }
            public List<string> master_deck { get; set; }
            public List<string> relics { get; set; }
            public List<int> potions_floor_usage { get; set; }
            public List<DamageTaken> damage_taken { get; set; }
            public string seed_played { get; set; }
            public List<PotionsObtained> potions_obtained { get; set; }
            public bool is_trial { get; set; }
            public List<string> path_per_floor { get; set; }
            public string character_chosen { get; set; }
            public List<string> items_purchased { get; set; }
            public int campfire_rested { get; set; }
            public List<int> item_purchase_floors { get; set; }
            public List<int> current_hp_per_floor { get; set; }
            public int gold { get; set; }
            public string neow_bonus { get; set; }
            public bool is_prod { get; set; }
            public bool is_daily { get; set; }
            public bool chose_seed { get; set; }
            public int campfire_upgraded { get; set; }
            public int win_rate { get; set; }
            public int timestamp { get; set; }
            public List<string> path_taken { get; set; }
            public string build_version { get; set; }
            public int purchased_purges { get; set; }
            public bool victory { get; set; }
            public List<int> max_hp_per_floor { get; set; }
            public List<CardChoice> card_choices { get; set; }
            public int player_experience { get; set; }
            public List<RelicsObtained> relics_obtained { get; set; }
            public List<EventChoice> event_choices { get; set; }
            public bool is_beta { get; set; }
            public List<BossRelic> boss_relics { get; set; }
            public List<int> items_purged_floors { get; set; }
            public bool is_endless { get; set; }
            public List<int> potions_floor_spawned { get; set; }
            public int ascension_level { get; set; }
        }

        public class Root
        {
            public Event @event { get; set; }
        }
    }
}
