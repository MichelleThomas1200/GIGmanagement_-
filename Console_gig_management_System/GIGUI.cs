using GIG.Entity;
using System;
using GIG.BL;
using GIG.Exceptions;
using System.Collections.Generic;

namespace Console_gig_management_System
{
    public class GIGUI
    {
        Gig gigObj = null;
        GigBl gigBl = null;
        public GIGUI()
        {
            gigBl = new GigBl();
        }  
        public static void GIGMenu()
        {
            Console.WriteLine("\t\tGIG Menu");
            Console.WriteLine("==============================================");
            Console.WriteLine("----Menu Items----");
            Console.WriteLine("1.\t Add GIG Details.");
            Console.WriteLine("2.\t Update GIG Details.");
            Console.WriteLine("3.\t Delete GIG Detials.");
            Console.WriteLine("4.\t Show GIG Detials By GID_ID.");
            Console.WriteLine("5.\t Show All GIG Detials");
            Console.WriteLine("6.\t Show GIG Detials By Artist");
        }
        public  void GIGMain()
        {
            int choice = 1;
            do
            {
                GIGMenu();
                Console.WriteLine("Enter Your Choice from above Menu:");
                choice = Int32.Parse(Console.ReadLine());
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
                Console.WriteLine("Please Enter GIG ID :");
                gigObj.GIG_ID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please Enter GIG DateTime :");
                gigObj.DATETIME = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Please Enter GIG Venue:");
                gigObj.VENUE = Console.ReadLine();

                Console.WriteLine("Please Enter GIG Artist:");
                gigObj.ARTIST = Console.ReadLine();

                Console.WriteLine("Please Enter GIG Genre:");
                gigObj.GENRE = Console.ReadLine();

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
                Console.WriteLine("Enter GIG_ID");
                gigObj.GIG_ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter DateTime");
                gigObj.DATETIME = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Venue");
                gigObj.VENUE = Console.ReadLine();
                Console.WriteLine("Enter Artist");
                gigObj.ARTIST = Console.ReadLine();
                Console.WriteLine("Enter Genre");
                gigObj.GENRE = Console.ReadLine();
                Console.WriteLine("Enter IsCanceled");
                gigObj.ISCANCELLED = Convert.ToBoolean(Console.ReadLine());
                gigBl.UpdateGig(gigObj);
                Console.WriteLine("-----GiG Updated-----");

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
                Console.WriteLine("-----Delete Gig -----");
                //
               // int GIG_ID;
                Gig gigObj = new Gig();
                GigBl gigBl = new GigBl();
               
                //
                Console.WriteLine("Enter Gig_Id:");
                gigObj.GIG_ID = Convert.ToInt32(Console.ReadLine());
                GigBl.DeleteGigBl(gigObj);
                Console.WriteLine("Gig deleted successfully.");
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

                Console.Write("Please Enter GIGID :");
                int GIG_ID = Convert.ToInt32(Console.ReadLine());
                Gig gigObj = gigBl.SearchGigByID(GIG_ID);
                if (gigObj != null)
                {
                    Console.WriteLine("\t\tGIG Details");
                    Console.WriteLine("=================================");
                    Console.WriteLine($"GIG ID :{gigObj.GIG_ID}");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"GIG DATETIME :{gigObj.DATETIME}");
                    Console.WriteLine($"GIG VENUE  :{gigObj.VENUE}");
                    Console.WriteLine($"GIG ARTIST :{gigObj.ARTIST}");
                    Console.WriteLine($"GIG GENRE  :{gigObj.GENRE}");
                    Console.WriteLine($"GIG IsCANCELED :{gigObj.ISCANCELLED}");
                    Console.WriteLine("-----------------------------------");

                }
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //if (true)
            //{
            //     finally
            //    {
            //        Console.WriteLine("Enter Valid ID");
            //    }

            //}

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
                        Console.WriteLine("\t\tGIG Details");
                        Console.WriteLine("=================================");
                        Console.WriteLine($"GIG_Id :{gObj.GIG_ID}");
                        //Console.WriteLine("---------------------------------");
                        Console.WriteLine($"GIG DATETIME :{gObj.DATETIME}");
                        Console.WriteLine($"GIG VENUE  :{gObj.VENUE}");
                        Console.WriteLine($"GIG ARTIST :{gObj.ARTIST}");
                        Console.WriteLine($"GIG GENRE  :{gObj.GENRE}");
                        Console.WriteLine($"GIG IsCANCELED :{gObj.ISCANCELLED}");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine();
                    }
                }
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
