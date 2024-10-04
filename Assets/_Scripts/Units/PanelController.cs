using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public float waitTime = 2f;
    // Start the coroutine to show the panel when set active
    private void OnEnable() {
        StartCoroutine(ShowPanelCoroutine());
    }

    private IEnumerator ShowPanelCoroutine()
    {
        yield return new WaitForSeconds(waitTime);

        gameObject.SetActive(false);
    }
}
