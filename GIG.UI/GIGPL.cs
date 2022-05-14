using System;
using System.Collections.Generic;
using System.Text;
using GIG.BL;
using GIG.Exceptions;
using GIG.Entity;

namespace GIG.UI
{
    class GIGPL
    {
        //Gig gigObj = null;
        GigBl gigBl = null;
        public GIGPL()
        {
            gigBl = new GigBl();
        }
        public static void GIGMenu()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\tGIG Menu");
            Console.WriteLine("============================================");
           // Console.WriteLine("----Menu Items----");
            Console.WriteLine("  1.  Add GIG Details.");
            Console.WriteLine("  2.  Update GIG Details.");
            Console.WriteLine("  3.  Delete GIG Detials.");
            Console.WriteLine("  4.  Show GIG Detials By GID_ID.");
            Console.WriteLine("  5.  Show All GIG Detials");
            Console.WriteLine("  6.  Show GIG Detials By Artist");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void GIGMain()
        {
            int choice = 1;
            do
            {
                GIGMenu();
                Console.WriteLine("---------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n"+"Enter Your Choice from above Menu  :  ");
                choice = Int32.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                switch (choice)
                {
                    case 1:
                        {
                            AddGigUi();
                            break;
                        }
                    case 2:
                        {
                            UpdateGigUi();
                            break;
                        }
                    case 3:
                        {
                            DeleteGigUi();
                            break;
                        }
                    case 4:
                        {
                            SearchGIGByIdUi();
                            break;
                        }
                    case 5:
                        {
                            ShowAllGigUi();
                            break;
                        }
                    default:
                        Console.WriteLine("Please enter your choice in 1-5");
                        break;
                }

            } while (choice != -1);
        }
        public void AddGigUi()
        {
            try
            {
                GigBl gigBl = new GigBl();
                Gig gigObj = new Gig();

                gigObj = new Gig();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please Enter GIG ID       :\t");
                gigObj.GIG_ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please Enter GIG DateTime :\t");
                gigObj.TIMING = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Please Enter GIG Venue    :\t");
                gigObj.VENUE = Console.ReadLine();

                Console.Write("Please Enter GIG Artist   :\t");
                gigObj.ARTIST = Console.ReadLine();

                Console.Write("Please Enter GIG Genre    :\t");
                gigObj.GENRE = Console.ReadLine();
                Console.WriteLine();

                //Console.Write("Please Enter GIG Genre    :\t");
                gigObj.ISCANCELLED = "n";
                Console.WriteLine();

                gigBl.AddGig(gigObj);

                //Console.WriteLine("Please Enter GIG Description :");
                //gigObj.ISCANCELLED = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tRecord Added...\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void UpdateGigUi()
        {
            try
            {
                Gig gigObj = new Gig();
                GigBl gigBl = new GigBl();

                Console.Write("Enter GIG_ID     :  ");
                gigObj.GIG_ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter DateTime   :  ");
                gigObj.TIMING = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Venue      :  ");
                gigObj.VENUE = Console.ReadLine();

                Console.Write("Enter Artist     :  ");
                gigObj.ARTIST = Console.ReadLine();

                Console.Write("Enter Genre      :  ");
                gigObj.GENRE = Console.ReadLine();

                Console.WriteLine("Enter IsCanceled :  (y/n)");
                gigObj.ISCANCELLED = Console.ReadLine();
                Console.WriteLine();

                gigBl.UpdateGig(gigObj);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("         ---GiG Updated---            ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            catch (CustomException e)
            {
                throw e;
            }
        }
        public static void DeleteGigUi()
        {
            try
            {
                 Console.WriteLine("      Enter Gig Id to be Deleted     " + "\n");

                    Gig gigObj = new Gig();
                    GigBl gigBl = new GigBl();

                //if (gigObj.GIG_ID != null)
                //{
                    Console.Write("Enter Gig Id  :  ");
                    gigObj.GIG_ID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    GigBl.DeleteGigBl(gigObj);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("      Gig deleted successfully..." + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                //}
                //else
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine("       Enter Valid Id   ");
                //}
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SearchGigByArtistUi()
        {

        }
        public void SearchGIGByIdUi()
        {            
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please Enter GIGID  :  ");
                int GIG_ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                Gig gigObj = gigBl.SearchGigByID(GIG_ID);

                if (gigObj != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\t\tGIG Details");
                    Console.WriteLine("=============================================");
                    Console.WriteLine($"GIG ID         :  {gigObj.GIG_ID}");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"GIG DATETIME   :  {gigObj.TIMING}");
                    Console.WriteLine($"GIG VENUE      :  {gigObj.VENUE}" );
                    Console.WriteLine($"GIG ARTIST     :  {gigObj.ARTIST}");
                    Console.WriteLine($"GIG GENRE      :  {gigObj.GENRE}" );
                    Console.WriteLine($"GIG IsCANCELED :  {gigObj.ISCANCELLED}");
                    Console.WriteLine("---------------------------------------------" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }                
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n"+"Invalid Id"+"\n");                    
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }                        
        }
        public void ShowAllGigUi()
        {
            try
            {
                List<Gig> tempList = gigBl.ShowAllGig();

                if (tempList != null)
                {
                    foreach (var gObj in tempList)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\t\tGIG Details");
                        Console.WriteLine("=============================================");
                        Console.WriteLine($"GIG_Id         :  {gObj.GIG_ID}");
                        //Console.WriteLine("---------------------------------");
                        Console.WriteLine($"GIG DATETIME   :  {gObj.TIMING}");
                        Console.WriteLine($"GIG VENUE      :  {gObj.VENUE}");
                        Console.WriteLine($"GIG ARTIST     :  {gObj.ARTIST}");
                        Console.WriteLine($"GIG GENRE      :  {gObj.GENRE}");
                        Console.WriteLine($"GIG IsCANCELED :  {gObj.ISCANCELLED}");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot Fetch the data from DataBase");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
