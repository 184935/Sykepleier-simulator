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
	private List<string> MHistory { get; set;}
	private List<string> SurgicalHistory { get; set;}
	private List<string> SocialHistory { get; set;}
	private List<string> FamHistory { get; set;}

	public MedicalHistory(List<string> history, List<string> surgicalHistory, List<string> socialHistory,
		List<string> famhistory)
	{
		_History = history;
		_SurgicalHistory = surgicalHistory;
		_SocialHistory = socialHistory;
		_FamHistory = famhistory;
	}
}

// Litt usikker på denne, fyre inn de fra doc, evt finne på noe selv? 
public class LabValues
{
	private double BloodSugar {  get; set; }
	private int Creatinine {  get; set; }
	private int Sodium { get; set; }
	private double Potassium { get; set; }
	
	public LabValues(double bloodsugar, int creatinine, int sodium,  double potassium)
	{
		_BloodSugar = bloodsugar;
		_Creatinine = creatinine;
		_Sodium = sodium;
		_Potassium = potassium;
	}

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
	private int CaseId { get; set;}
	private Patient Patient { get; set;}
	private Vitals Vitals { get; set;}
	private List<Medication> Medications { get; set;}
	private List<Allergy> Allergies { get; set;}
	private List<Diagnosis> Diagnoses { get; set;}
	private MedicalHistory MedicalHistory { get; set;}
	private bool Editable { get; set;}
	private List<User> TestUsers { get; set;}
	private Difficulty Difficulty { get; set;}

	public Case(Patient patient, Vitals vitals, List<Medication> meds, List<Allergy> allergies, 
		List<Diagnosis> diagnoses, MedicalHistory medHis, bool editable, List<User> testUsers, Difficulty diff)
	{
		_Patient = patient;
		_Vitals = vitals;
		_Medications = meds;
		_Allergies = allergies;
		_Diagnoses = diagnoses;
		_MedicalHistory = medHis;
		_Editable = editable;
		_TestUsers = testUsers;
		_Difficulty = diff;
	}



}
enum Difficulty
{
	Easy,
	Intermediate,
	Hard
}
