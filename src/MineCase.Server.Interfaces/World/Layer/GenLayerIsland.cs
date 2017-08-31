using System;
using System.Collections.Generic;
using System.Text;

namespace MineCase.Server.World.Layer
{
    public class GenLayerIsland : GenLayer
    {
        public GenLayerIsland(int seed)
            : base(seed)
        {
        }

        /**
        * Returns a list of integer values generated by this layer. These may be interpreted as temperatures, rainfall
        * amounts, or Biome ID's based on the particular GenLayer subclass.
        */
        public override int[] GetInts(int areaX, int areaY, int areaWidth, int areaHeight)
        {
            int[] aint = new int[areaWidth * areaHeight];

            for (int i = 0; i < areaHeight; ++i)
            {
                for (int j = 0; j < areaWidth; ++j)
                {
                    InitChunkSeed(areaX + j, areaY + i);
                    aint[j + i * areaWidth] = NextInt(10) == 0 ? 1 : 0;
                }
            }

            if (areaX > -areaWidth && areaX <= 0 && areaY > -areaHeight && areaY <= 0)
            {
                aint[-areaX + -areaY * areaWidth] = 1;
            }

            return aint;
        }
    }
}