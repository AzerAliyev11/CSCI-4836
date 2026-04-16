using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] GameObject popup;

    [SerializeField] AudioClip cookieSFX;

    public void OnClick()
    {
        ScoreManager.Instance.AddScore(1);

        AnimationManager.Instance.Cookie();
        AudioManager.Instance.PlaySFX(cookieSFX);
        popup.SetActive(true);
    }

}
