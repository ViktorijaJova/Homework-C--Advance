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
    public int IdCount { get; set; }
    private readonly string _dbDirectory;
    private readonly string _dbFile;

    public Db()
    {
    IdCount = 0;
    _dbDirectory = $@"..\..\..\Db\";
    _dbFile = $"{_dbDirectory}{typeof(T).Name}s.json";
    if (!Directory.Exists(_dbDirectory))
    {
    Directory.CreateDirectory(_dbDirectory);
    }
    if (!File.Exists(_dbFile))
    {
    File.Create(_dbFile).Close();
    }

    List<T> _db = Read();
    if (_db == null)
    {
    Write(new List<T>());
    }
    else if (_db.Count > 0)
    {
    IdCount = _db[_db.Count - 1].Id;
    }
    }

    public Db(DbOptions dbOptions)
    {
    _dbDirectory = dbOptions.FileDirectory;
    _dbFile = $"{_dbDirectory}{dbOptions.FileName}s.json";
    if (!Directory.Exists(_dbDirectory))
    {
    Directory.CreateDirectory(_dbDirectory);
    }
    if (!File.Exists(_dbFile))
    {
    File.Create(_dbFile).Close();
    }
    List<T> _db = Read();
    if (_db== null)
    {
    Write(new List<T>());
    }
    else if (_db.Count > 0)
    {
    IdCount = _db
    [_db.Count - 1].Id;
    }
    }

    public void UpdateUser(T entity)
    {
    var list = Read();
    T item = list.FirstOrDefault(x => x.Id == entity.Id);
    item.Age = entity.Age;
    item.Activities = entity.Activities;
    item.FavoriteTypeBook = entity.FavoriteTypeBook;
    item.FavoriteTypePuzzle = entity.FavoriteTypePuzzle;
    item.FavoriteTypToWatch = entity.FavoriteTypToWatch;
    item.FirstName = entity.FirstName;
    item.LastName = entity.LastName;
    item.Password = entity.Password;
    item.TotalHoursOtherHobbies = entity.TotalHoursOtherHobbies;
    item.TotalHoursPuzzles = entity.TotalHoursPuzzles;
    item.TotalHoursReading = entity.TotalHoursReading;
    item.TotalHoursWatching = entity.TotalHoursWatching;
    item.Username = entity.Username;
    item.Id = entity.Id;
    Write(list);
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

    public List<T> GetAllNewWay()
    {
    return Read();
    }

    public T GetById(int id)
    {
    List<T> data = Read();
    return data.FirstOrDefault(x => x.Id == id);
    }

    public int InsertNewWay(T entity)
    {
    List<T> data = Read();
    IdCount++;
    entity.Id = IdCount;
    data.Add(entity);
    Write(data);
    return entity.Id;
    }
    public T GetUserById(int id)
    {
    return Read().FirstOrDefault(user => user.Id == id);
    }

    }


}
	
