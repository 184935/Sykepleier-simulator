using System;

public class User
{
	private string Username {get; set;}
	private string Password {get; set;}
	private bool IsTeacher {get; set;}
	public User(string username, string password, bool isTeacher)
	{
		_Username = username;
		_Password = password;
		_IsTeacher = isTeacher;
	}
}

public class Patient
{
	private string Name {get; set;}
	private int Age {get; set;}
	private string Gender {get; set;}
	private double Weight {get; set;}
	
	public Patient(string name, int age, string gender, double weight)
	{
		_Name = name;
		_Age = age;
		_Gender = gender;
		_Weight = weight;
	}
}

public class Vitals
{
	private int OverPressure {get; set;}
	private int UnderPressure {get; set;}
	private int Puls { get; set;}
	private int RespiratoryRate {get; set;}
	private int OxygenSaturation {get; set;}
	private double Temperature {get; set;}

	public Vitals(int overPressure, int underPressure, int puls, int respiratoryRate,
		int oxygenSaturation, double temperature)
	{
		_OverPressure = overPressure;
		_UnderPressure = underPressure;
		_Puls = puls;
		_RespiratoryRate = respiratoryRate;
		_OxygenSaturation = oxygenSaturation;
		_Temperature = temperature;
	}

	public string BlodPressure()
	{
		return OverPressure + " / " + UnderPressure;
	}

}
public class Medication
{
	private string Name { get; set;}

}
