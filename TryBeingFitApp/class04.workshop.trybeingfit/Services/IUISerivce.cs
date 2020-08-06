using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enteties;
using workshop.TryBeingFit.Domain.Enums;
using workshop.TryBeingFit.Domain.Interfaces;

namespace class04.workshop.trybeingfit.Services.Services
{
	public interface IUIService
	{
		List<string> MainMenuItems { get; set; }
		void Welcome(User user);
		int ChooseEntiiesMenu<T>(List<T> entities) where T : IBaseEntity;
		int MainMenu(UserRole role);
		int ChooseMenu<T>(List<T> items);
		int LogInMenu();
		int RoleMenu();
		int TrainMenu();
		int TrainMenuItems<T>(List<T> trainings) where T : Training;
		void UpgradeToPremium();
	}
}
