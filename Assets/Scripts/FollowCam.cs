using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set Dinamicaly")]
    public float camZ;
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;
    public GameObject castle_1lvl;
    public GameObject castle_2lvl;
    public GameObject castle_3lvl;
    // Start is called before the first frame update


    private void Start()
    {
        GameObject castle = new GameObject();
        if (GameStatistick.Level==1)
            castle = Instantiate<GameObject>(castle_3lvl);
        else if (GameStatistick.Level == 2)
            castle = Instantiate<GameObject>(castle_2lvl);
        else if (GameStatistick.Level == 3)
            castle = Instantiate<GameObject>(castle_3lvl);

        Vector3 pos = Vector3.zero;
        pos.x = 5f;
        pos.y = 0f;
        pos.z = -10f;
        castle.transform.position = pos;
       
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            POI = null;
        }
    }
    private void Awake()
    {
        camZ = this.transform.position.z;
    }
    private void FixedUpdate()
    {
        Vector3 destination;

        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;

            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination = Vector3.Lerp(transform.position, destination, easing);

        destination.z = camZ;

        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
    }
}
