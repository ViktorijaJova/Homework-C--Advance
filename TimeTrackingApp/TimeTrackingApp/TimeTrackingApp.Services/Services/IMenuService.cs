using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Interfaces;

namespace TimeTrackingApp.Services.Services
{
     public interface IMenuService
    {
		void Welcome(User user);
		int MainMenu();
		int LogInMenu();
		public int ShowWatchingTypes();

		public int ActivityMenu();

		public int ShowPuzzlesTypes();

		public int ShowReadingTypes();




	}
}
