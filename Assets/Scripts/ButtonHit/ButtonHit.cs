using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHit : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{
    private int Buttinhit;
    private Animator _anim;

    public static bool  Kicking = false;
    //public Goblin Goblin { get => goblin; set => goblin = value; }
    public void Awake()
    {

    }

    public void Start()
    {
        Kicking = false;
        var aninator = GameObject.Find("Hero");
        _anim = aninator.GetComponent<Animator>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Kicking = true;
        _anim.SetBool("isSlashing", true);
    }

    

    public void OnPointerUp(PointerEventData eventData)
    {
        Kicking = false;
        _anim.SetBool("isSlashing", false);
    }
}
