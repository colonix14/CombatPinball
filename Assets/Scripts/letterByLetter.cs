using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class letterByLetter : MonoBehaviour {
	
	private string str;
	public Text text;
	public Animator anim;

	bool isWriting = false;

	void Start(){
		text.gameObject.SetActive(false);
		anim.SetBool ("isActive", false);
	}


	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			anim.SetBool ("isActive", true);
			if (!isWriting) {
				StartCoroutine( AnimateText("Pretty cool text") );	
			}
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			anim.SetBool ("isActive", false);
			text.gameObject.SetActive(false);
		}
	}


	IEnumerator AnimateText(string strComplete){
		isWriting = true;
		text.gameObject.SetActive(true);
		int i = 0;
		str = "";
		while( i < strComplete.Length ){
			str += strComplete[i++];
			text.text = str;
			yield return new WaitForSeconds(0.1F);
		}
		isWriting = false;
	}
}
