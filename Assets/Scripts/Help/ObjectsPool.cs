using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
    Object Pool Parrent Implementation
*/

public class ObjectsPool {

    GameObject pooledObject;
    int pooledObjectsAmount;
    bool willGrow;
    List<GameObject> pooledObjects;
    Transform parentObject;


    /**
        obj : el objeto que se quiere instancia y meter en el pool
        parent : tranform del objeto que será padre de los objetos del pool, con motivos de limpieza en la jerarquia
        grow : si es true permite aumentar la instanciacion de un nuevo objeto cuando no hay un objeto en el pool disponible
        amount : cantidad total inicial de objetos en el pool
    */
    public ObjectsPool(GameObject obj, Transform parent = null, bool grow = false, int amout = 10) {
        pooledObject = obj;
        parentObject = parent;
        willGrow = grow;
        pooledObjectsAmount = amout;
        pooledObjects = new List<GameObject>();
        // Instancia los objetos
        for (int i = 0; i < pooledObjectsAmount; i++)
        {
            GameObject o = (GameObject)GameObject.Instantiate(pooledObject);
            o.transform.parent = parent; // hacerlos hijos
            o.SetActive(false); // y desactivarlos
            pooledObjects.Add(o);
        }
    }
    /**
        Metodo para conseguir un objeto del pool
    */
    public GameObject GetPooledObject()
    {
        // devolver un objeto si no esta activo en la jerarquia (este objeto debe ser activado para no volver a devolverlo)
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // si no hay ningun objeto disponible y se permite crearlos, hacer uno nuevo
        if (willGrow)
        {
            GameObject o = (GameObject)GameObject.Instantiate(pooledObject);
            o.transform.parent = parentObject;
            o.SetActive(false);
            pooledObjects.Add(o);
            return o;
        }

        return null;
    }

}
