using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetScores : MonoBehaviour
{
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player1_det;

    public TextMeshProUGUI player2;
    public TextMeshProUGUI player2_det;

    public TextMeshProUGUI total_score;
    // Start is called before the first frame update
    void Start()
    {
        // getting player1's scores
        int total1 = Score.player1Score;
        int max1 = Score.player1MaxScore;

        float percent = (float)total1/max1*100;
        percent = Mathf.Round(percent);

        player1.text = percent.ToString() + "%";
        string miss = " misses";
        if(Score.player1Misses == 1) miss = " miss";
        player1_det.text = Score.player1Misses.ToString() + miss;

        // getting player 2's scores
        int total2 = Score.player2Score;
        int max2 = Score.player2MaxScore;

        float percent2 = (float)total2/max2*100;
        percent2 = Mathf.Round(percent2);

        player2.text = percent2.ToString() + "%";
        string miss2 = " misses";
        if(Score.player2Misses == 1) miss2 = " miss";
        player2_det.text = Score.player2Misses.ToString() + miss2;


        float group_total = total1 + total2;
        float group_max = max1 + max2;
        float percent3 = Mathf.Round((group_total/group_max)*100);

        total_score.text = percent3.ToString() + "%";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
