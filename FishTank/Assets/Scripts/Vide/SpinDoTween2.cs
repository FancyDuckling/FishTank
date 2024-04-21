using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpinDoTween2 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.DORotate(new Vector3(0, 360, 0), 2.5f, RotateMode.FastBeyond360).SetRelative(true).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SwimAnim()
    {
        animator.Play(0);
    }
}
