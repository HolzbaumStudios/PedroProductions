using UnityEngine;
using System.Collections;

public class CreateUser : MonoBehaviour {

	public string URL = "http://blancos.ch/UnityTests/create.php?";

	void Start()
	{
		StartCoroutine(CreateUserFunction());
	}

	public IEnumerator CreateUserFunction()
	{
		string username = "Concentrao";
		string password = "password";
		string password2 = "password";

		string postUrl = URL + "username=" + username + "&password=" + password + "&password2=" + password2;
		// Post the URL to the site and create a download object to get the result.
		WWW hsPost = new WWW(postUrl);
		yield return hsPost; // Wait until the download is done

		if(hsPost.error != null)
		{
			print (postUrl);
			print("There was an error creating this stuff!");
		}
	
	}
}
