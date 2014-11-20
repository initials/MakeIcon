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
            Bitmap src = Image.FromFile("data/test.png") as Bitmap;
            if (src.Width < Width)
            {
                Console.WriteLine("Resizing");
                src = (Bitmap)resizeImage(src, new Size(src.Width * 2, src.Height * 2));
            }



            Image rsz = resizeImage(image, new Size(Width, Height));

            Rectangle cropRect = new Rectangle((src.Width/2) - (Width/2),(src.Height/2) - (Height/2),Width,Height);
            



            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using(Graphics g = Graphics.FromImage(target))
            {
               g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), 
                                cropRect,                        
                                GraphicsUnit.Pixel);
                target.Save("output/" + projectName + "/" + Folder + "/" + CompleteName); 
            }

            rsz.Save("output/" + projectName + "/" + Folder + "/RSZ_" + CompleteName);

        }



        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }


    }
}