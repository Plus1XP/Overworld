using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite HalfFullHeart;
    public Sprite EmptyHeart;
    public FloatValue HeartContainers;

 	// Use this for initialization
	void Start ()
    {
        InitHearts();
	}
	
	public void InitHearts()
    {
        // Loops through heart containers and turns them on and full either at the beginning of the game or when a new heart is recieved.
        for (int i = 0; i < HeartContainers.InitialValue; i++)
        {
            Hearts[i].gameObject.SetActive(true);
            Hearts[i].sprite = FullHeart;
        }
    }
}
