using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueOutput : MonoBehaviour {
	Text text;
	string line;
	string []words;
	private int letter=0;
	public static bool isTyping = false;
	private bool cancelTyping = false;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	void Update(){
		
	}
	// Update is called once per frame

	void SetDialogue(string input){
		text.text = input;
	}
	void SetDialogueScroll(string input){
		text.text = "";
		line = input;
		code (input);
	}

	///<summary>Sets the letter value to zero and text area to nothing and changes to the state.</summary>
	///<param name="s"> refers to the Text needed for that scene. </param>
	///<param name="state"> Gets the state that you are going to moving to.
	/// 
	//private void resetSentence (string s, States state)
	//{
	//	if (letter >= s.Length - 1) {
	//		this.letter = 0;
	//		text.text = null;
	//		myState = state;

	//	}
	//}

	/// <summary>
	/// Pressing the space key completes the line
	/// </summary>
	/// <param name="s">S. The text outputed</param>
	public void SkipScroll(){
		qucikSentence (line);
	}

	private void qucikSentence (string s)
	{   cancelTyping = true;
		if(s.Length >= letter ){
			text.text = "";
			string[] lines = s.Split ('|');
			foreach(string line in lines){
				print (line+" QS");
				text.text+=line;
			    text.text+="\n";
			}
			letter = s.Length;
		}
	}
	/// <summary>
	/// While text being outputted buttons cannot be pressed.
	/// </summary>
	/// <param name="s">S.The text outputed</param>
	private void code (string s)
	{

		if (!isTyping) {
			StartCoroutine (TextScroll (s));

		} else if (isTyping && !cancelTyping) {
			cancelTyping = true;

		}
	}


	/// <summary>
	/// Makes the text scroll.
	/// </summary>
	/// <returns>The scroll.</returns>
	/// <param name="lineOfText">Line of text being outputed.</param>
	private IEnumerator TextScroll (string lineOfText) {
		isTyping=true;
		cancelTyping = false;
		letter = 0;
		while(isTyping && !cancelTyping && (letter <= lineOfText.Length - 1)){
			print(lineOfText[letter]);
			if (lineOfText[letter].Equals ('|')) {
				text.text += "\n";
			} else {
				text.text += lineOfText [letter];
			}
			letter ++;

			yield return new WaitForSecondsRealtime (0.05F);
		}

		isTyping = false;

	}




}
