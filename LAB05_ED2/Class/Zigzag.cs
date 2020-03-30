using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace LAB05_ED2.Class
{
    public class Zigzag
    {

        //PUBLIC FUNCTION

        public void Encode(string rPath, string wPath, int key)
        {
            string[] ZigZag;
            using (FileStream Rfile = new FileStream(rPath, FileMode.Open))
            using (BinaryReader BR = new BinaryReader(Rfile))
            {
                ZigZag = EText(BR, key);
            }
            using (FileStream Wfile = new FileStream(wPath, FileMode.Create))
            using (BinaryWriter BW = new BinaryWriter(Wfile))
            {
                WCText(ref ZigZag, BW, key);
            }
        }// End method for encode the algorith zig zag


        //END PUBLIC FUNCTIONS


        //PRIVATE FUNCTIONS

        private string[] EText(BinaryReader br, int key)
        {
            string[] ZigZag = new string[key];
            ZigZag.Initialize();

            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                int current = 0;
                while (br.BaseStream.Position != br.BaseStream.Length && current < key - 1)
                {
                    ZigZag[current] += br.ReadChar();
                    current++;
                }

                while (br.BaseStream.Position != br.BaseStream.Length && current > 0)
                {
                    ZigZag[current] += br.ReadChar();
                    current--;
                }
            }
            return ZigZag;
        }//End method for encrypted text for encode

        private void WCText(ref string[] ZigZag, BinaryWriter bw, int Key)
        {
            for (int i = 0; i < Key; i++) if (ZigZag[i] != null) bw.Write(Encoding.UTF8.GetBytes(ZigZag[i]));
        }//End method for write cyphed text in encode



        //END PRIVATE FUNCTIONS
    }
}
