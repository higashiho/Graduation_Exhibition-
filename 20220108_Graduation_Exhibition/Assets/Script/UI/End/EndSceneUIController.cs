using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneUIController : BaseUI
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreUI.Scores.PrintScore(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
