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
	private int Age {get; set;}
}
