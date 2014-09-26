//HashTableAssignment.cs
//Created by Annika Magnusson 2014-09-18
//2014-09-25 Added code in switch to call methods in hashtable  
//2014-09-26 Added comments
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAssignment
{
    /// <summary>
    /// Class to display a menu
    /// </summary>
    class MainMenu
    {
        private static int numberOfElements = 15;
        private Hashtable hashtable = new Hashtable(numberOfElements);

        /// <summary>
        /// Calls the method Start on startup.
        /// </summary>
        public MainMenu()
        {
            Start();
        }

        /// <summary>
        /// Displays a start menu which gives the user a number of choices.
        /// </summary>
        private void Start()
        {
            int choiceInMenu = -1;

            while (choiceInMenu != 0)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("              Linked Hash Table           ");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Do you want to:                           ");
                Console.WriteLine("     1) Add word                          ");
                Console.WriteLine("     2) See word                          ");
                Console.WriteLine("     3) Remove word                       ");
                Console.WriteLine("     4) See number of words               ");
                Console.WriteLine("     5) See all the words                 ");
                Console.WriteLine("     0) Exit application                  ");
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choiceInMenu))
                {
                    switch (choiceInMenu)
                    {
                        case 0:
                            break;
                        case 1: //Adds the desired word if it doesn't allready exists
                            Console.WriteLine("Add word");
                            Console.Write("Add swedish word: ");
                            object key = Console.ReadLine();
                            Console.Write("Add english word: ");
                            object value = Console.ReadLine();
                            if (hashtable.Put(key, value))
                                Console.WriteLine("The word has been added.");
                            else
                                Console.WriteLine("The word was allready in list");
                            break;
                        case 2: //Shows the desired word if it is in table
                            Console.WriteLine("See word");
                            Console.Write("Enter word to see: ");
                            object word = hashtable.Get(Console.ReadLine());
                            if (word == null)
                                Console.WriteLine("The word wasn't in hash table");
                            else
                                Console.WriteLine("The english translation is: " + word);
                            break;
                        case 3: //Removes the desired word if it is in table
                            Console.WriteLine("Remove word");
                            Console.Write("Enter word to remove: ");
                            if (hashtable.Remove(Console.ReadLine()))
                                Console.WriteLine("The word has been removed.");
                            else
                                Console.WriteLine("Word wasn't in hash table");
                            break;
                        case 4: //Presents the number of words in table
                            if (hashtable.Count < 1)
                                Console.WriteLine("There are no words in hash table.");
                            else
                                Console.WriteLine("No of words in list are: " + hashtable.Count);
                            break;
                        case 5: //Displays the words in the table if there are any
                            if (hashtable.Count < 1)
                                Console.WriteLine("There are no words in hash table.");
                            else
                            {
                                foreach (object o in hashtable.GetInsertionOrder())
                                {
                                    Console.WriteLine(o);
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input, please try again!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again");
                    choiceInMenu = -1;
                }
            }
        }
    }
}
