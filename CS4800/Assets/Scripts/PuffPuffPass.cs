using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffPuffPass : MonoBehaviour
{
    bool isPassing;
    
    List<GameObject> children = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GetKids();
        while (children.Count < 5)
        {
            GetKids();
        }
        StartCoroutine(PassSomeTime(2));
    }

    void GetKids()
    {
        children.Clear();
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform t in transforms)
        {
            children.Add(t.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPassing)
        {
            StartCoroutine(PassTheJ());
            StartCoroutine(PassSomeTime(7));
            isPassing = false;
        }

    }

    IEnumerator PassTheJ()
    {
        foreach (GameObject child in children)
        {
            Vector3 oldPos = child.transform.position;
            Vector3 newPos = new Vector3(child.transform.position.x * 1.5f, child.transform.position.y, child.transform.position.z * 1.5f);
            StartCoroutine(PassEachJ(child.transform, oldPos, newPos));
        }
        StartCoroutine(RotateDemJs());
        yield return new WaitForSeconds(3);
        foreach(GameObject child in children)
        {
            Vector3 oldPos = child.transform.position;
            Vector3 newPos = new Vector3(child.transform.position.x / 1.5f, child.transform.position.y, child.transform.position.z / 1.5f);
            StartCoroutine(PassEachJ(child.transform, oldPos, newPos));
        }
        yield return null;
    }

    IEnumerator PassEachJ(Transform moveObject, Vector3 oldPos, Vector3 newPos)
    {
        float moveTime = 1f;
        float i = 0;
        float rate = 1.0f / moveTime;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            moveObject.position = Vector3.Lerp(oldPos, newPos, i);
            yield return null;
        }
    }

    IEnumerator RotateDemJs()
    {
        yield return new WaitForSeconds(1);
        float rotateDegrees = 90f;
        float rate = 1.0f / rotateDegrees;
        float degreesRotated = 0;

        while (degreesRotated < 90.0f)
        {
            this.transform.Rotate(Vector3.up, 90 * rate);
            degreesRotated += (90 * rate);
            yield return null;
        }
    }

    IEnumerator PassSomeTime(float seconds = 5.0f)
    {
        yield return new WaitForSeconds(seconds);
        isPassing = true;
    }
}
