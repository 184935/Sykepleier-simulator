using System;

public class Bruker
{
	private string Username {get; set;}
	private string Password {get; set;}
	private bool IsTeacher {get; set;}
	public Bruker(string username, string password, bool isTeacher)
	{
		_Username = username;
		_Password = password;
		_IsTeacher = isTeacher;
	}
}

public class Pasient
{
	private string Navn {get; set;}
	private int Alder {get; set;}
	private string Kjonn {get; set;}
	private double Vekt {get; set;}
	
	public Pasient(string navn, int alder, string kjonn, double vekt)
	{
		_Navn = navn;
		_Alder = alder;
		_Kjonn = kjonn;
		_Vekt = vekt;
	}
}

public class Vitals
{
	private int OverTrykk {get; set;}
	private int UnderTrykk {get; set;}
	private int Puls { get; set;}
	private int Pusterytme {get; set;}

}
