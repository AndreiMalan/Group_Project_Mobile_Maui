namespace Proiect_Mobile_Maui_Onetiu_Malan;
using System;
using Proiect_Mobile_Maui_Onetiu_Malan.Data;
using System.IO;

public partial class App : Application
{
    static VisitingListDatabase database;
    public static VisitingListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               VisitingListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "VisitingList.db3"));
            }
            return database;
        }
    }
    public App()
	{

		InitializeComponent();

		MainPage = new AppShell();
	}
}
