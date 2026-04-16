using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    void OnEnable()
    {
        transform.position = Input.mousePosition;
        StartCoroutine(Animation(new Vector3(1, 1, 1), new Vector3(transform.position.x, transform.position.y + 100, transform.position.z), 0.08f));
    }

    public IEnumerator Animation(Vector3 endScale, Vector3 endPosition, float duration) {
        Vector3 startScale = transform.localScale;
        Vector3 startPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration) {
            transform.localScale = Vector3.Lerp(startScale, endScale, elapsed / duration);
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;
        transform.position = endPosition;

        gameObject.SetActive(false);
    }
}
