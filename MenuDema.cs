using UnityEngine;
using System.Collections;

public class MenuDema : MonoBehaviour {

	public string loc1;
	public string bossowski;
	public string loc2;
	public string loc3;
	public string loc4;
	public string loc5;
	public string loc6;
	public string bestia;
	public string cutsceneBoss2;
	public string boss2;
	
	//------------------------------------------------------
	
	public void Loc1()
	{
		Application.LoadLevel (loc1);
		
	}
	
	
	public void boss()
	{
		Application.LoadLevel (bossowski);
		
	}

	public void Loc2()
	{
		Application.LoadLevel (loc2);
		
	}

	public void Loc3()
	{
		Application.LoadLevel (loc3);
		
	}

	public void Loc1Poz2()
	{
		Application.LoadLevel (loc4);

	}

	public void Loc1Poz3()
	{
		Application.LoadLevel (loc5);

	}

	public void Loc2Poz1()
	{
		Application.LoadLevel (loc6);

	}
	public void QuitGame()
	{
		Application.Quit ();
	}

	public void Bestia()
	{
		Application.LoadLevel (bestia);
		
	}

	public void Boss2Cutscene()
	{
		Application.LoadLevel (cutsceneBoss2);

	}

	public void Boss2WithoutCutscene()
	{
		Application.LoadLevel (boss2);

	}
	
}

