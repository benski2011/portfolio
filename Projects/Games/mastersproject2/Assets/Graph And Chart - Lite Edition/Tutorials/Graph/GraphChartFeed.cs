using UnityEngine;
using ChartAndGraph;
using System.Collections;
using System.Collections.Generic;

public class GraphChartFeed : MonoBehaviour
{
    GraphChartBase graph;
    int h;

    static public List<float> rightaverage = new List<float>();
    static public List<float> leftaverage = new List<float>();


    void Start ()
    {
        h = 0;
        graph = GetComponent<GraphChartBase>();
        if (graph != null)
        {
            
          // graph.Scrollable = false;
          // graph.HorizontalValueToStringMap[0.0] = "Zero"; // example of how to set custom axis strings
          // graph.DataSource.StartBatch();
          // graph.DataSource.ClearCategory("Player 1");
          // graph.DataSource.ClearAndMakeBezierCurve("Player 2");
          // 
          // for (int i = 0; i <5; i++)
          // {
          //     graph.DataSource.AddPointToCategory("Player 1",i*5,Random.value*10f + 20f);
          //     if (i == 0)
          //         graph.DataSource.SetCurveInitialPoint("Player 2",i*5, Random.value * 10f + 10f);
          //     else
          //         graph.DataSource.AddLinearCurveToCategory("Player 2", 
          //                                                         new DoubleVector2(i*5 , Random.value * 10f + 10f));
          // }
          // graph.DataSource.MakeCurveCategorySmooth("Player 2");
          // graph.DataSource.EndBatch();
        }
       // StartCoroutine(ClearAll());
    }

    private void FixedUpdate()
    {


        h++;

        if (h%30 ==0 || h==0)
        {

            float tempR = 0;
            float tempL = 0;
            if (rightaverage.Count > 0)
            {
                for (int i = 0; i < rightaverage.Count; i++)
                {
                    tempR += rightaverage[i];
                }

                tempR /=  rightaverage.Count;

                rightaverage.Clear();
            }

            if (leftaverage.Count > 0)
            {
                for (int i = 0; i < leftaverage.Count; i++)
                {
                    tempL += leftaverage[i];
                }

                tempL /= leftaverage.Count;
                leftaverage.Clear();


                
            }
            Debug.Log(tempR);

            graph.DataSource.AddPointToCategory("HHand", h, tempR);
            graph.DataSource.AddPointToCategory("LHand", h, tempL);

        }
    }
    IEnumerator ClearAll()
    {
        yield return new WaitForSeconds(5f);
        GraphChartBase graph = GetComponent<GraphChartBase>();

        graph.DataSource.Clear();
    }
}
