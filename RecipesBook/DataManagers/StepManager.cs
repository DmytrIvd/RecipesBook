using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace RecipesBook.DataManagers
{
    public class StepManager : AbsractDataManager<Step>
    {
        protected override void Seed()
        {
            string filename = "./wwwroot/images/NotFound.png";
            byte[] bytes = null;
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                // Create a byte array of file stream length
                bytes = System.IO.File.ReadAllBytes(filename);
                //Read block of bytes from stream into the byte array
                fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
                //Close the File Stream
                fs.Close();
            }
            Entities.Add(new Step() { Id = "1", Text = "Do this fisrt", Img = bytes });
            Entities.Add(new Step() { Id = "2", Text = "Do this secound", Img = bytes });
            Entities.Add(new Step() { Id = "3", Text = "Do this third", Img = bytes });
            Entities.Add(new Step() { Id = "4", Text = "Do this fourth", Img = bytes });
            Entities.Add(new Step() { Id = "5", Text = "Do this fifth", Img = bytes });
            Entities.Add(new Step() { Id = "6", Text = "Do this sixth", Img = bytes });
            Entities.Add(new Step() { Id = "7", Text = "Do this seventh", Img = bytes });
            Entities.Add(new Step() { Id = "8", Text = "Do this eighth", Img = bytes });

        }
    }
}
