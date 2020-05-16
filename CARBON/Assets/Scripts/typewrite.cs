using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class typewrite : MonoBehaviour
{
    public float delay = 0.1f;
	public string fullText;
	private string currentText = "";
	public AudioClip blip;
	GameObject objToSpawn;

	// Use this for initialization
	void Start () {
		StartCoroutine(ShowText());
	}
	
	IEnumerator ShowText(){
		for(int i = 0; i <= fullText.Length; i++){
			currentText = fullText.Substring(0,i);
			this.GetComponent<Text>().text = currentText;
			if (i % 3 == 0)
			{
				objToSpawn = new GameObject("sound producer");
				AudioSource audioSource = objToSpawn.AddComponent<AudioSource>();
				//objToSpawn.GetComponent<AudioSource>();
				audioSource.clip = blip;
				audioSource.volume = 0.25f;
				audioSource.Play();
				Destroy(objToSpawn, 0.5f);
			}
			yield return new WaitForSeconds(delay);
		}
	}
}
