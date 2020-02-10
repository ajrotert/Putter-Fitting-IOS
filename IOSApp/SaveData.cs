using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UIKit;

namespace IOSApp
{
    public class SaveData
    {
        private string[] PutterDataArray = {

        "Scotty Cameron Newport 2»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»",
        "Scotty Cameron Newport»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Newport 2.5»Normal Putter Head»Toe Weighted»Straight Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Newport Del Mar»Wide Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Newport Fastback»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Newport Squareback»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Phantom X 5»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Phantom X 6»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Phantom X 7»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Phantom X 8»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Harder Feel»",
"Scotty Cameron Phantom X 12»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Harder Feel»",
"Scotty Cameron Phantom X 6 STR»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Phantom X 5.5»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Flowback 5»Wide Putter Head»Face Balanced»Straight Shaft»Standard Weight»Harder Feel»",
"Odyssey Triple Track 2-Ball»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»",
"Odyssey Triple Track 2-Ball Blade»Normal Putter Head»Face Balanced*»Offset Shaft»Standard Weight»Softer Feel»",
"Odyssey Triple Track Marxman»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»",
"Odyssey Triple Track Ten»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Triple Track Ten S»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Triple Track Doulbe Wide»Wide Putter Head»Face Balanced*»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Triple Track Doulbe Wide S»Wide Putter Head»Toe Weighted»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab Double Wide FLow»Wide Putter Head»Toe Weighted»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab Three»Normal Putter Head»Toe Weighted»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab One»Normal Putter Head»Toe Weighted»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab V-Line CS»Wide Putter Head»Face Balanced»Straight Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab V-Line S»Wide Putter Head»Face Balance*»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab V-Line»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab R-Ball»Normal Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab R-Ball S»Normal Putter Head»Face Balance*»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab Seven»Normal Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»",
"Odyssey Stroke Lab Seven S»Normal Putter Head»Face Balance*»Offset Shaft»Heavier Weight»Softer Feel»",
"Ping Sigma 2 Anser»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Softer Feel»",
"Ping Sigma 2 Arna»Wide Putter Head»Toe Weighted»Offset Shaft»Heavier Weight»Softer Feel»",
"Ping Sigma 2 Fetch»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»",
"Ping Sigma 2 Kushin C»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Softer Feel»",
"Ping Sigma 2 Tyne»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»",
"Ping Sigma 2 Tyne 4»Normal Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»",
"Ping Sigma 2 Valor»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»",
"Ping Sigma 2 Wolverine H»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»",
"Ping Sigma 2 ZB 2»Normal Putter Head»Toe Weighted»Offset Shaft»Lighter Weight»Softer Feel»",
"Taylormade Spider Tour Black»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Harder Feel»",
"Taylormade Spider Tour Red»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Softer Feel»",
"Taylormade Spider Tour Red Double Bend»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»",
"Taylormade Spider Tour Black Double Bend»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Taylormade Spider Tour Red Sightline»Wide Putter Head»Face Balanced»Straight Shaft»Standard Weight»Softer Feel»",
"Taylormade Truss TB1»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»",
"Taylormade Truss TB2»Normal Putter Head»Toe Weighted»Straight Shaft»Standard Weight»Harder Feel»",
"Taylormade Truss TM1»Wide Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»",
"Taylormade Spider Mini Red»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Cleveland Frontline 4.0»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Softer Feel»",
"Cleveland Frontline Elevado Single Bend»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»",
"Cleveland Frontline Elevado Slant»Normal Putter Head»Face Balanced*»Offset Shaft»Standard Weight»Softer Feel»",
"Cleveland Frontline Cero Slant»Normal Putter Head»Face Balanced*»Offset Shaft»Heavier Weight»Softer Feel»",
"Cleveland Frontline ISO Slant»Wide Putter Head»Face Balanced*»Offset Shaft»Standard Weight»Softer Feel»"
};


        public string[] accessData(params string[] data) //returns a string of matching information
        {
                List<string> dataList = new List<string>();
            for (int a = 0; a < PutterDataArray.Length; a++)
            {
                if (PutterDataArray[a].Contains(data[0]))
                {
                    dataList.Add(PutterDataArray[a]);
                }
            }

                if (dataList.Count == 0) //insures that there will always be one item returned
                    {
                        if (PutterDataArray.Length != 0)
                                    dataList.Add(PutterDataArray[0]);
                        else
                            dataList.Add("empty list");
                    }

                int[] tracking = new int[dataList.Count];
                int trackingCount = 0;
                for (int a = 1; a < data.Length; a++) //the number of parameters sent in
                {
                    for (int b = 0; b < dataList.Count && dataList.Count >= 1; b++)
                    {
                        if (!dataList[b].Contains(data[a]))
                        {
                            tracking[trackingCount] = b;
                            trackingCount++;
                        }
                    }
                    if (trackingCount <= dataList.Count - 1)
                    {
                        int eliminated = 0;
                        for (int b = 0; b < trackingCount; b++)
                        {
                            dataList.RemoveAt(tracking[b] - eliminated);
                            eliminated++;
                        }
                        trackingCount = 0;
                    }
                    trackingCount = 0;
                }
                string[] array = dataList.ToArray();
                return array;

        }


    }
}
