using System;
using System.Collections.Generic;
using System.IO;

namespace MeetingApp
{
    public class Contact
    {
        private string firstname;
        private string lastname;
        private string phonenumber;
        private string email;

        public string FirstName
        {
            get
            {
                return this.firstname;
            }
            set
            {
                this.firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastname;
            }
            set
            {
                this.lastname = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phonenumber;
            }
            set
            {
                this.phonenumber = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public Contact() { }
    }

    public class Meeting
    {
        private string title;
        private string location;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private Contact meetingcontact;

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
        public Contact MeetingContact
        {
            get
            {
                return this.meetingcontact;
            }
            set
            {
                this.meetingcontact = value;
            }
        }

        public Meeting() { }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = "";
            List<Meeting> listOfMeetings = new List<Meeting>();
            List<Contact> listOfContacts = new List<Contact>();
            bool userMenu = true;
            bool welcomeMenu = true;

            while (true)
            {
                try
                {
                    while (welcomeMenu)
                    {
                        int welcomeSelection = WelcomeMenu();
                        Console.WriteLine("\n");

                        switch (welcomeSelection)
                        {
                            case 1:
                                Console.WriteLine("Input file path: ");
                                fileLocation = Console.ReadLine();
                                listOfMeetings = LoadCalendar(fileLocation);
                                Console.WriteLine("Calendar Loaded!\n");
                                welcomeMenu = false;
                                break;
                            case 2:
                                while (welcomeMenu)
                                {
                                    Console.Write("Where would you like to store the file? (type exit to return) ");
                                    fileLocation = Console.ReadLine();
                                    if (fileLocation == "exit")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("What would you like to name the file?");
                                        fileLocation = fileLocation + Console.ReadLine() + ".dat";
                                        welcomeMenu = CreateFile(fileLocation);
                                        break;
                                    }
                                }
                                break;
                            case 0:
                                Environment.Exit(1);
                                break;
                            default:
                                Console.WriteLine("Invalid Input\n");
                                break;
                        }
                    }

                    while (userMenu)
                    {
                        int userChoice = UserMenu();
                        Console.WriteLine("\n");

                        switch (userChoice)
                        {
                            case 1:
                                AddMeeting(listOfMeetings, listOfContacts);
                                break;
                            case 2:
                                listOfMeetings = RemoveMeeting(listOfMeetings);
                                break;
                            case 3:
                                ViewCalendar(listOfMeetings);
                                break;
                            case 4:
                                AddContact(listOfContacts);
                                break;
                            case 0:
                                welcomeMenu = true;
                                userMenu = false;
                                break;
                            default:
                                Console.WriteLine("\nInvalid Input Try Again1\n");
                                break;
                        }
                    }

                    SaveFile(fileLocation, listOfMeetings);
                    fileLocation = "";
                    welcomeMenu = true;
                    userMenu = true;

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nFormat Exception: Invalid Entry\n");
                    welcomeMenu = false;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("\nFile Not Found \n");
                    welcomeMenu = true;
                }
                catch (IOException)
                {
                    Console.WriteLine("\nIO Exception\n");
                    fileLocation = "";
                    welcomeMenu = true;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access to file path denied");
                }
            }
        }

