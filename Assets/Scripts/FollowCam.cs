using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    public Text level;
    public Text player1;
    public Text player2;
    public Text allShots;
    public Color textColor = new Color(255 / 255f, 64 / 255f, 64 / 255f);
    // Start is called before the first frame update


    private void Start()
    {
        GameObject castle = new GameObject();
        if (GameStatistick.Level==1)
            castle = Instantiate<GameObject>(castle_1lvl);
        else if (GameStatistick.Level == 2)
            castle = Instantiate<GameObject>(castle_2lvl);
        else if (GameStatistick.Level == 3)
            castle = Instantiate<GameObject>(castle_3lvl);

        GameObject go = GameObject.Find("Level");
        level = go.GetComponent<Text>();
        level.text += GameStatistick.Level.ToString();


        go = GameObject.Find("Player1");
        player1 = go.GetComponent<Text>();
        player1.text = $"Player 1 : {GameStatistick.ScorePlayer1}";
        go = GameObject.Find("Player2");
        player2 = go.GetComponent<Text>();
        player2.text = $"Player 2 : {GameStatistick.ScorePlayer2}";

        Vector3 pos = Vector3.zero;
        pos.x = 15f;
        pos.y = 0f;
        pos.z = -10f;
        castle.transform.position = pos;
       
    }
    private void Update()
    {
        GameObject go = GameObject.Find("AllShots");
        allShots = go.GetComponent<Text>();
        allShots.text = $"Shots : {GameStatistick.Shots}";
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
            if (GameStatistick.Shots % 2 == 0)
            {
                player1.color = Color.green;
                player2.color = textColor;
            }
            else
            {
                player2.color = Color.green;
                player1.color = textColor;
            }
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
