using UnityEngine;
using System.Collections;

public class UberNerd : MonoBehaviour {


	// Use this for initialization
	void Start () {//makes this nerd uber
     transform.GetComponent<NerdsHealth>().setUberNerd(false);
	}
}
