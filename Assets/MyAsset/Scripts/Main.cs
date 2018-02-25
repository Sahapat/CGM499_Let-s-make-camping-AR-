using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TargetTag
{
    Camp,
    Crate,
    Stone,
    Fire,
    TreeNone,
    TreeLeaf,
    Fence1,
    Fence2,
    Fence3,
    Fence4
};

public class Main : MonoBehaviour
{
    [Header("Text")]
    [SerializeField]
    private Text TxtCampStatus;
    [SerializeField]
    private Text TxtFireStatus;

    [Header("Other")]
    [SerializeField]
    private GameObject StartBtn;
    [SerializeField]
    private GameObject startCampfireParticle;

    private bool _campStatus;
    public bool campStatus
    {
        get
        {
            return _campStatus;
        }
        set
        {
            _campStatus = value;
            if(_campStatus)
            {
                TxtCampStatus.color = Color.green;
                TxtCampStatus.text = "Found";
            }
            else
            {
                TxtCampStatus.color = Color.red;
                TxtCampStatus.text = "None";
            }
        }
    }
    private bool _FireStatus;
    public bool FireStatus
    {
        get
        {
            return _FireStatus;
        }
        set
        {
            _FireStatus = value;
            if (_FireStatus)
            {
                TxtFireStatus.color = Color.green;
                TxtFireStatus.text = "Found";
            }
            else
            {
                TxtFireStatus.color = Color.red;
                TxtFireStatus.text = "None";
            }
        }
    }
    private bool _canStartCampfire;
    public bool canStartCampfire
    {
        get
        {
            return _canStartCampfire;
        }
        set
        {
            _canStartCampfire = value;
            if(canStartCampfire)
            {
                StartBtn.SetActive(true);
            }
            else
            {
                StartBtn.SetActive(false);
            }
        }
    }

    public static Main instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        canStartCampfire = false;
        campStatus = false;
        FireStatus = false;
        startCampfireParticle.SetActive(false);
    }
    private void Update()
    {
        canStartCampfire = (campStatus && FireStatus) ? true : false;
    }
    public void setTargetStatus(TargetTag myTag,bool status)
    {
        switch(myTag)
        {
            case TargetTag.Camp:
                campStatus = status;
                break;
            case TargetTag.Fire:
                FireStatus = status;
                break;
        }
    }
    public void StartCampfire()
    {
        startCampfireParticle.SetActive(!startCampfireParticle.activeSelf);
        if(startCampfireParticle.activeSelf)
        {
            StartBtn.GetComponentInChildren<Text>().text = "StopCampFire";
        }
        else
        {
            StartBtn.GetComponentInChildren<Text>().text = "StartCampFire";
        }
    }
}
