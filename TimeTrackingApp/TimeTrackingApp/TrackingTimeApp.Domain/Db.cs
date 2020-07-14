using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;
using TrackingTimeApp.Domain.Interfaces;

namespace TrackingTimeApp.Domain
{
	public class Db<T>:IDb<T> where T:User
	{
/*		private List<T> _db
*/


	/*	public Db()
		{
			_db = new List<T>();
			IdCounter = 1;
		}*/

	/*	public List<T> GetAll()
		{
			return _db;
		}*/

	/*	public T GetUserbyId(int id)
		{

			return _db.FirstOrDefault(x => x.Id == id);
		}*/

/*		public int Insert (T entity)
		{
			entity.Id = IdCounter;
			_db.Add(entity);
			IdCounter++;
			return entity.Id;
		}
*/
		public void UpdateUSer (T entity)
		{
            List<T> data = Read();
            T dbEntity = data.FirstOrDefault(x => x.Id == entity.Id);
        }
	

        private readonly string _dbDirectory;
        private readonly string _dbFile;

        // fields that we need to change
        private int _idTracker = 0;

        public Db()
        {
            _dbDirectory = $@"..\..\..\Db\";
            _dbFile = $"{_dbDirectory}{typeof(T).Name}s.json";
            // _dbFile = $"{_dbDirectory}{nameof(T)}s.json";

            if (!Directory.Exists(_dbDirectory))
            {
                Directory.CreateDirectory(_dbDirectory);
            }
            if (!File.Exists(_dbFile))
            {
                File.Create(_dbFile).Close();
            }

            // set id to last record
            List<T> data = Read();
            if (data == null)
            {
                Write(new List<T>());
            }
            else if (data.Count > 0)
            {
                _idTracker = data[data.Count - 1].Id;
            }
        }

        public Db(DbOptions dbOptions)
        {
            _dbDirectory = dbOptions.FileDirectory;
            //_dbFile = $"{typeof(T).Name}s.json";
            _dbFile = $"{_dbDirectory}{dbOptions.FileName}s.json";

            if (!Directory.Exists(_dbDirectory))
            {
                Directory.CreateDirectory(_dbDirectory);
            }
            if (!File.Exists(_dbFile))
            {
                File.Create(_dbFile).Close();
            }

            // set id to last record
            List<T> data = Read();
            if (data == null)
            {
                Write(new List<T>());
            }
            else if (data.Count > 0)
            {
                _idTracker = data[data.Count - 1].Id;
            }
        }

        #region Read/Write
        private List<T> Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_dbFile))
                {
                    string content = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<T>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private bool Write(List<T> entities)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_dbFile))
                {
                    string content = JsonConvert.SerializeObject(entities);
                    sw.Write(content);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        public List<T> GetAll()
        {
            return Read();
        }

        public T GetById(int id)
        {
            List<T> data = Read();
            return data.FirstOrDefault(x => x.Id == id);

            // return Read().FirstOrDefault(x => x.Id == id);
        }

        public int Insert(T entity)
        {
            List<T> data = Read();
            _idTracker++;
            entity.Id = _idTracker;
            data.Add(entity);
            Write(data);
            return entity.Id;
        }

     /*   public void Update(T entity)
        {
            T dbEntity = Read().FirstOrDefault(x => x.Id == entity.Id);

        }*/

        public void Delete(int id)
        {
            List<T> data = Read();
            T dbEntity = data.FirstOrDefault(x => x.Id == id);
            data.RemoveAll(x => x.Id == dbEntity.Id);
            Write(data);
        }

        public void ClearDb()
        {
            Write(new List<T>());
        }
    }


}
	
