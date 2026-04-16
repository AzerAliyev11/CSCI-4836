using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator cookieAnimator;
    public static AnimationManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Cookie()
    {
        cookieAnimator.SetBool("Clicked", true);
        StartCoroutine(AfterCall(0.08f, "Clicked"));
    }

    IEnumerator AfterCall(float duration, string parameter)
    {
        yield return new WaitForSeconds(duration);
        cookieAnimator.SetBool(parameter, false);
    }
}
