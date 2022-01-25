using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    private Stack<GameObject> poolStack = new Stack<GameObject>();

    public void AddObjectToPool(GameObject newObject)
    {
        poolStack.Push(newObject);
        newObject.SetActive(false);
    }

    public void AddObjectToPoolInSeconds(GameObject newObject, float seconds)
    {
        StartCoroutine(AddInSecondsCoroutine(newObject, seconds));
    }

    public GameObject GetObjectFromPool(Vector3 objectPosition, Quaternion objectRotation)
    {
        GameObject returnObject;

        if (poolStack.Count > 0)
        {
            returnObject = poolStack.Pop();
            returnObject.transform.position = objectPosition;
            returnObject.transform.rotation = objectRotation;
            returnObject.SetActive(true);
        }

        else
        {
            returnObject = Instantiate(objectPrefab, objectPosition, objectRotation);
        }

        return returnObject;
    }

    private IEnumerator AddInSecondsCoroutine(GameObject newObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        AddObjectToPool(newObject);
    }
}
