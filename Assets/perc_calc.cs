using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class perc_calc : MonoBehaviour
{
    public TMP_InputField[] percin;
    public TMP_InputField[] scorein;
    public TMP_InputField[] maxin;
    public TMP_Text currtotal;
    public TMP_Text grade;
    public TMP_Text remaining;
    public TMP_Text summary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    float scoreNum()
    {
        float scoreAgg = 0;
        for (int i = 0; i < scorein.Length; i++)
        {
            if (allAvailable(i))
            {
                scoreAgg += calcField(i);
            }
        }
        return scoreAgg;
    }

    bool allAvailable(int index)
    {
        return !(percin[index].text == "") && !(scorein[index].text == "") && !(maxin[index].text == "");
    }

    bool noneAvailable()
    {
        for(int i=0; i<percin.Length; i++)
        {
            if (allAvailable(i))
            {
                return false;
            }
        }
        return true;
    }

    float calcField(int index)
    {
        return (float.Parse(scorein[index].text) / float.Parse(maxin[index].text)) * (float.Parse(percin[index].text));
    }

    int getLast()
    {
        int i; 
        for(i = 0; i < maxin.Length; i++)
        {
            if (maxin[i].text == "")
            {
                return i-1;
            }
        }
        return i;
    }

    public string createSummary()
    {
        float currScore = scoreNum();
        string left = "";
        int lastIndex = getLast();
        bool numDiff = !allAvailable(lastIndex);
        float lastMax = float.Parse(maxin[lastIndex].text);
        string addText;
        float remPerc = remainingPerc();
        if (currScore < 50)
        {
            if (numDiff)
            {
                addText = "" + (((50 - currScore) * lastMax) / remPerc);
            }
            else
            {
                addText = (50 - currScore) + "%";
            }
            left += "Left for D: " + addText + "\n";
        }
        if (currScore < 55)
        {
            if (numDiff)
            {
                addText = "" + (((55 - currScore) * lastMax)/remPerc);
            }
            else
            {
                addText = (55 - currScore) + "%";
            }
            left += "Left for D+: " + addText + "\n";
        }
        if (currScore < 60)
        {
            if (numDiff)
            {
                addText = "" + (((60 - currScore) * lastMax)/remPerc);
            }
            else
            {
                addText = (60 - currScore) + "%";
            }
            left += "Left for C-: " + addText + "\n";
        }
        if (currScore < 65)
        {
            if (numDiff)
            {
                addText = "" + (((65 - currScore) * lastMax) / remPerc);
            }
            else
            {
                addText = (65 - currScore) + "%";
            }
            left += "Left for C: " + addText + "\n";
        }
        if (currScore < 70)
        {
            if (numDiff)
            {
                addText = "" + (((70 - currScore)* lastMax) / remPerc);
            }
            else
            {
                addText = (70 - currScore) + "%";
            }
            left += "Left for C+: " + addText + "\n";
        }
        if (currScore < 74)
        {
            if (numDiff)
            {
                addText = "" + (((74 - currScore) * lastMax) / remPerc);
            }
            else
            {
                addText = (74 - currScore) + "%";
            }
            left += "Left for B-: " + addText + "\n";
        }
        if (currScore < 78)
        {
            if (numDiff)
            {
                addText = "" + (((78 - currScore) * lastMax) / remPerc);
            }
            else
            {
                addText = (78 - currScore) + "%";
            }
            left += "Left for B: " + addText + "\n";
        }
        if (currScore < 82)
        {
            if (numDiff)
            {
                addText = "" + (((82 - currScore) * lastMax) / remPerc);
            }
            else
            {
                addText = (82 - currScore) + "%";
            }
            left += "Left for B+: " + addText + "\n";
        }
        if (currScore < 86)
        {
            if (numDiff)
            {
                addText = "" + (((86 - currScore) * lastMax) / remPerc);
            }
            else
            {
                addText = (86 - currScore) + "%";
            }
            left += "Left for A-: " + addText + "\n";
        }
        if (currScore < 90)
        {
            if (numDiff)
            {
                addText = "" + (((90 - currScore) * lastMax) / remPerc);
            }
            else
            {
                addText = (90 - currScore) + "%";
            }
            left += "Left for A: " + addText + "\n";
        }
        if (currScore <94)
        {
            if (numDiff)
            {
                addText = "" + (((94 - currScore) * lastMax) / remPerc);
            }
            else
            {
                addText = (94 - currScore) + "%";
            }
            left += "Left for A+: " + addText + "\n";
        }
        else
        {
            return "Max grade!";
        }
        return left;
    }

    float remainingPerc()
    {
        float p = 0;
        for (int i = 0; i < percin.Length; i++)
        {
            if (percin[i].text != "")
            {
                p += float.Parse(percin[i].text);
            }
        }
        return 100 - p;
    }

    string getGrade()
    {
        float scoreAgg = scoreNum();
        if (scoreAgg.ToString().Length > 7)
        {
            currtotal.text = scoreAgg.ToString().Substring(0, 7) + "%";
        }
        else
        {
            currtotal.text = scoreAgg.ToString() + "%";
        }
        string gradeText;
        if (scoreAgg >= 94)
        {
            gradeText = "A+";
        }
        else if (scoreAgg >= 90)
        {
            gradeText = "A";
        }
        else if (scoreAgg >= 86)
        {
            gradeText = "A-";
        }
        else if (scoreAgg >= 82)
        {
            gradeText = "B+";
        }
        else if (scoreAgg >= 78)
        {
            gradeText = "B";
        }
        else if (scoreAgg >= 74)
        {
            gradeText = "B-";
        }
        else if (scoreAgg >= 70)
        {
            gradeText = "C+";
        }
        else if (scoreAgg >= 65)
        {
            gradeText = "C";
        }
        else if (scoreAgg >= 60)
        {
            gradeText = "C-";
        }
        else if (scoreAgg >= 55)
        {
            gradeText = "D+";
        }
        else if (scoreAgg >= 50)
        {
            gradeText = "D";
        }
        else
        {
            gradeText = "F";
        }
        return gradeText;
    }

    public void recalculate()
    {
        if (noneAvailable())
        {
            grade.text = "??";
            currtotal.text = "??";
            remaining.text = "??";
            summary.text = "";
            return;
        }
        grade.text = getGrade();
        remaining.text = remainingPerc().ToString() + "%";
        summary.text = createSummary();
    }
   
}
