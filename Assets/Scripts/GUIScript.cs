using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GUIScript : MonoBehaviour {
    //private Dictionary<string, int> selectedExercise;
    //private List<string> selectedJoints;
    string currExercise;
    private int breakTime, sets;
    private string user;
    private GameObject loginUI, inter, skel;
    public NetManager NetworkManager;
    public GameObject GUI;
    //public MapJoins MJ;
    //public T_Pose TP;
	public static GUIScript path = new GUIScript ();
	public string CreateFolder;

	// Use this for initialization
	void Start () {
        loginUI = GameObject.Find("Login");
        inter = GameObject.Find("Interface");
        skel = GameObject.Find("Skeleton");
        inter.SetActive(false);
        skel.SetActive(false);
        //currExercise = new Exercise();
        //selectedExercise = new Dictionary<string, int>();
        //selectedJoints = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(UnityEngine.Random.Range(1,3));
	}
    public void register()
    {
        StreamReader fread = new StreamReader("user.txt");
        string uname = GameObject.Find("NameField").GetComponent<InputField>().text;
        string pwd = GameObject.Find("PasswordField").GetComponent<InputField>().text;
        //Debug.Log(uname + " " + pwd);
        string temp;
		bool flag = false;
		CreateFolder = "C:\\Users\\rajan\\Desktop\\MultiBoxing\\Prabha" + uname;
        while ((temp = fread.ReadLine()) != null && flag == false)
        {
            temp = temp.Substring(0, temp.IndexOf(":"));
            //Debug.Log(temp);
            if(uname==temp)
            {
                flag = true;
                //EditorUtility.DisplayDialog("Error", "User Already Exists.", "Okay");
                break;
            }
        }
        fread.Close();
        if (flag == false)
        {
            StreamWriter file = new StreamWriter("user.txt");
            file.WriteLine(uname + ":" + pwd);
            file.Close();
        }
		if (!Directory.Exists (CreateFolder)) {
			Directory.CreateDirectory(CreateFolder);
		}
    }
    public void login()
    {
        StreamReader file = new StreamReader("user.txt");
        string uname = GameObject.Find("NameField").GetComponent<InputField>().text;
        string pwd = GameObject.Find("PasswordField").GetComponent<InputField>().text;
        string match = uname + ":" + pwd;
        string temp;
		bool flag = false;
		CreateFolder = "C:\\Users\\rajan\\Desktop\\MultiBoxing\\Prabha" + uname;
        while((temp=file.ReadLine())!=null && flag==false)
        {
            if (temp == match)
            {
                user = uname;
                file.Close();
                loginSuccess();
                flag = true;
                break;
            }
        }
        if (flag == false)
        {
            //EditorUtility.DisplayDialog("Error", "Invalid Username or Password.", "Okay");
            file.Close();
        }
		if (!Directory.Exists (CreateFolder)) {
			Directory.CreateDirectory(CreateFolder);
		}
    }
    public void loginSuccess()
    {
        loginUI.SetActive(false);
        inter.SetActive(true);
        skel.SetActive(true);
    }


    public void OKdemo(InputField ip)
    {
		if (ip.text != "")
		{
			
			if (ip.name == "HighKneesField") 
			{
				currExercise = "HighKnees";
				Debug.Log (currExercise);
                GUIData.Current.selectedExercise.Add(currExercise, 0);
                GUIData.Current.ExerciseList.Add(currExercise);

				int rep = System.Convert.ToInt32(ip.text);
                GUIData.Current.selectedExercise[currExercise] = rep;
                Debug.Log(rep);

				foreach (KeyValuePair<string, int>  k in GUIData.Current.selectedExercise)
				{
					// Debug.Log(k.Key+":"+k.Value);
				}
				currExercise = null;

			}
			else if(ip.name == "SquatsField")
			{
				Debug.Log (ip.name);
				currExercise = "Squat";
                GUIData.Current.selectedExercise.Add(currExercise, 0);
                GUIData.Current.ExerciseList.Add(currExercise);

				int rep = System.Convert.ToInt32(ip.text);
                GUIData.Current.selectedExercise[currExercise] = rep;
                Debug.Log(rep);

                foreach (KeyValuePair<string, int>  k in GUIData.Current.selectedExercise)
				{
					// Debug.Log(k.Key+":"+k.Value);
				}
				currExercise = null;

			}else if(ip.name == "JJField")
			{
				Debug.Log (ip.name);
				currExercise = "JumpingJack";
                GUIData.Current.selectedExercise.Add(currExercise, 0);
                GUIData.Current.ExerciseList.Add(currExercise);

				int rep = System.Convert.ToInt32(ip.text);
                GUIData.Current.selectedExercise[currExercise] = rep;
                Debug.Log(rep);

                foreach (KeyValuePair<string, int>  k in GUIData.Current.selectedExercise)
				{
					// Debug.Log(k.Key+":"+k.Value);
				}
				currExercise = null;
			}else if(ip.name == "LeftLungesField")
			{
				Debug.Log (ip.name);
				currExercise = "LeftLunges";
                GUIData.Current.selectedExercise.Add(currExercise, 0);
                GUIData.Current.ExerciseList.Add(currExercise);

				int rep = System.Convert.ToInt32(ip.text);
                GUIData.Current.selectedExercise[currExercise] = rep;
                Debug.Log(rep);

                foreach (KeyValuePair<string, int>  k in GUIData.Current.selectedExercise)
				{
					// Debug.Log(k.Key+":"+k.Value);
				}
				currExercise = null;
			}else if(ip.name == "RightLungesField")
			{
				Debug.Log ("RLF : "+ip.name);
				currExercise = "RightLunges";
                GUIData.Current.selectedExercise.Add(currExercise, 0);
                GUIData.Current.ExerciseList.Add(currExercise);

				int rep = System.Convert.ToInt32(ip.text);
                GUIData.Current.selectedExercise[currExercise] = rep;
                Debug.Log(rep);

                foreach (KeyValuePair<string, int>  k in GUIData.Current.selectedExercise)
				{
					// Debug.Log(k.Key+":"+k.Value);
				}
				currExercise = null;
            }
            else
            {
                return;
            }
		}
		else
		{
			//EditorUtility.DisplayDialog("Error", "Enter the number of Reps.", "Okay");
		}
    }

    public void ExercisePressed(Button b)
    {
        if (b.image.color == Color.green)
        {
            //EditorUtility.DisplayDialog("Error", "You have already selected this exercise.", "Okay");
            currExercise = b.name;
        }
        else
        {
            b.image.color = Color.green;
			Debug.Log (b.name);
            currExercise = b.name;
            GUIData.Current.selectedExercise.Add(currExercise, 0);
            //selectedExercise.Add(currExercise, 0);
            GUIData.Current.ExerciseList.Add(currExercise);
        }
    }

    public void addJoint(Button b)
    {
        string jointName = b.name;
        if (GUIData.Current.selectedJoints.Contains(jointName))
        //if (selectedJoints.Contains(jointName))
        {
            GUIData.Current.selectedJoints.Remove(jointName);
            //selectedJoints.Remove(jointName);
            b.image.color = Color.white;
        }
        else
        {
            GUIData.Current.selectedJoints.Add(jointName);
            //selectedJoints.Add(jointName);
            b.image.color = Color.green;
        }
        foreach (string s in GUIData.Current.selectedJoints)
        //foreach (string s in selectedJoints)
        {
            //Debug.Log(s);
        }
    }

    public void finish(string scenename)
    {
		Debug.Log (GUIData.Current.selectedExercise);
        InputField br = GameObject.Find("BreakField").GetComponent<InputField>();
        InputField set = GameObject.Find("SetsField").GetComponent<InputField>();
        if (GUIData.Current.selectedJoints.Count == 0)
        {
            //EditorUtility.DisplayDialog("Error", "You have not selected any joints.", "Okay");
        }
        else if (GUIData.Current.selectedExercise.Count == 0) {
            //EditorUtility.DisplayDialog("Error", "You have not selected any exercise.", "Okay");
        }
        else if (br.text == "") {
            //EditorUtility.DisplayDialog("Error", "You have not entered break time.", "Okay");
        }
        else if (set.text == "") {
            //EditorUtility.DisplayDialog("Error", "You have not entered number of sets.", "Okay");
        }
        else
        {
            GUIData.Current.breakTime = Convert.ToInt32(br.text);
            GUIData.Current.sets = Convert.ToInt32(set.text);
            inter.SetActive(false);
            skel.SetActive(false);
            //EditorUtility.DisplayDialog("Error", "Details Updated.", "Okay");
            //NetworkManager.StartS();
            CharacterMotion.CanWork = true;
            //MJ.Initialized = true;
            //MJ.Map();
            //TP.TPosition();
            Debug.Log(scenename);
            SceneManager.LoadScene(scenename);
            GUI.SetActive(false);
        }
    }
}
