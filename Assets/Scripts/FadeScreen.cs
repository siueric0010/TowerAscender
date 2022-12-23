using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    private float rateFade = .01f;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(0f,0f, 0f, 1.0f);
    }

    private void OnLevelWasLoaded(int level) {
        if(level >= 1 && image != null) {
            image.color = new Color(0f, 0f, 0f, 1.0f);
        }
    }

    void FixedUpdate()
    {
        StartCoroutine(decrementColor());
    }

    IEnumerator decrementColor() {

        if (image.color.a >= 0.0f) {
            image.color -= new Color(0, 0, 0, rateFade);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
