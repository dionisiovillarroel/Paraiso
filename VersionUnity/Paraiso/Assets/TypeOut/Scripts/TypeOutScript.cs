using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Text;


[Serializable]
public class TypeOutScript : MonoBehaviour {

    private AudioSource typingSound;
    private Text text;
	public bool On = true;
	public bool reset = false;
    [TextArea]
    public string FinalText;
	
    [Range(0,100)]
	public float TotalTypeTime = -1f;

	public float TypeRate;
	private float LastTime;

    public int i;

    private void Awake()
    {
        text = GetComponent<Text>();
        typingSound = GetComponent<AudioSource>();
    }
    //	void Start () 
    //	{
    //		try
    //		{
    //			gameObject.AddComponent(typeof(GUIText));
    //		}
    //		catch(UnityException)
    //		{
    //
    //		}
    //
    //	}

    public void StartTyping()
    {
        StartCoroutine(TypeText());
    }

	public void Skip()
	{
        text.text = FinalText;
		On = false;
	}

    // Update is called once per frame
    private void Update()
    {
        if (On)
        {
            StartTyping();
            On = false;
        }
    }
    private IEnumerator TypeText() 
	{
		if (TotalTypeTime != -1f)
		{
			TypeRate = TotalTypeTime/(float)FinalText.Length;
		}

        while (text.text.Length < FinalText.Length)
        {
            yield return new WaitForSeconds(TypeRate);
            i++;
            /*bool isChar = false;
            while (!isChar)
		    {
			    if ((i + 1) < FinalText.Length)
			    {
				    if (FinalText.Substring(i,1) == " ")
				    {
					    i++;
				    }
				    else
				    {
					    isChar = true;
				    }
			    }
			    else
			    {
				    isChar = true;
			    }
		    }*/

            if ((i + 1) < FinalText.Length && FinalText.Substring(i, 1) != " ")
            {
                typingSound.Play();
            }

            try
            {
                text.text = FinalText.Substring(0, i);
            }
            catch (ArgumentOutOfRangeException)
            {
                StopAllCoroutines();
            }
		}
	}
}
