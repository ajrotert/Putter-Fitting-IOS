﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IOSApp
{
    public class PutterData : Iputter //implements traits for found putter
    {
        /// <summary>
        /// Checks to make sure that everything is in order still
        /// </summary>
        /// <param name="heap"></param>
        /// <param name="loc"></param>
        /// <param name="last"></param>
        private void reheapDown(node[] heap, int loc, int last)
        {//check for children, if one is larger then swap
            int leftKey, rightKey, largestIndex;
            node hold;
            if (loc * 2 + 1 <= last)
            {
                leftKey = heap[loc * 2 + 1].importance;
                if (loc * 2 + 2 <= last)
                    rightKey = heap[loc * 2 + 2].importance;
                else
                    rightKey = leftKey - 1; // make so rightKey is always smaller than leftKey
                if (rightKey > leftKey)
                    largestIndex = 2 * loc + 2;
                else
                    largestIndex = 2 * loc + 1;
                if (heap[loc].importance < heap[largestIndex].importance)
                {
                    hold = heap[loc];
                    heap[loc] = heap[largestIndex];
                    heap[largestIndex] = hold;
                    reheapDown(heap, largestIndex, last);
                }
            }
        }
        /// <summary>
        /// Removes the largest option each time, until nothing is left
        /// </summary>
        /// <param name="heap"></param>
        /// <param name="last"></param>
        /// <param name="dataOut"></param>
        private void deleteHeap(node[] heap, ref int last, ref string dataOut)
        {
            if (last >= 0)
            {
                dataOut = heap[0].putterTrait;
                heap[0] = heap[last];
                last--;
                reheapDown(heap, 0, last);
            }
        }
        //Iputter Interface implementation
        public string putterShape { get; set; }
        public string putterBalance { get; set; }
        public string putterHosel { get; set; }
        public string putterWeight { get; set; }
        public string putterFeel { get; set; }
        public string putterLink { get; set; }
        public void setCharacteristic(params string[] putterName)
        {
            for (int a = 0; a < data.Length; a++) //data is the list of putters that fit, not data passed in
            {
                if (data[a].Contains(putterName[0]))
                {
                    putterShape = data[a].Split('\u00BB')[1];
                    putterBalance = data[a].Split('\u00BB')[2];
                    putterHosel = data[a].Split('\u00BB')[3];
                    putterWeight = data[a].Split('\u00BB')[4];
                    putterFeel = data[a].Split('\u00BB')[5];
                    if (data[a].Split('\u00BB')[6] != "")
                    {
                        putterLink = data[a].Split('\u00BB')[6];
                    }
                    else
                    {
                        putterLink = null;
                    }
                }
            }
        }
        /// <summary>
        /// Collects data in order of importance, removes length and grip from list
        /// The length and grip are universal, so they are not necessary in finding putter
        /// </summary>
        /// <param name="heap"></param>
        /// <param name="last"></param>
        public PutterData(node[] heap, int last)
        {
            int a = 0, l = last;
            deleteHeap(heap, ref l, ref PutterLength);
            deleteHeap(heap, ref l, ref PutterGrip);

            while (l >= 0)
            {
                putterCharacteristics[a] = "";
                deleteHeap(heap, ref l, ref putterCharacteristics[a]);
                a++;
            }
        }
        public string PutterLength;
        public string PutterGrip;
        public string[] putterFits;
        private string[] putterCharacteristics = new string[5];
        private string[] data; //holds the unsplit data for matching putters
        SaveData putters = new SaveData();

        /// <summary>
        /// Calls the data function, and finds from the data all the matching characteristics
        /// the data function keeps removing data until all the characteristics are checked
        /// or nothing is left, then it goes back one characteristic and returns that
        /// </summary>
        public void GetPutter()
        {
            data = putters.accessData(putterCharacteristics);
            putterFits = new string[data.Length];
            for (int a = 0; a < data.Length; a++)
            {
                string[] temp = data[a].Split('\u00BB');
                putterFits[a] = temp[0];
            }
        }
    }
}