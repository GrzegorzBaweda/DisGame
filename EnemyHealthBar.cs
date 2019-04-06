using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour {

	public bool hitted;
	public GameObject barPart;
	public GameObject[] barArr;
	public int barAmount;

	private float posx;
	private float posy;

	public float przesuniecieX;
	public float przesuniecieY;

	private bool created;
	private bool created2;
	public float bias;
	public GameObject place;



	//Skrypt ma wyświetlać malutki pasek HP nad przeciwnikiem. Nie od samego początku, natomiast dopiero wtedy gdy przeciwnik dostanie na pizdeczke. 
	//Problem mam taki, że pozycje tego paska HP dla każdego obiektu trzeba obliczać cały czas i mam takie jakieś przeczucie, że zrobiłem to chujowo xD
	//Natomiast podoba mi sie to, że w edytorze nie potrzebuje tworzyć jakichś nowych jebanych transformów i jebać się z obiektami, bo wszystko tworzy mi się samo
	//Aczkolwiek no kurwa, nie wiem czy to jest aby optymalne, rzuć okiem i powiedz co o tym sądzisz.



	void Start () {
		barAmount = this.GetComponent<EnemyHealthManager> ().enemyHealth; //barAmount pobiera ilosc HP przeciwnika
	}
	
	// Update is called once per frame
	void Update () {
		


		if (hitted == true) //jezeli przeciwnik zostanie trafiony, wszystko sie odpala, wczesniej nie widac paska jego HP, bool jest włączany przez zewnętrzny skrypt
		{
			
		


			posx = this.transform.position.x + przesuniecieX;   //ustalana jest na bieżąco pozycja w której ma być lewy kraniec paska HP, czyli mniejwięcej po północnozachodniej stronie przeciwnika
			posy = this.transform.position.y + przesuniecieY;

			if (!created) //jezeli nie zostal jeszcze stworzony pasek, wykonujemy tego ifa, jezeli zostal, wykonujemy elsa
			{
				if (!created2) {   //pomocniczy bool, tworzy gameObjecta RAZ
					place = new GameObject ();

				}
				created2 = true;


				place.transform.position = new Vector3 (posx, posy, place.transform.position.z);   //ten GameObject wskazuje nam pozycje pierwszego punktu HP miniona
				barArr = new GameObject[barAmount];    //tworzona jest tablica GameObjectów w której będą wszystkie punkty miniona, ilosc miejsc w tablicy okresla oczywiscie jego HP
				for (int i = 0; i < barAmount; i++ )   
				{
					barArr [i] =  Instantiate (barPart, place.transform.position, place.transform.rotation);  //tworzymy punkt w odpowiednim miejscu
					place.transform.position = new Vector3 (place.transform.position.x + bias, place.transform.position.y, place.transform.position.z); //przesuwamy miejsce kolejnego punktu troszke w prawo

				}


				created = true; //procedura tworzenia skonczona
			}

			else  //gdy juz stworzylismy
				
			{
				place.transform.position = new Vector3 (posx, posy, place.transform.position.z); //wciąż ustalamy pozycję względem przeciwnika
				for (int i = 0; i < barAmount; i++) 
				{
					if (barArr [i]) { //jezeli przeciwnik wgle jeszcze ma tyle hp
						barArr [i].transform.position = place.transform.position; //przesuwamy punkt HP w odpowiednie miejsce
						place.transform.position = new Vector3 (place.transform.position.x + bias, place.transform.position.y, place.transform.position.z); //przesuwamy miejsce troszke w prawo
					}
				}
			}
		}

	}


	public void giveDmg (int enemyHealth)  //funkcja wywoływana przez inny skrypt, wtedy kiedy minion dostanie na pizde
	{
		//if (created == true) {
		//	for (int i = 0; i < dmgToGive; i++) {
		//		GameObject tmp = barArr [barAmount - 1];
		//		if (tmp) {
		//			Destroy (tmp);
		//			barAmount--;
		//		} else 
		//		{
		//			return;
		//		}
		//	}
		//} else 
		//{
		//	return;
		//}
		if (created == true) { //jezeli wgle stworzylismy to HP
			while (barAmount > enemyHealth) { //jezeli pokazywane na ekranie HP miniona jest wieksze od rzeczywistego
				if (barArr [barAmount - 1]) { 
					Destroy (barArr [barAmount - 1]);  //usun widoczne na ekranie HP
					barAmount--;
					if (barAmount == 0) 
					{
						Destroy (place);
					}//zmniejsz wyznacznik widocznego HP
				} else {
					return;
				}
			}
		} else {
			return;
		}
	}

}
