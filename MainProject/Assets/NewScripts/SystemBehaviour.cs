using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemBehaviour : StateMachine

{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



public class Begin : State {
    public Begin(StateMachineBehaviour stateMachineBehaviour) : base(stateMachineBehaviour)
    {
    }
    public override IEnumerator Start()

    {
        yield return new WaitForSeconds(2);
    }


}
