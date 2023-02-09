using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FocusMe : MonoBehaviour
{
    //[SerializeField] private FocusSwitcher focus;
    GameObject FocusCamera;
    FocusSwitcher FocusSwitcher;

    public GameObject Drill;
    public GameObject Bolt;
    public GameObject Screwdriver_Cross;

    AudioSource Drill_audio;
    AudioSource Bolt_audio;
    AudioSource Screwdriver_audio;


    int object_num = 0;
    void Start()
    {
        
        FocusCamera = GameObject.Find("FocusCamera");
        
        FocusSwitcher = FocusCamera.GetComponent<FocusSwitcher>();
        //FocusCamera.SetActive(false);
        Drill = GameObject.Find("Body");
        Bolt = GameObject.Find("Bolt");
        Screwdriver_Cross = GameObject.Find("Screwdriver_Cross");
        
        Drill_audio = Drill.GetComponent<AudioSource>();
        Bolt_audio = Bolt.GetComponent<AudioSource>();
        Screwdriver_audio = Screwdriver_Cross.GetComponent<AudioSource>();

        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        while(true)
        {
            
            object_num++;
            if(object_num==4)
            {
                object_num=1;
            }
            if (object_num ==1)
            {
                FocusSwitcher.SetFocused(Bolt);
                Bolt_audio.Play();
            }
            else if (object_num ==2)
            {
                FocusSwitcher.SetFocused(Drill);
                Drill_audio.Play();
            }
            else if (object_num ==3)
            {
                FocusSwitcher.SetFocused(Screwdriver_Cross);
                Screwdriver_audio.Play();
            }
            //Debug.Log(object_num);
            yield return new WaitForSeconds(3);

        }
    }

    /*
    private void OnMouseEnter()
    {
        
        Debug.Log(gameObject);
        FocusSwitcher.SetFocused(gameObject);
        
    }

    private void OnMouseExit()
    {
        // reset the focus
        // in the future you should maybe check first
        // if this object is actually the focused one currently
        FocusSwitcher.SetFocused(null);
    }
    */
}