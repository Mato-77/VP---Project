﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class Hard :Level
    {
        public Hard(int numBlocks): base(numBlocks,90) {
            Timing = 1500;
        }

        public override void strategy()
        {
            List<string> temp = new List<string>(HiddenInformation);
            List<int> numeredBlocks = this.getNumeredBlocks();

            for (int i = 0; i < HiddenInformation.Count; i++)
            {
                string info = temp[Random.Next(temp.Count)];
                int first = numeredBlocks.ElementAt(Random.Next(numeredBlocks.Count));
                numeredBlocks.Remove(first);
                int second = numeredBlocks.ElementAt(Random.Next(numeredBlocks.Count));
                numeredBlocks.Remove(second);
                Blocks[first].Information = info;
                Blocks[second].Information = info;
                temp.Remove(info);

            }
        }

        public override void punishment()
        {

            Timer -= 15;
           
            Points -= 100;
            foreach (Block block in Blocks)
                block.Opened = false;
            HittedBlocks.Clear();
            
            resetIndexes();

            
        }
    }
}
