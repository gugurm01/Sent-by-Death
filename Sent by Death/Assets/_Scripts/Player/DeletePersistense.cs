using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePersistense : MonoBehaviour
{
    void Awake()
    {
        Destroy(Persistence.Instance.gameObject);
    }
}
