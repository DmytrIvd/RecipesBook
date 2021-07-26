using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipesBook.DataManagers
{
    public class CategoryManager : AbsractDataManager<Category>
    {

        public CategoryManager()
        {

        }

        public override Category Get(object key, bool loadReferences = false)
        {
            if (key != null)
            {
                var category = base.Get(key, loadReferences);

                return category;
            }
            return null;
        }
        public override Category Get(Func<Category, bool> predicate, bool loadReferences = false)
        {
            var category = base.Get(predicate, loadReferences);

            return category;
        }

        public override IList<Category> GetEntities<Parameter>(bool loadReferences = false, Func<Category, Parameter> SortPredicate = null)
        {
            var category = base.GetEntities(loadReferences, SortPredicate);

            return category;
        }

        protected override void Seed()
        {
            //string filename = "./wwwroot/images/NotFound.png";
            //byte[] bytes = null;
            //using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            //{
            //    // Create a byte array of file stream length
            //    bytes = System.IO.File.ReadAllBytes(filename);
            //    //Read block of bytes from stream into the byte array
            //    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            //    //Close the File Stream
            //    fs.Close();
            //}
            //Entities.Add(new Category()
            //{
            //    Id = "1",
            //    IsHidden = false,
            //    Name = "Супи",
            //    Description = "description1",
            //    DateOfAdd = DateTime.Now,
            //    MainImage = bytes,
            //    Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            //});
            //Entities.Add(new Category()
            //{
            //    Id = "2",
            //    IsHidden = false,
            //    Name = "Каші",
            //    Description = "description2",
            //    DateOfAdd = DateTime.Now,
            //    MainImage = bytes,
            //    Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            //});
            //Entities.Add(new Category()
            //{
            //    Id = "3",
            //    IsHidden = false,
            //    Name = "Салати",
            //    Description = "description3",
            //    DateOfAdd = DateTime.Now,
            //    MainImage = bytes,
            //    Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            //});
            //Entities.Add(new Category()
            //{
            //    Id = "4",
            //    IsHidden = false,
            //    Name = "Рецепти за 15 хвилин",
            //    Description = "description4",
            //    DateOfAdd = new DateTime(2020, 3, 21),
            //    MainImage = bytes,
            //    Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            //});
            //Entities.Add(new Category()
            //{
            //    Id = "5",
            //    IsHidden = true,
            //    Name = "Мясо",
            //    Description = "description5",
            //    DateOfAdd = DateTime.Now,
            //    MainImage = bytes,
            //    Recipes = new Recipe[] { new Recipe() { Id = "1" }, new Recipe() { Id = "2" }, new Recipe() { Id = "3" }, new Recipe() { Id = "4" }, new Recipe() { Id = "5" } }
            //});
        }
    }
}
