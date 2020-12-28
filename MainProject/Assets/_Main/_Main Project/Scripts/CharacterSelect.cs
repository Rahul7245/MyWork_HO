using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject Character;
    // Start is called before the first frame update

    Animator anim;
    void Start()
    {
        anim = Character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void SelectButtonClicked() {
        anim.Play("SelectAnimation");
    }
}
