using System;
using System.Windows.Desktop;
using System.IO;
using System.Windows.Media;

namespace VoteNow
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Notification notification = new System.Windows.Desktop.Notification();
			notification.HeaderText = "Self-Host Vote";
			notification.BodyText = "You have been using this Longhorn build for a few hours now.  By using the Vote Now button below, you can vote to let us know what you think of it.  To learn more, click this text.";

			notification.IsBodyClickable = true;
			NotificationButton notificationButton = new NotificationButton();
			notificationButton.Text = "Vote Now";
			notification.AddButton(notificationButton);

			NotificationButton notificationButton1 = new NotificationButton();
			notificationButton1.Text = "Later";
			notification.AddButton(notificationButton1);

			// Image
			try 
			{
				FileStream fs = File.Open("ThumbsUp.png", FileMode.Open, FileAccess.Read, FileShare.None);
				ImageData imageData = new ImageData(fs);
				notification.HeaderIcon = imageData;
			} 
			catch (Exception e) { Console.WriteLine(e); }

			notification.Send();
		}
	}
}
