using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
	public static void SavePlayer (Prologue progress)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/progress.dat";
		FileStream stream = new FileStream(path, FileMode.Create);

		ProgressData data = new ProgressData(progress);


		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static ProgressData LoadProgress()
	{
		string path = Application.persistentDataPath + "/progress.dat";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			ProgressData data = formatter.Deserialize(stream) as ProgressData;
			stream.Close();
			return data;
		} else
		{
			Debug.LogError("No save file found in" + path);
			return null;
		}
	}
   
}
