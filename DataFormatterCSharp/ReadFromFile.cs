using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataFormatterCSharp
{
    class ReadFromFile
    {
        //Gold per floor: index+1 will be floor number
        ArrayList gold_floor = new ArrayList();

        //floor_reached
        long floor_reached;

        //items purged
        Dictionary<int, string> items_purged = new Dictionary<int, string>();
        ArrayList items_purged_list = new ArrayList();
        int index_item_purged = 0;

        //relics added from the variable "relics_obtained"
        Dictionary<int, string> relics = new Dictionary<int, string>();

        //character chosen: 0 - ironclad, 1- silent, 2 - defect, 3 - watcher
        int character;

        //items purchased
        Dictionary<int, string> items_purchased = new Dictionary<int, string>();

        //hp per floor: floor will be index+1
        ArrayList hp_floor = new ArrayList();

        //path taken for each act. ends with BOSS
        ArrayList path_act_1 = new ArrayList();
        ArrayList path_act_2 = new ArrayList();
        ArrayList path_act_3 = new ArrayList();

        //Victory: 0 - false, 1 - true
        int victory;

        //Cards in deck.
        ArrayList deck = new ArrayList();
        //When cards where obtained
        Dictionary<int, string> cards_floor_obtained = new Dictionary<int, string>();

        //Ascension level
        int ascension_level;

        bool first = true;
        public ReadFromFile()
        {

        }


        
        /// <summary>
        /// Read from file and add to variables
        /// </summary>
        public void Read()
        {
            StreamReader streamReader = File.OpenText(@"C:\Users\oscar\source\repos\DataFormatterCSharp\DataFormatterCSharp\testset.json");
            JsonTextReader reader = new JsonTextReader(streamReader);

            string category = "";
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    //Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                    if(reader.TokenType.ToString() == "PropertyName")
                    {
                        category = (string)reader.Value;
                        if (category == "event")
                        {
                            if (!first)
                            {
                                Print();
                                EmptyVariables();
                            }
                            if (first)
                            {
                                first = false;
                            }
                        }
                    }
                    else
                    {      

                        if (category == "gold_per_floor")
                        {
                            gold_floor.Add(Convert.ToInt32(reader.Value));
                        }

                        if (category == "floor_reached")
                        {
                            floor_reached = Convert.ToInt32(reader.Value);
                        }

                        if(category == "items_purged")
                        {
                            items_purged_list.Add(reader.Value);
                        }

                        if(category == "items_purged_floors")
                        {
                            items_purged.Add(Convert.ToInt32(reader.Value), (string)items_purged_list[index_item_purged]);
                            index_item_purged++;
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("Token: {0}", reader.TokenType);
                }
            }
            Print();
        }
        public void Print()
        {
            foreach (int i in gold_floor)
            {
                Console.WriteLine(i);
            }

            foreach(var v in items_purged)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine(floor_reached);
        }
        private void EmptyVariables()
        {
            gold_floor.Clear();
            items_purged.Clear();
            items_purged_list.Clear();
            index_item_purged = 0;
        }
    }
}
