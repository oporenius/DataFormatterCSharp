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
        //Dictionary<int, string> items_purged = new Dictionary<int, string>();
        //ArrayList items_purged_list = new ArrayList();
        //int index_item_purged = 0;

        //relics added from the variable "relics_obtained"
        //Dictionary<int, string> relics = new Dictionary<int, string>();
        ArrayList relics_all = new ArrayList();
        //string floor_or_key = "";
        //int floor = 0;

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
        int current_act = 1;

        //Victory: 0 - false, 1 - true
        int victory;

        //Cards in deck.
        ArrayList deck = new ArrayList();
        //When cards where obtained
        //Dictionary<int, string> cards_floor_obtained = new Dictionary<int, string>();

        //Ascension level
        int ascension_level;

        StreamWriter sw;
        bool shouldWrite = true;


        bool first = true;
        public ReadFromFile()
        {

        }



        /// <summary>
        /// Read from file and add to variables
        /// </summary>
        public void Read()
        {
            int writeIndex = 1;
            foreach(string filePath in Directory.EnumerateFiles(@"C:\Users\oscar\source\repos\DataFormatterCSharp\DataFormatterCSharp\Data", "*.json"))
            {
                StreamReader streamReader = File.OpenText(filePath);
                JsonTextReader reader = new JsonTextReader(streamReader);
                sw = new StreamWriter(@"C:\Users\oscar\source\repos\DataFormatterCSharp\DataFormatterCSharp\Outputs\training" + writeIndex + ".csv");
                writeIndex++;
                //sw.WriteLine("character,ascension,floor,hp,gold,path,deck,relics,victory");
                sw.WriteLine("character,ascension,floor,hp,gold,r1,r2,r3,r4,r5,r6,r7,r8,r9,r10,r11,r12,r13,r14,r15,r16,deck,relics,victory");
                sw.Flush();

                string category = "";
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        //Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                        if (reader.TokenType.ToString() == "PropertyName" &&
                            (string)reader.Value != "floor" && (string)reader.Value != "key")
                        {
                            category = (string)reader.Value;
                            if (category == "event")
                            {
                                if (!first)
                                {
                                    Print(sw);
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

                            //if(category == "items_purged")
                            //{
                            //    items_purged_list.Add(reader.Value);
                            //}

                            //if(category == "items_purged_floors")
                            //{
                            //    items_purged.Add(Convert.ToInt32(reader.Value), (string)items_purged_list[index_item_purged]);
                            //    index_item_purged++;
                            //}

                            //add to seperate list for control when using item purchased
                            if (category == "relics")
                            {
                                relics_all.Add((string)reader.Value);
                            }

                            //if (category == "relics_obtained")
                            //{
                            //    if(reader.TokenType.ToString() == "PropertyName")
                            //    {
                            //        floor_or_key = (string)reader.Value;
                            //    }
                            //    else
                            //    {
                            //        if(floor_or_key == "floor")
                            //        {
                            //            floor = Convert.ToInt32(reader.Value);
                            //        }else if(floor_or_key == "key")
                            //        {
                            //            relics.Add(floor, (string)reader.Value);
                            //        }
                            //    }
                            //}

                            if (category == "character_chosen")
                            {
                                if ((string)reader.Value == "IRONCLAD")
                                {
                                    character = 0;
                                }
                                else if ((string)reader.Value == "SILENT")
                                {
                                    character = 1;
                                }
                                else if ((string)reader.Value == "DEFECT")
                                {
                                    character = 2;
                                }
                                else
                                {
                                    character = 3;
                                }
                            }

                            if (category == "current_hp_per_floor")
                            {
                                hp_floor.Add(Convert.ToInt32(reader.Value));
                            }

                            if (category == "path_taken")
                            {
                                string v = (string)reader.Value;
                                if (current_act == 1)
                                {
                                    path_act_1.Add(v);
                                }
                                else if (current_act == 2)
                                {
                                    path_act_2.Add(v);
                                }
                                else if (current_act == 3)
                                {
                                    path_act_3.Add(v);
                                }
                                if (v == "BOSS")
                                {
                                    current_act++;
                                }
                            }

                            if (category == "victory")
                            {
                                if ((bool)reader.Value)
                                {
                                    victory = 1;
                                }
                                else
                                {
                                    victory = 0;
                                }
                            }

                            if (category == "master_deck")
                            {
                                deck.Add((string)reader.Value);
                            }

                            if (category == "ascension_level")
                            {
                                ascension_level = Convert.ToInt32(reader.Value);
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Token: {0}", reader.TokenType);

                    }
                }
                Print(sw);

                sw.Close();
            }

           
        }
        public void Print(StreamWriter sw)
        {
            StringBuilder deck_string = new StringBuilder();
            foreach (string s in deck)
            {
                deck_string.Append(s + "|");
            }
            deck_string.Remove(deck_string.Length - 1, 1);

            StringBuilder relics_string = new StringBuilder();
            foreach (string r in relics_all)
            {
                relics_string.Append(r + "|");
            }
            relics_string.Remove(relics_string.Length - 1, 1);

            
            if(deck_string.Length < 1 || relics_string.Length < 1)
            {
                shouldWrite = false;
            }

            for (int i = 0; i < hp_floor.Count; i++)
            {
                //"character,ascension_level,floor,hp,gold,path taken,deck,relics,victory"
                StringBuilder path = new StringBuilder();
                PathString(i, path);

                if (shouldWrite)
                {
                    shouldWrite = true;
                    var line = string.Format("{0},{1},{2},{3},{4},{5}{6},{7},{8}", character,
                    ascension_level, i + 1, hp_floor[i], gold_floor[i], path,
                    deck_string, relics_string, victory);
                    sw.WriteLine(line);
                }
            }
            sw.Flush();
        }

        private void PathString(int i, StringBuilder path)
        {
            
            for (int j = 0; j < 16; j++)
            {
                if(path_act_1.Count > j)
                {
                    path.Append(path_act_1[j] + ",");
                }
                else
                {
                    path.Append("*,");
                }
            }

            if (i > 16)
            {
                path.Clear();
                for (int k = 0; k < 16; k++)
                {
                    if(path_act_2.Count > k)
                    {
                        path.Append(path_act_2[k] + ",");

                    }
                    else
                    {
                        path.Append("*,");
                    }
                }
            }

            if (i > 32)
            {
                path.Clear();
                for (int l = 0; l < 16; l++)
                {
                    if (path_act_3.Count > l)
                    {
                        path.Append(path_act_3[l] + ",");
                    }
                    else
                    {
                        path.Append("*,");
                    }
                }
            }

            if(path.Length < 1)
            {
                shouldWrite = false;
            }
            //path.Remove(path.Length - 1, 1);
        }

        private void EmptyVariables()
        {
            gold_floor.Clear();
            //items_purged.Clear();
            //items_purged_list.Clear();
            //index_item_purged = 0;
            //relics.Clear();
            relics_all.Clear();
            //floor = 0;
            character = 0;
            hp_floor.Clear();
            path_act_1.Clear();
            path_act_2.Clear();
            path_act_3.Clear();
            current_act = 1;
            deck.Clear();
            shouldWrite = true;
        }
    }
}
