using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {      //jakieś gówno, nobody cares

	//Wszystko co ma public, to wyglada tak, że potem w Unity pojawiają się takie prostokąciki które się wypełnia właśnie, np. inty, albo wypełnia przeciągając do nich obiekty z mapki
	// np. do AudioSource biore po prostu chamsko obiekt z mapki (ten który mi odpala dźwięki) i przeciągam go na kwadracik xd

	public int pointsToAdd;        //Public to znaczy, że ja se moge w Unity w każdej chwili ustawic te wartosc, nie musze przypisywac jej tu, a private nie widac w Unity 

	public AudioSource coinSoundEffect;     // No chyba kurwa wiadomo o co chodzi xD
	public CoinPitch coinPitch;            // Sam se napisałem skrypt i on ma klase CoinPitch i jest gdzieś taki obiekt na mapce, a do tej zmiennej go przypisze
	private bool pitchControl;             //chuj wie co to jest nie pamiętam
	private float pitchEndTime =1;         //to tez nie pamietam xd

	void Start ()    //Start wykonuje sie przy starcie mapki RAZ, jest jeszcze Update() i to sie wykonuje raz na klatkę
	{
		coinPitch = FindObjectOfType<CoinPitch> ();  //Znajduje na mapce obiekt który ma w sobie mojego skrypta CoinPitch i wpierdala go do tej zmiennej(uchwytu).
													//CoinPitch to byl taki mój skrypcik, żeby każda kolejna monetka podnosiła ton dźwięku przy zbieraniu jeżeli od poprzedniej monetki nie minelo 3s.
	}

	void OnTriggerEnter2D (Collider2D other)   //To sie wykonuje jak coś wykona kolizję z obiektem do którego ten skrypt w którym właśnie jesteśmy jest wpierdolony. 
												// Collider2D to jest taka kurwa "struktura" innymi słowy inny "skrypt" który sie na obiekty wpierdala. Wyglada to tak, że po prostu
												// obrysowujesz se sprajta i to jest jego collider, czyli takie gówno które wykrywa kolizję
	{
		if (other.GetComponent<PlayerController> () == null)      //jeżeli to coś co sie wjebalo w collider nie ma w sobie skryptu PlayerController to znaczy, że nie jest playerem, wiec
																//nie powinno zebrać monetki i niech wypierdala
			return;

		ScoreManager.AddPoints (pointsToAdd);                //Weź obiekt z mapki który sie nazywa ScoreManager (ja pisałem xd) i wywołaj na nim funkcje Addpoints (ja pisałem xd)
															////funkcja po prostu dodaje punkty, jej argumentem jest ilość punktów które ma dodać, a to ustaliliśmy już wcześniej, że se to wpiszemy
		coinPitch.took = true;                           //jakiś tam bool coinPitcha ma być true, nie pamietam kurwa
		coinPitch.managingPitch ();                      // wywołaj jakąś tam funkcje coinpitcha
		coinSoundEffect.Play ();                           //wywołaj funkcje Play() dla audiosource'a (nie ja pisałem, dla audiosourców są funkcje z Unity, ale one ograniczają się do Play i stop kurwa xd
		Destroy (gameObject);                            //rozpierdol ten obiekt w którym znajduje się ten skrypt w którym jesteśmy
	}




}
