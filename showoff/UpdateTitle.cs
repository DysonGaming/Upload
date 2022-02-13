using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UpdateTitle : MonoBehaviour
{

    Animator animatorButtonStart;
    Animator animatorButtonStats;
    Animator animatorButtonMultiplayer;
    Animator animatorButtonOptions;
    Animator animatorButtonQuit;

    public GameObject AnimatedObjectStart;
    public GameObject AnimatedObjectStats;
    public GameObject AnimatedObjectMultiplayer;
    public GameObject AnimatedObjectOptions;
    public GameObject AnimatedObjectQuit;

    string StartName;
    string StatsName;
    string MultiName;
    string OptionsName;
    string QuitName;

    //string test;
    //string takeMeOn;

    int returnAnim;

    RaycastResult selected;

    void Start() 
    {
        animatorButtonStart = AnimatedObjectStart.GetComponent<Animator>();
        animatorButtonStats = AnimatedObjectStats.GetComponent<Animator>();
        animatorButtonMultiplayer = AnimatedObjectMultiplayer.GetComponent<Animator>();
        animatorButtonOptions = AnimatedObjectOptions.GetComponent<Animator>();
        animatorButtonQuit = AnimatedObjectQuit.GetComponent<Animator>();

        StartName = AnimatedObjectStart.transform.name;
        StatsName = AnimatedObjectStats.transform.name;
        MultiName = AnimatedObjectMultiplayer.transform.name;
        OptionsName = AnimatedObjectOptions.transform.name;
        QuitName = AnimatedObjectQuit.transform.name;

        //test = "hope";
        //takeMeOn = "hopevangough";
    }

    private void Update() {

        if (IsMouseOverUIWithIgnores()) 
        {

            PointerEventData pointerEventDataRay = new PointerEventData(EventSystem.current);
            pointerEventDataRay.position = Input.mousePosition;

            List<RaycastResult> raycastResultListRay = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventDataRay, raycastResultListRay);

            foreach( var x in raycastResultListRay) {

                //Debug.Log(x.ToString());
                selected = x;
                //Debug.Log(selected.ToString());
            }


            if(selected.ToString().Contains(StartName)) 
            {

                animatorButtonStart.SetTrigger("Inflate");
                if (returnAnim != 1) {returnScript();}

                returnAnim = 1;

            } else if (selected.ToString().Contains(StatsName)) 
            {

                animatorButtonStats.SetTrigger("Inflate");
                if (returnAnim != 2) {returnScript();}

                returnAnim = 2;

            } else if (selected.ToString().Contains(MultiName)) 
            {

                animatorButtonMultiplayer.SetTrigger("Inflate");
                if (returnAnim != 3) {returnScript();}

                returnAnim = 3;

            } else if (selected.ToString().Contains(OptionsName)) 
            {

                animatorButtonOptions.SetTrigger("Inflate");
                if (returnAnim != 4) {returnScript();}

                returnAnim = 4;

            } else if (selected.ToString().Contains(QuitName))
            {

                animatorButtonQuit.SetTrigger("Inflate");
                if (returnAnim != 5) {returnScript();}

                returnAnim = 5;

            } //else {Debug.Log("Anim:" + AnimatedObjectStart.transform.name.ToString());Debug.Log("Sel:" + selected.ToString());}
            /*else if (takeMeOn.Contains(test)) {
                Debug.Log("mans not hot");
            }*/
            
        } else {

            returnScript();
        }
    }
    
    private bool IsMouseOverUIWithIgnores() 
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for (int i = 0; i > raycastResultList.Count; i++) 
        {
            if (raycastResultList[i].gameObject.GetComponent<MouseUIClickthrough>() != null) 
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }

        return raycastResultList.Count > 0;
    }

    private void returnScript () 
    {

        switch(returnAnim)
        {
            case 1:
                if (!(animatorButtonStart.GetCurrentAnimatorStateInfo(0).IsName("Inflate"))) {animatorButtonStart.SetTrigger("Return");}
                break;

            case 2:
                if (!(animatorButtonStart.GetCurrentAnimatorStateInfo(0).IsName("Inflate"))) {animatorButtonStats.SetTrigger("Return");}
                
                break;

            case 3:
                if (!(animatorButtonStart.GetCurrentAnimatorStateInfo(0).IsName("Inflate"))) {animatorButtonMultiplayer.SetTrigger("Return");}
                
                break;

            case 4:
                if (!(animatorButtonStart.GetCurrentAnimatorStateInfo(0).IsName("Inflate"))) {animatorButtonOptions.SetTrigger("Return");}
                
                break;

            case 5:
                if (!(animatorButtonStart.GetCurrentAnimatorStateInfo(0).IsName("Inflate"))) {animatorButtonQuit.SetTrigger("Return");}
                
                break;

        }

    }

}