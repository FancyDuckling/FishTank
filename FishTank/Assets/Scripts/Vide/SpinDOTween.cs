using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class SpinDOTween : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public GameObject specimenText;
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.DOLocalRotate(new Vector3(0, 360, 0), 2.5f, RotateMode.FastBeyond360).SetRelative(true).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        transform.DOMove(transform.position, 1f).SetLoops(-1).OnStepComplete(FlashText);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SwimAnim()
    {
       animator.Play(0);
    }
    void FlashText()
    {
        specimenText.SetActive(!specimenText.activeSelf);
    }
}
