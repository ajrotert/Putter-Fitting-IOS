﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UIKit;

namespace IOSApp
{
    public class SaveData
    {
        private string[] PutterDataArray = {
        "Scotty Cameron Newport 2»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/select/newport-2/»",
"Scotty Cameron Newport 2.5»Normal Putter Head»Toe Weighted»Straight Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/select/newport-25/»",
"Scotty Cameron Newport 3»Wide Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/select/newport-3/»",
"Scotty Cameron Newport Laguna»Wide Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/select/laguna/»",
"Scotty Cameron Newport Fastback»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/select/fastback/»",
"Scotty Cameron Newport Squareback»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/select/squareback/»",
"Scotty Cameron Phantom X 5»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Phantom X 6»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Phantom X 7»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Phantom X 8»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Harder Feel»",
"Scotty Cameron Phantom X 12»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Harder Feel»",
"Scotty Cameron Phantom X 6 STR»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Harder Feel»",
"Scotty Cameron Futura 5W»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/futura/futura-5w/»",
"Scotty Cameron Futura 6M»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/futura/futura-6m/»",
"Scotty Cameron Futura 5.5M»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/futura/futura-55m/»",
"Scotty Cameron Futura 7M»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/futura/futura-7m/»",
"Scotty Cameron Futura 5S»Wide Putter Head»Face Balanced»Straight Shaft»Standard Weight»Harder Feel»https://www.scottycameron.com/putters/futura/futura-5s/»",
"Scotty Cameron Futura 5CB»Normal Putter Head»Face Balanced»Offset Shaft»Lighter Weight»Harder Feel»https://www.scottycameron.com/putters/futura/futura-5cb/»",
"Scotty Cameron Futura 5MB»Normal Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Harder Feel»https://www.scottycameron.com/putters/futura/futura-5mb/»",
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
"Odyssey O-Works #1»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works-black/putters-2017-o-works-black-1-ss.html»",
"Odyssey O-Works #1 Wide S»Wide Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-black-le-1w-slant.html»",
"Odyssey O-Works #1 Wide S Tank»Wide Putter Head»Toe Weighted»Straight Shaft»Heavier Weight»Softer Feel»",
"Odyssey O-Works #1 Tank»Normal Putter Head»Toe Weighted»Offset Shaft»Heavier Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-black-le-tank-1.html»",
"Odyssey O-Works Markxman»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-black-le-marxman.html»",
"Odyssey O-Works Markxman S»Wide Putter Head»Face Balance*»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-black-le-marxman-slant.html»",
"Odyssey O-Works Jailbird Mini»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-red-jailbird-mini.html»",
"Odyssey O-Works Jailbird Mini S»Normal Putter Head»Face Balance*»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-red-jailbird-mini-slant.html»",
"Odyssey O-Works 2-Ball Fang»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-red-le-2-ball-fang.html»",
"Odyssey O-Works 2-Ball Fang S»Wide Putter Head»Face Balance*»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-black-le-2-ball-fang-slant.html»",
"Odyssey O-Works #7»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-black-le-7.html»",
"Odyssey O-Works #7 S»Normal Putter Head»Face Balance*»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works-black/putters-2017-o-works-black-7s-ss.html»",
"Odyssey O-Works #7 Tank»Normal Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2018-o-works-black-le-tank-7.html»",
"Odyssey O-Works 2-Ball»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works-red/putters-2017-o-works-red-2-ball-ss.html»",
"Odyssey O-Works #2M CS»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works/putters-2017-o-works-black-2m-cs-ss.html»",
"Odyssey O-Works #3T»Normal Putter Head»Face Balanced»Offset Shaft»Lighter Weight»Softer Feel»https://www.callawaygolf.com/clubs/odyssey-putters/o-works-black/putters-2017-o-works-black-3t-ss.html»",
"Ping Sigma 2 Anser»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Ping Sigma 2 Arna»Wide Putter Head»Toe Weighted»Offset Shaft»Heavier Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Ping Sigma 2 Fetch»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Ping Sigma 2 Kushin C»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Ping Sigma 2 Tyne»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Ping Sigma 2 Tyne 4»Normal Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Ping Sigma 2 Valor»Wide Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Ping Sigma 2 Wolverine H»Wide Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Ping Sigma 2 ZB 2»Normal Putter Head»Toe Weighted»Offset Shaft»Lighter Weight»Softer Feel»http://ping.com/clubs/putters/sigma-2»",
"Taylormade Spider Tour Black»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Harder Feel»https://www.taylormadegolf.com/Spider-Tour-Black/DW-WZ816.html?cgid=taylormade-putters#start=2&»",
"Taylormade Spider Tour Red»Normal Putter Head»Face Balanced»Straight Shaft»Standard Weight»Softer Feel»https://www.taylormadegolf.com/Spider-Tour-Red/DW-WZ811.html?cgid=taylormade-putters#start=3&»",
"Taylormade Spider Tour Red Double Bend»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»https://www.taylormadegolf.com/Spider-Tour-Red-Double-Bend/DW-WZ814.html?cgid=taylormade-putters#start=4&»",
"Taylormade Spider Tour Black Double Bend»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.taylormadegolf.com/Spider-Tour-Black-Double-Bend/DW-WZ817.html?cgid=taylormade-putters#start=5&»",
"Taylormade Spider Tour Red Sightline»Wide Putter Head»Face Balanced»Straight Shaft»Standard Weight»Softer Feel»https://www.taylormadegolf.com/Spider-Tour-Red-Sightline/DW-WZ815.html?cgid=taylormade-putters#start=6&»",
"Taylormade TP Black Copper Collection Juno»Normal Putter Head»Toe Weighted»Offset Shaft»Lighter Weight»Harder Feel»https://www.taylormadegolf.com/TP-Black-Copper-Collection-Juno/DW-JIC32.html?cgid=taylormade-putters#start=7&»",
"Taylormade TP Black Copper Collection Ardmore 3»Wide Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Harder Feel»https://www.taylormadegolf.com/TP-Black-Copper-Collection-Ardmore-3/DW-JIC35.html?cgid=taylormade-putters#start=8&»",
"Taylormade TP Red Collection Ardmore 3»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.taylormadegolf.com/TP-Red-Collection-Ardmore-3/DW-WZ807.html?cgid=taylormade-putters#start=9&»",
"Taylormade Spider Mini Red»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Harder Feel»https://www.taylormadegolf.com/Spider-Mini-Red/DW-JIC27.html?cgid=taylormade-putters#start=10&»",
"Cleveland Huntington Beach Soft 1»Normal Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Softer Feel»https://www.clevelandgolf.com/en/putters-/huntington-beach-soft-1-putter/MHBS1.html»",
"Cleveland Huntington Beach Soft 6»Normal Putter Head»Face Balanced»Offset Shaft»Standard Weight»Softer Feel»https://www.clevelandgolf.com/en/putters-/huntington-beach-soft-6-putter/MHBS6.html»",
"Cleveland Huntington Beach Soft 8.5»Wide Putter Head»Toe Weighted»Offset Shaft»Standard Weight»Softer Feel»https://www.clevelandgolf.com/en/putters-/huntington-beach-soft-8.5-putter/MHBS85.html»",
"Cleveland Huntington Beach Soft 11»Normal Putter Head»Face Balanced»Offset Shaft»Heavier Weight»Softer Feel»https://www.clevelandgolf.com/en/putters-/huntington-beach-soft-11-putter/MHBS11.html»",
"Cleveland Huntington Beach Soft 11C»Normal Putter Head»Face Balanced»Straight Shaft»Heavier Weight»Softer Feel»https://www.clevelandgolf.com/en/putters-/huntington-beach-soft-11c-putter/MHBS11C.html»",
"Cleveland Huntington Beach Soft 12»Wide Putter Head»Face Balanced»Straight Shaft»Heavier Weight»Softer Feel»https://www.clevelandgolf.com/en/putters-/huntington-beach-soft-12-putter/MHBS12.html»"
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
