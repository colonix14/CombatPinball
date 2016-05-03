using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
	
	public Image image;
	public Text text;
	public Animator anim;
	protected Sprite[] Allfaces;
	protected TextAsset[] Alltexts;
	protected string[] AllDialogsLines;

	List<int> ImageList = new List<int>();
	List<int> TextList = new List<int>();

	bool isWriting = false;

	void Start(){
		Allfaces = Resources.LoadAll<Sprite>("Faces");
		Alltexts = Resources.LoadAll<TextAsset>("Dialog");
		AllDialogsLines = Alltexts[0].text.Split("\n"[0]);
		SetDialog (0, 0);
		SetDialog (1, 1);
		SetDialog (0, 0);
		SetDialog (1, 1);
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
		ImageList.Add (imageNumber);
		TextList.Add (textNumber);
		StartCoroutine (AnimateDialog ());
	}

	protected void HideDialog(){
		anim.SetBool ("isActive", false);
		//text.text = "";
		isWriting = false;
	}

	IEnumerator AnimateDialog(){
		string str;
		while (isWriting) {
			yield return new WaitForSeconds(0.01F);
		}
		isWriting = true;
		string strComplete = AllDialogsLines[TextList[0]];
		image.sprite = Allfaces [ImageList[0]];
		int i = 0;
		str = "";
		while( i < strComplete.Length ){
			str += strComplete[i++];
			text.text = str;
			yield return new WaitForSeconds(0.1F);
		}
		isWriting = false;
		ImageList.RemoveAt (0);
		TextList.RemoveAt (0);
		yield return new WaitForSeconds(0.5F);
		if (ImageList.Count<1) {
			HideDialog ();
		}
	}
}