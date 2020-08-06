using class04.workshop.trybeingfit.Services.Helpers;
using class04.workshop.trybeingfit.Services.Services;
using System;
using System.Linq;
using workshop.TryBeingFit.Domain.Enteties;
using workshop.TryBeingFit.Domain.Enums;

namespace workshop.csharpadvance.class04
{
	class Program
	{

		public static IUIService _uiService = new UIService();
		public static IUserService<StandarUser> _standardUserSrvc = new UserService<StandarUser>();
		public static IUserService<PremiumUser> _premiumUserSrvc = new UserService<PremiumUser>();
		public static IUserService<TrainerUser> _trainerUserSrvc = new UserService<TrainerUser>();
		public static ITrainingService<VideoTraining> _videoTrainings = new TrainingService<VideoTraining>();
		public static ITrainingService<LiveTraining> _liveTrainings = new TrainingService<LiveTraining>();
		public static User _currentUser;

		public static void Seed()
		{
			_standardUserSrvc.Register(new StandarUser() { FirstName = "Bob", LastName = "Bobsky", UserName = "bobob1", Password = "bobbest1" });
			_premiumUserSrvc.Register(new PremiumUser() { FirstName = "Jill", LastName = "Wayne", UserName = "jilllw", Password = "jillsuper26" });
			TrainerUser John = new TrainerUser() { FirstName = "John", LastName = "Johnsky", UserName = "johnjj", Password = "johny55", YearsExperience = 7 };
			_trainerUserSrvc.Register(John);
			_videoTrainings.AddTraining(new VideoTraining() { Title = "30 min workout", Description = "Cool workout for beginners and intermediate users", Difficulty = Difficulty.Medium, Link = "https://www.youtube.com/watch?v=50kH47ZztHs", Rating = 4, Time = 35 });
			_videoTrainings.AddTraining(new VideoTraining() { Title = "Standing ABS workout", Description = "Abs workout for people at home with standing and no equipment required", Difficulty = Difficulty.Easy, Link = "https://www.youtube.com/watch?v=Qia2ZXEzyLw", Rating = 5, Time = 11 });
			_videoTrainings.AddTraining(new VideoTraining() { Title = "Full AGILITY Bodyweight", Description = "An intense workout for people that have experience working out and need a good AGILITY training", Difficulty = Difficulty.Hard, Link = "https://www.youtube.com/watch?v=tveIjnSG_8s", Rating = 2, Time = 67 });
			_liveTrainings.AddTraining(new LiveTraining() { Title = "Workout with John", Description = "Working out can be easy when you are at home. Trust John, he is a professional!", Difficulty = Difficulty.Medium, NextSession = new DateTime(2020, 07, 20), Trainer = John, Rating = 2, Time = 25 });
			_liveTrainings.AddTraining(new LiveTraining() { Title = "Quick abs with John", Description = "You want abs for the summer? You want them quick? This is the training for you!", Difficulty = Difficulty.Hard, NextSession = new DateTime(2020, 07, 24), Trainer = John, Rating = 4, Time = 40 });
		}
		static void Main(string[] args)
		{
			Seed();
			while (true)
			{
				Console.Clear();
				int loginChoice = _uiService.LogInMenu();
				Console.Clear();
				if (loginChoice == 1)
				{
					int roleChoice = _uiService.RoleMenu();
					UserRole role = (UserRole)roleChoice;
					Console.Clear();
					Console.WriteLine("Enter username:");
					string username = Console.ReadLine();
					Console.WriteLine("Enter password:");
					string password = Console.ReadLine();
					switch (role)
					{
						case UserRole.Standard:
							_currentUser = _standardUserSrvc.LogIn(username, password);
							break;
						case UserRole.Premium:
							_currentUser = _premiumUserSrvc.LogIn(username, password);
							break;
						case UserRole.Trainer:
							_currentUser = _trainerUserSrvc.LogIn(username, password);
							break;
					}

					if (_currentUser == null) continue;
					break;
				}
				else
				{
					StandarUser newUser = new StandarUser();
					Console.WriteLine("Enter first name:");
					newUser.FirstName = Console.ReadLine();
					Console.WriteLine("Enter last name:");
					newUser.LastName = Console.ReadLine();
					Console.WriteLine("Enter username:");
					newUser.UserName = Console.ReadLine();
					Console.WriteLine("Enter password:");
					newUser.Password = Console.ReadLine();
					_currentUser = _standardUserSrvc.Register(newUser);
					if (_currentUser == null)
					{
						continue;
					}

					break;
				}
			}
			Console.Clear();
			_uiService.Welcome(_currentUser);
			int mainMenuChoice = _uiService.MainMenu(_currentUser.Role);
			string mainMenuItem = _uiService.MainMenuItems[mainMenuChoice - 1];
			switch (mainMenuItem)
			{
				case MenuItemsConstants.Train:
					int trainChoice = 1;
					if (_currentUser.Role == UserRole.Premium)
					{
						trainChoice = _uiService.TrainMenu();
					}
					if (trainChoice == 1)
					{
						int trainingItem = _uiService.TrainMenuItems(_videoTrainings.GetTrainings());
						VideoTraining training = _videoTrainings.GetTrainings()[trainingItem - 1];
						Console.WriteLine(training.Title);
						Console.WriteLine($"Link: {training.Link}");
						Console.WriteLine($"Rating: {training.CheckRating()}");
						Console.WriteLine($"Time: {training.Time} minutes");
						Console.ReadLine();
					}
					if (trainChoice == 2)
					{
						int trainingItem = _uiService.TrainMenuItems(_liveTrainings.GetTrainings());
						LiveTraining training = _liveTrainings.GetTrainings()[trainingItem - 1];
						Console.WriteLine(training.Title);
						Console.WriteLine($"THE TRAINING STARTS AT: {training.NextSession}");
						Console.WriteLine($"Rating: {training}");
						Console.WriteLine($"Time: {training} minutes");
					}
					break;
				case MenuItemsConstants.UpgradeToPremium:
					_uiService.UpgradeToPremium();
					break;
				case MenuItemsConstants.RescheduelTraining:
					var trainings = _liveTrainings
						.GetTrainings()
						.Where(x => x.Trainer.Id == _currentUser.Id)
						.ToList();
					if (trainings.Count == 0)
					{
						Console.WriteLine("No Trainings!");
						Console.ReadLine();
					}
					else
					{
						int trainingChoice = _uiService.ChooseEntiiesMenu(trainings);
						Console.WriteLine("How many days do you want to reschedule the training: ");
						int days = ValidationHelper.ValidateNumber(Console.ReadLine(), 100);
						_trainerUserSrvc.GetById(_currentUser.Id)
							.ChangeSchedule(trainings[trainingChoice - 1], days);
						Console.WriteLine("Schedule changed!");
						Console.ReadLine();
					}
					break;
				case MenuItemsConstants.Account:
					break;
				case MenuItemsConstants.LogOut:
					_currentUser = null;
					break;
				default:
					break;
			}
		}
	}

}

