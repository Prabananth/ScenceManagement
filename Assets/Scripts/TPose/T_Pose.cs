using UnityEngine;
using UnityEngine.SceneManagement;
public class T_Pose : MonoBehaviour {
    private GameObject TPOSE;
    public GameObject GD;
    public GameObject SKTN;
    public GameObject IDSWT;
    //public MapJoins MJ;
    void Start()
    {
        TPOSE = GameObject.Find("TPose");   
        GD.SetActive(true);
        SKTN.SetActive(true);
        IDSWT.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TPosition()
    {
        if (TPose_Colliders.HandLeft == true && TPose_Colliders.HandRight == true && TPose_Colliders.LeftElbow == true && TPose_Colliders.RightElbow == true)
        {
            SceneManager.LoadScene("MainGame");
            //MJ.StartCoroutine("StartTimer");
            TPOSE.SetActive(false);
            GUIData.Current.Initialized = true;
           // MJ.Map();
        }
    }
}
