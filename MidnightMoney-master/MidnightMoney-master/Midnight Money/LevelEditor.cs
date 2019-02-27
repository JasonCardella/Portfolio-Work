using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
 
namespace Midnight_Money
{
    class LevelEditor
    {


        private const int arrayHeight = 24; // ORIGINALLY 6
        private const int arrayWidth = 40;  // ORIGINALLY 10
        private string[] myArray = new string[arrayHeight];
        private string[,] my2dArray = new string[arrayWidth, arrayHeight];
        private List<Environment> crates;
        public List<Environment> ListCrates{ get { return crates; } set { crates = value; } }
        
        public LevelEditor()
        {
            crates = new List<Environment>();
        }
        
        public void Reader()
        {
            StreamReader reader = null;
            try
            {   
                int count = 0;
              foreach (string line in File.ReadLines(@"../../../../LevelFile1.txt"))
              {
                    string s = line;
                    char[] mychars = s.ToCharArray();
                    for(int i = 0; i < s.Length ; i++)
                    {
                        my2dArray[i, count] = mychars[i].ToString();
                    }
                    count++;
              }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error with file : " + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            
        }

        public List<Environment> PopulateCrateList(int viewWidth, int viewHeight,Texture2D crateTex)
        {
            for(int i = 0; i < arrayWidth; i++)
            {
                for(int j = 0; j < arrayHeight; j++)
                {
                    if(my2dArray[i,j] == "X")
                    {
                        Rectangle positionCrate = new Rectangle(i*(viewWidth/arrayWidth), j*(viewHeight/arrayHeight), 20,20);
                        Environment crate = new Environment(positionCrate, crateTex);
                        crates.Add(crate);
                    }
                }
            }
            return crates;
        }
        //we know that at (x,y) ex. 10,10 is wall,
        //so now multiple that x,y by screen factor
        public string[,] GetArray
        {
            get{ return my2dArray;}
        }

        public int GetArrayHeight
        {
            get{ return arrayHeight;}
        }
        public int GetArrayWidth
        {
            get{ return arrayWidth;}
        }
        public int SpriteCount()
{
            return -1;
            //returns number of sprites
}

        public int Xincrease(int screenWidth)
{
            //the amount x increases by each time a sprite is drawn
            int xinc = screenWidth/ arrayWidth;
            return xinc;
}

        public int Yincrease(int screenHeight) //put GraphicsDevice.ViewPort.Height
            //the amount y increases each time a sprite is drawn
{
            int yinc = screenHeight/ arrayHeight; //value to increase y by each time
            return yinc;
}

    }
}
