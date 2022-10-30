using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private CameraFollow cameraFollow;

    private void Awake()
    {
        GlobalReferences.CameraShake = this;
        cameraFollow = GetComponent<CameraFollow>();
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        cameraFollow.SetCanFollow(false);

        Vector3 originalPos = transform.position;

        float elapsed = 0f;

        while(elapsed < duration)
        {
            float x = originalPos.x + Random.Range(-1f, 1f) * magnitude;
            float y = originalPos.y + Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
        cameraFollow.SetCanFollow(true);
    }
}
