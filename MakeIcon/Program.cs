using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Drawing;

namespace ConsoleApplication1
{
    class Program
    {
        public static string projectName;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Project Name:\n");
            projectName = Console.ReadLine();
            System.IO.Directory.CreateDirectory("output/"+projectName);



            string allText =  File.ReadAllText("data/data.csv");
            //Console.WriteLine(allText);

            string[] split = allText.Split('\n');
            foreach (var item in split)
            {
                Console.WriteLine(item + "\n\n");

                string[] parts = item.Split(',');
                try
                {
                    System.IO.Directory.CreateDirectory("output/" + projectName + "/" + parts[6]);
                    makeImage(parts[0], Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), parts[5], parts[6]);
                }
                catch 
                {
                    
                    
                }
                
            }


            //Console.ReadLine();
        }

        static public void makeImage(string Name, int Width, int Height, string CompleteName, string Folder)
        {

            Image image = new Bitmap("data/test.png");

            Image rsz = resizeImage(image, new Size(Width, Height));

            rsz.Save("output/" + projectName + "/" + Folder + "/" + CompleteName);

        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }


    }
}