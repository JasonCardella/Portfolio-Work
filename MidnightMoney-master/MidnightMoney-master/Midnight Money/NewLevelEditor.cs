using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class NewLevelEditor
{
    private string[,] myArray;
    public NewLevelEditor()
	{

	}
    public void Reader()
    {
        StreamReader reader = null;
        try
        {
            foreach(string line in File.ReadLines(@"LevelFile.txt"))
            {
                Console.WriteLine(line);
            }
            File.WriteAllLines(@"LevelFile.txt", myArray);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error with file : " + ex.Message);
        }
        finally
        {
            if(reader != null)
            {
                reader.Close();
            }
        }
    }
    
}