        static Meeting AddMeeting(List<Meeting> inputList, List<Contact> contactList)
        {
            var newMeeting = new Meeting();
            var removedMeeting = new Meeting();
            var meetingContact = new Contact();

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
                            removedMeeting = existingMeeting;
                            break;
                        case "NO":
                        case "No":
                        case "no":
                        case "N":
                        case "n":
                            return null;
                        default:
                            Console.WriteLine("\nInput not recognized. Returning to Menu \n");
                            return null;

                    }
                }
            }
            inputList.Remove(removedMeeting);
            Console.WriteLine("\nMeeting Added!\n");
            Console.WriteLine("Would you like to add a contact to this meeting? (Y/N)");
            string ifContact = Console.ReadLine();

            if ((ifContact == "Y") || (ifContact == "y"))
            {
                Console.WriteLine("Below are your contacts:");
                foreach (Contact person in contactList)
                {
                    Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
                }
                Console.WriteLine("Would you like to select an existing contact? (Y/N)");
                string ifExisting = Console.ReadLine();
                if ((ifExisting == "Y") || (ifExisting == "y"))
                {
                    Console.WriteLine("Please input the First and Last Name of the contact you want to add");
                    string userContact = Console.ReadLine();
                    foreach (Contact person in contactList)
                    {
                        if (userContact == person.FirstName + " " + person.LastName)
                        {
                            newMeeting.MeetingContact = person;
                            inputList.Add(newMeeting);
                            Console.WriteLine("{0} {1} was added to {}", person.FirstName, person.LastName, newMeeting.Title);
                            return null;
                        }
                    }

                }
                else
                {
                    newMeeting.MeetingContact = AddContact(contactList);
                    inputList.Add(newMeeting);
                    return null;

                }
            }

            inputList.Add(newMeeting);
            return null;
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
        static void ViewCalendar(List<Meeting> inputList)
        {
            Console.Write("What day would you like to view? (MM/DD/YY) ");
            DateTime calendarDay = DateTime.Parse(Console.ReadLine());
            DateTime start = calendarDay.AddHours(8);
            DateTime end = calendarDay.AddHours(17);
            while (start < end)
            {
                string meetingTitle = "";
                string meetingContact = "";

                foreach (Meeting meeting in inputList)
                {
                    if ((start >= meeting.StartDateTime) & (start <= meeting.EndDateTime))
                    {
                        meetingTitle = meeting.Title;
                        meetingContact = meeting.MeetingContact.FirstName + " " + meeting.MeetingContact.LastName;
                    }
                }
                if ((meetingTitle != "") & (meetingContact != ""))
                {
                    Console.WriteLine("{0} | {1} with {2}", start.ToString("MM/dd/yy HH:mm"), meetingTitle, meetingContact);
                }
                else if((meetingTitle != ""))
                {
                    Console.WriteLine("{0} | {1} {2}", start.ToString("MM/dd/yy HH:mm"), meetingTitle);
                }
                else
                {
                    Console.WriteLine("{0} |", start.ToString("MM/dd/yy HH:mm"));
                }

                start = start.AddMinutes(30);
            };

            Console.WriteLine("\n");
        }
        static Contact AddContact(List<Contact> inputContacts)
        {
            var newContact = new Contact();

            Console.WriteLine("Input the following information\nFirst Name:");
            newContact.FirstName = Console.ReadLine();

            Console.WriteLine("Last Name: ");
            newContact.LastName = Console.ReadLine();

            Console.WriteLine("Phone Number:");
            newContact.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Email:");
            newContact.Email = Console.ReadLine();

            inputContacts.Add(newContact);

            Console.WriteLine("Contact Added");
            return newContact;

        }
        static int WelcomeMenu()
        {
            Console.WriteLine("Welcome to the Meeting App!\n");
            Console.WriteLine("What would you like to do?\n1. Load calendar from file\n" +
                    "2. Create new calendar\n0. Exit\n");
            return int.Parse(Console.ReadLine());
        }
        static bool CreateFile(string fileLocation)
        {
            File.Create(fileLocation);
            if (!File.Exists(@fileLocation))
            {
                Console.WriteLine("File Location not valid try again");
                return true;
            }
            else
            {
                Console.WriteLine("\nNew file Created!\n");
                return false;
            }
        }
        static int UserMenu()
        {
            Console.WriteLine("What would you like to do?\n\n1. Add meeting to calendar\n" +
                                 "2. Remove meeting from calendar\n3. View schedule\n4. Add A Contact\n0. Go Back\n");
            return int.Parse(Console.ReadLine());
        }
        static void SaveFile(string fileLocation, List<Meeting> inputList)
        {
            string fileString = "";
            Console.Write("Do you want to save? Type Y to save: ");
            string save = Console.ReadLine();
            if ((save == "Y") || (save == "y"))
            {
                foreach (Meeting myMeetings in inputList)
                {
                    fileString += myMeetings.Title + "," + myMeetings.Location + "," + myMeetings.StartDateTime
                         + "," + myMeetings.EndDateTime + "\n";
                }
                File.WriteAllText(@fileLocation, fileString);
            }
            else
            {
                Console.WriteLine("File not saved!\n");
            }
        }

    }
}




