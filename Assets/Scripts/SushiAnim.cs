using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiAnim : MonoBehaviour {

    public Animator animator;
    
    public void animate() {
        animator.Play("RunningSushi");
    }
}
