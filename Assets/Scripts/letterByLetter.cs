using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class letterByLetter : MonoBehaviour {
	
	public Image image;
	public Text text;
	public Animator anim;
	protected Sprite[] Allfaces;
	protected TextAsset[] Alltexts;
	protected string[] AllDialogsLines;

	bool isWriting = false;

	void Start(){
		Allfaces = Resources.LoadAll<Sprite>("Faces");
		Alltexts = Resources.LoadAll<TextAsset>("Dialog");
		AllDialogsLines = Alltexts[0].text.Split("\n"[0]);

		text.gameObject.SetActive(false);
		anim.SetBool ("isActive", false);
	}


	// Update is called once per frame
	void Update () {
		//TEST
		if(Input.GetKeyDown(KeyCode.UpArrow)){
				SetDialog (0,0);
		}
	}

	public void SetDialog(int imageNumber, int textNumber){
		anim.SetBool ("isActive", true);
		SetImage (imageNumber);
		SetText (textNumber);
	}

	protected void SetImage(int number){
		image.sprite = Allfaces[number];
	}

	protected void SetText(int number){
		StartCoroutine( AnimateText(AllDialogsLines[number]) );	
	}

	protected void HideDialog(){
		anim.SetBool ("isActive", false);
		text.text = "";
		isWriting = false;
	}

	IEnumerator AnimateText(string strComplete){
		string str;
		while (isWriting) {
			yield return new WaitForSeconds(0.01F);
		}
		isWriting = true;
		text.gameObject.SetActive(true);
		int i = 0;
		str = "";
		while( i < strComplete.Length ){
			str += strComplete[i++];
			text.text = str;
			yield return new WaitForSeconds(0.1F);
		}
		yield return new WaitForSeconds(1F);
		HideDialog ();

		// falta multiples msg.
	}
}
