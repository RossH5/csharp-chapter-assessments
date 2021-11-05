using System;
using System.Collections.Generic;
using System.IO;

namespace MeetingApp
{
    public class Meeting
    {
        private string title;
        private string location;
        private DateTime startDateTime;
        private DateTime endDateTime;

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public DateTime StartDateTime
        {
            get
            {
                return this.startDateTime;
            }
            set
            {
                this.startDateTime = value;
            }
        }

        public DateTime EndDateTime
        {
            get
            {
                return this.endDateTime;
            }
            set
            {
                this.endDateTime = value;
            }
        }
        public Meeting() { }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            bool userMenu = true;
            bool welcomeMenu = true;
            string fileLocation = "";
            List<Meeting> listOfMeetings = new List<Meeting>();

            do
            {
                try
                {
                    do
                    {
                        Console.WriteLine("Welcome to the Meeting App!\n");
                        Console.WriteLine("What would you like to do?\n1. Load calendar from file\n" +
                                "2. Create new calendar\n0. Exit\n");
                        int welcomeSelection = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n");
                        switch (welcomeSelection)
                        {
                            case 1:
                                Console.WriteLine("Input file path: ");
                                fileLocation = Console.ReadLine();
                                welcomeMenu = false;
                                listOfMeetings = LoadCalendar(fileLocation);
                                Console.WriteLine("\n");
                                break;
                            case 2:
                                Console.Write("Where would you like to store the file? ");
                                fileLocation = Console.ReadLine();
                                File.Create(fileLocation).Close();  
                                welcomeMenu = false;
                                Console.WriteLine("\n");
                                break;
                            case 0:
                                Environment.Exit(1);
                                break;
                            default:
                                Console.WriteLine("Invalid Input\n");
                                break;
                        }
                    } while (welcomeMenu);

                    do
                    {
                        Console.WriteLine("What would you like to do?\n\n1. Add meeting to calendar\n" +
                             "2. Remove meeting from calendar\n3. View schedule\n0. Go Back\n");
                        int userChoice = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n");

                        switch (userChoice)
                        {
                            case 1:
                                listOfMeetings = AddMeeting(listOfMeetings);
                                break;
                            case 2:
                                listOfMeetings = RemoveMeeting(listOfMeetings);
                                break;
                            case 3:
                                DateTime start = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
                                         DateTime.Today.Day, 08, 00, 00, DateTimeKind.Local);
                                DateTime end = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
                                     DateTime.Today.Day, 17, 00, 00, DateTimeKind.Local);

                                while (start != end)
                                {
                                    string meetingTitle = " ";

                                    foreach (Meeting meeting in listOfMeetings)
                                    {
                                        if ((start >= meeting.StartDateTime) & (start <= meeting.EndDateTime))
                                        {
                                            meetingTitle = meeting.Title;
                                        }
                                    }
                                    Console.WriteLine("{0} | {1}", start.ToString("MM/dd/yy HH:mm"), meetingTitle);

                                    start = start.AddMinutes(30);
                                };

                                Console.WriteLine("\n");
                                break;
                            case 0:
                                welcomeMenu = true;
                                userMenu = false;
                                break;
                            default:
                                Console.WriteLine("\nInvalid Input Try Again\n");
                                break;
                        }
                    } while (userMenu);

                    string fileString = "";

                    if (fileLocation != "")
                    {
                        foreach (Meeting myMeetings in listOfMeetings)
                        {
                            fileString += myMeetings.Title + "," + myMeetings.Location + "," + myMeetings.StartDateTime
                                 + "," + myMeetings.EndDateTime + "\n";
                        }
                        File.WriteAllText(@fileLocation, fileString);
                    }
                    fileLocation = "";

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input try again\n");
                    welcomeMenu = false;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("\nFile Not Found \n");
                    welcomeMenu = true;
                }
                catch (IOException)
                {
                    Console.WriteLine("\nFile Location not valid. Please try again\n");
                    fileLocation = "";
                    welcomeMenu = true;
                }
            } while (true);
        }

        static List<Meeting> AddMeeting(List<Meeting> inputList)
        {
            var newMeeting = new Meeting();
            try
            {
                Console.Write("Meeting Title: ");
                newMeeting.Title = Console.ReadLine();

                Console.Write("Meeting Location: ");
                newMeeting.Location = Console.ReadLine();

                Console.Write("Meeting start date: ");
                newMeeting.StartDateTime = DateTime.Parse(Console.ReadLine());

                Console.Write("Meeting end date: ");
                newMeeting.EndDateTime = DateTime.Parse(Console.ReadLine());

                foreach (Meeting existingMeeting in inputList)
                {
                    if ((newMeeting.StartDateTime <= existingMeeting.StartDateTime && newMeeting.EndDateTime >= existingMeeting.EndDateTime)
                        || (newMeeting.StartDateTime >= existingMeeting.StartDateTime && newMeeting.StartDateTime < existingMeeting.EndDateTime)
                         || (newMeeting.EndDateTime > existingMeeting.StartDateTime && newMeeting.EndDateTime <= existingMeeting.EndDateTime))
                    {
                        Console.Write("Time conflict with {0} {1} - {2}. Would you like to replace the prior meeting? (Y/N): ",
                        existingMeeting.Title, existingMeeting.StartDateTime.ToString("f"), existingMeeting.EndDateTime.ToString("t"));
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "YES":
                            case "Yes":
                            case "yes":
                            case "Y":
                            case "y":
                                inputList.Remove(existingMeeting);
                                inputList.Add(newMeeting);
                                return inputList;
                            case "NO":
                            case "No":
                            case "no":
                            case "N":
                            case "n":
                                return inputList;
                            default:
                                Console.WriteLine("\nInput not recognized. Returning to Menu \n");
                                return inputList;
                        }
                    }
                }
                inputList.Add(newMeeting);
                Console.WriteLine("\nMeeting Added!\n");
                return inputList;
            }
            catch
            {
                Console.WriteLine("Meeting unable to be added");
                return inputList;
            }
        }
        static List<Meeting> RemoveMeeting(List<Meeting> inputList)
        {
            Console.WriteLine("Current Meeting List\n");
            foreach (Meeting meeting in inputList)
            {
                Console.WriteLine("Title: {0}\nLocation: {1}\nTime: {2} - {3}\n", meeting.Title, meeting.Location,
                    meeting.StartDateTime.ToString("f"), meeting.EndDateTime.ToString("t"));
            }
            Console.Write("Please input the title of the meeting you would like to remove: ");
            string removedMeeting = Console.ReadLine();

            int totalRemoved = inputList.RemoveAll(meeting => meeting.Title == removedMeeting);

            if (totalRemoved == 0)
            {
                Console.WriteLine("\nMeeting not found \n");
                return inputList;
            }
            Console.WriteLine("\nMeeting successfully removed!\n");
            return inputList;
        }
        static List<Meeting> LoadCalendar(string filePath)
        {
            IEnumerable<string> fileContents = File.ReadLines(filePath);
            List<Meeting> returnList = new List<Meeting>();

            foreach (string fileLine in fileContents)
            {
                var newMeeting = new Meeting();
                string[] fileLineArray = fileLine.Split(",");
                newMeeting.Title = fileLineArray[0];
                newMeeting.Location = fileLineArray[1];
                newMeeting.StartDateTime = DateTime.Parse(fileLineArray[2]);
                newMeeting.EndDateTime = DateTime.Parse(fileLineArray[3]);
                returnList.Add(newMeeting);
            }
            return returnList;
        }
    }
}



