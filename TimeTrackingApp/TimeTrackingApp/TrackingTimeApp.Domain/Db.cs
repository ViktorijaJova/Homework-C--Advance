using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;
using TrackingTimeApp.Domain.Interfaces;

namespace TrackingTimeApp.Domain
{
	public class Db<T> where T:User
	{
		private List<T> _db;

		public int IdCounter { get; set; }


		public Db()
		{
			_db = new List<T>();
			IdCounter = 1;
		}

		public List<T> GetAll()
		{
			return _db;
		}

		public T GetUserbyId(int id)
		{

			return _db.FirstOrDefault(x => x.Id == id);
		}

		public int Insert (T entity)
		{
			entity.Id = IdCounter;
			_db.Add(entity);
			IdCounter++;
			return entity.Id;
		}

		public void UpdateUSer (T entity)
		{
			T item = _db.FirstOrDefault(x => x.Id == entity.Id);
			item = entity;
		}
		public void RemoveUser(int id)
		{
			T item = _db.FirstOrDefault(x => x.Id == id);
			if(item != null)
			{
				_db.Remove(item);
			}


		}


		public List<BaseEntity> GetAllActivities(int id)
		{
			T user = _db.FirstOrDefault(x => x.Id == id);
			return user.Activities;
		}

		public BaseEntity GetActivity(ActivityType activity, int id)
		{
			T user = _db.FirstOrDefault(x => x.Id == id);
			var userActivity = user.Activities.FirstOrDefault(a => a.ActivityType == activity);
			return userActivity;
		}

	}
	}
