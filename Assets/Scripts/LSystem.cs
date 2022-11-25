using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class TransformInfo
{
    public Vector3 position;
    public Quaternion rotation;
}
public class LSystem : MonoBehaviour
{
    int color;                                                          //to assign different color to different L-System
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject SliderHolders;
    [SerializeField] private GameObject[] BranchObject;
    [SerializeField] private GameObject BranchingParent;

    private string axiom ;
    private Stack<TransformInfo> transformStack;
    private Dictionary<char, string> rules;
    private string currentString = string.Empty;

    [Header("UI")]
    public TextMeshProUGUI currentLSyst;
    public Slider angleSlider;
    public Slider iterationSlider;
    public Slider lengthSlider;
    public TextMeshProUGUI angleText;
    public TextMeshProUGUI iterationText;
    public TextMeshProUGUI lengthText;

    private void Start()
    {
        SliderHolders.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            LSys1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LSys2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LSys3();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LSys4();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            LSys5();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            LSys6();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            LSys7();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            LSys8();
        }
    }
    public void LSys1()
    {
        if (SliderHolders.activeInHierarchy == false)
            SliderHolders.SetActive(true);
        color = 1;
        Camera.transform.position = new Vector3(0, 15, -30);
        transformStack = new Stack<TransformInfo>();
        axiom = "F";
        rules =new Dictionary<char, string>
        {
            { 'F',"F[+F]F[-F]F"}
        };
        currentLSyst.text = "L-System 1";
        TreeGenerate(5, 25.7f,0.1f);
    }

    public void LSys2()
    {
        if (SliderHolders.activeInHierarchy == false)
            SliderHolders.SetActive(true);
        color = 2;
        Camera.transform.position = new Vector3(0, 15, -30);
        transformStack = new Stack<TransformInfo>();
        axiom = "F";
        rules = new Dictionary<char, string>
        {
            { 'F',"F[+F]F[-F][F]"}
        };
        currentLSyst.text = "L-System 2";
        TreeGenerate(5,20,0.5f);
    }

    public void LSys3()
    {
        if (SliderHolders.activeInHierarchy == false)
            SliderHolders.SetActive(true);
        color = 3;
        Camera.transform.position = new Vector3(0, 15, -30);
        transformStack = new Stack<TransformInfo>();
        axiom = "F";
        rules = new Dictionary<char, string>
        {
            { 'F',"FF-[-F+F+F]+[+F-F-F]"}
        };
        currentLSyst.text = "L-System 3";
        TreeGenerate(2, 22.5f,0.5f);
    }

    public void LSys4()
    {
        if (SliderHolders.activeInHierarchy == false)
            SliderHolders.SetActive(true);
        color = 4;
        Camera.transform.position = new Vector3(0, 15, -30);
        transformStack = new Stack<TransformInfo>();
        axiom = "X";
        rules = new Dictionary<char, string>
        {
            { 'X',"F[+X]F[-X]+X"},
            {'F',"FF" }
        };
        currentLSyst.text = "L-System 4";
        TreeGenerate(7,20,0.1f);
    }

    public void LSys5()
    {
        if (SliderHolders.activeInHierarchy == false)
            SliderHolders.SetActive(true);
        color = 5;
        Camera.transform.position = new Vector3(0, 15, -30);
        transformStack = new Stack<TransformInfo>();
        axiom = "X";
        rules = new Dictionary<char, string>
        {
            { 'X',"F[+X][-X]FX"},
            {'F',"FF" }
        };
        currentLSyst.text = "L-System 5";
        TreeGenerate(7, 25.7f,0.1f);
    }

    public void LSys6()
    {
        if (SliderHolders.activeInHierarchy == false)
            SliderHolders.SetActive(true);
        color = 6;
        Camera.transform.position = new Vector3(0, 15, -30);
        transformStack = new Stack<TransformInfo>();
        axiom = "X";
        rules = new Dictionary<char, string>
        {
            { 'X',"F-[[X]+X]+F[+FX]-X"},
            {'F',"FF" }
        };
        currentLSyst.text = "L-System 6";
        TreeGenerate(6, 22.5f,0.1f);
    }

    public void LSys7()
    {
        if (SliderHolders.activeInHierarchy == false)
            SliderHolders.SetActive(true);
        color = 7;
        Camera.transform.position = new Vector3(0, 0, -30);
        transformStack = new Stack<TransformInfo>();
        axiom = "FX";
        rules = new Dictionary<char, string>
        {
            { 'X',"[-FX]+FX"}
        };
        currentLSyst.text = "L-System 7";
        TreeGenerate(7, 40, 1f); ;
    }

    public void LSys8()
    {
        if (SliderHolders.activeInHierarchy == false)
            SliderHolders.SetActive(true);
        color = 8;
        Camera.transform.position = new Vector3(0, 0, -30);
        transformStack = new Stack<TransformInfo>();
        axiom = "F+XF+F+XF";
        rules = new Dictionary<char, string>
        {
            {'X',"XF-F+F-XF+F+XF-F+F-X" }
        };
        TreeGenerate(2, 90, 0.3f);
        currentLSyst.text = "L-System 8";
    }

    void TreeGenerate(int iterations, float angle, float length)
    {
        BranchCleaning();
        currentString = axiom;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            foreach (char c in currentString)
            {
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());
            }
            currentString = sb.ToString();
            sb = new StringBuilder();
        }
        foreach(char c in currentString)
        {
            switch(c)
            {
                case 'F':
                    Vector3 initialPosition = transform.position;
                    transform.Translate(Vector3.up * length);
                    GameObject treeSegment = Instantiate(BranchObject[color],BranchingParent.transform);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(0, initialPosition);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    break;

                case 'X':
                    break;

                case '+':
                    transform.Rotate(Vector3.forward * angle);
                    break;

                case '-':
                    transform.Rotate(Vector3.back * angle);
                    break;

                case '[':
                    transformStack.Push(new TransformInfo()
                    {
                        position = transform.position,
                        rotation=transform.rotation
                    });
                    break;

                case ']':
                    TransformInfo ti = transformStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                    break;

                default:
                    throw new InvalidOperationException("Invalid L-Tree operation");

            }
        }
        angleSlider.value = angle;
        angleText.text = "Angle : "+angle.ToString("00.0");
        iterationSlider.value = iterations;
        iterationText.text = "Iterations : " + iterations.ToString();
        lengthSlider.value = length;
        lengthText.text = "Length : " + length.ToString("0.0");
    }

    public void OnSliderValueChange()
    {
        float newAngle = angleSlider.value;
        int newIteration = ((int)iterationSlider.value);
        float newLength = lengthSlider.value;
        TreeGenerate(newIteration, newAngle, newLength);
    }    
    void BranchCleaning()                                                           //To destroy all the child branches before creating new branches and resetting the position and rotation
    {                                                                               //of tree spawner
        for (int i=0;i<BranchingParent.transform.childCount;i++)                     
        {
            Destroy(BranchingParent.transform.GetChild(i).gameObject);
        }
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
