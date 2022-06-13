using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCinematic : MonoBehaviour
{
    public GameObject fade;
    public GameObject thief1;
    public GameObject thief2;

    public GameObject diag1;
    public GameObject diag2;
    public GameObject kapow;
    public GameObject ding;

    public GameObject player;
    public GameObject cam;
    public GameObject questList;
    public GameObject stats;
    public GameObject phone;

    public GameObject backpack;
    public GameObject wallet;

    [Header("Timers")]
    public float fadein;
    public float dialogue1;
    public float dialogue2;
    public float thievesStart;
    public float thievesBonk;
    public float fadebackin;

    [Header("Thief Target Positions")]
    public Vector3 thiefStart1;
    public Vector3 thiefStart2;
    public Vector3 thiefEnd1;
    public Vector3 thiefEnd2;

    private bool step1 = false;
    private bool step2 = false;
    private bool step3 = false;
    private bool step5 = false;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= fadein && !step1)
        {
            fade.GetComponent<Animator>().SetTrigger("fadein");
            step1 = true;
        }
        if (time >= dialogue1 && !step2)
        {
            diag1.SetActive(true);
            step2 = true;
        }
        if (time >= dialogue2 && !step3)
        {
            ding.SetActive(true);
            diag2.SetActive(true);
            step3 = true;
        }
        if (time >= thievesStart)
        {
            thief1.transform.position = Vector3.Lerp(thiefStart1, thiefEnd1, (time - thievesStart) / (thievesBonk - thievesStart));
            thief2.transform.position = Vector3.Lerp(thiefStart2, thiefEnd2, (time - thievesStart) / (thievesBonk - thievesStart));
        }
        if (time >= thievesBonk && !step5)
        {
            kapow.SetActive(true);
            fade.GetComponent<Animator>().SetTrigger("fadeout");
            step5 = true;
        }
        if (time >= fadebackin)
        {
            fade.GetComponent<Animator>().SetTrigger("fadein");

            player.GetComponent<Movement>().enabled = true;
            cam.GetComponent<FollowPlayer>().enabled = true;
            cam.GetComponent<ClickInteractables>().enabled = true;
            questList.SetActive(true);
            phone.SetActive(true);
            stats.SetActive(true);

            thief1.SetActive(false);
            thief2.SetActive(false);

            backpack.SetActive(true);
            wallet.SetActive(true);

            enabled = false;
        }

        time += Time.deltaTime;
    }
}
