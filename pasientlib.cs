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
public class MedicalHistory
{
	private List<string> History { get; set;}

	public MedicalHistory(List<string> history)
	{
		_History = history;
	}
}

// Litt usikker på denne, fyre inn de fra doc, evt finne på noe selv? 
public class LabValues
{

}

public class Diagnosis
{
	public string Name {get; set;}
	public string Description {get; set;}
	public string Treatment {get; set;}

	public Diagnosis(string name, string description, string treatment)
	{
		_Name = name;
		_Description = description;
		_Treatment = treatment;
	}
}
public class Medication
{
	private string Name { get; set;}
	private int Dose { get; set;}
	private string Route { get; set;}
	private string Frequency { get; set;}
	private string Notes { get; set;}

	public Medication(string name, int dose, string route,  string frequency,  string notes)
	{
		_Name = name;
		_Dose = dose;
		_Route = route;
		_Frequency = frequency;
		_Notes = notes;
	}

}
public class Allergy
{
	private string Allergen { get; set;}
	private string Reaction { get; set;}

	public Allergy(string allergen, string reaction)
	{
		_Allergen = allergen;
		_Reaction = reaction;
	}
}

public class Case
{
	private Patient Patient { get; set;}
	private Vitals Vitals { get; set;}
	private List<Medication> Medications { get; set;}
	private List<Allergy> Allergies { get; set;}
	private List<Diagnosis> Diagnoses { get; set;}
	private MedicalHistory MedicalHistory { get; set;}

}
