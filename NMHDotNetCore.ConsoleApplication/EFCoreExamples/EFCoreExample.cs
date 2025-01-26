using NMHDotNetCore.ConsoleApplication.AppDbContexts;
using NMHDotNetCore.ConsoleApplication.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHDotNetCore.ConsoleApplication.EFCoreExamples
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();

        public void Run()
        {
            //Read();
            //Create("VideoEditing", "Ryan", "How to use Tools");
            Update(1, "Internet 2", "Ryan 2", "How to use Internet 2");
            //Delete(1);
        }

        private void Read()
        {
            var Lst = db.Blogs.ToList();

            foreach (BlogModel item in Lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("--------------------");
            }
        }

        private void Create(string Title, string Author, string Content)
        {
            var item = new BlogModel()
            {
                BlogTitle = Title,
                BlogAuthor = Author,
                BlogContent = Content
            };

            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Create Successfully" : "Fail to create";
            Console.WriteLine(message);
        }

        private void Update(int Id, string Title, string Author, string Content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.Id == Id);
            if (item is null) {
                Console.WriteLine("No data found.");
                return;
            }

            item.BlogTitle = Title;
            item.BlogAuthor = Author;
            item.BlogContent = Content;
            int result = db.SaveChanges();

            string message = result > 0 ? "Update Successfully" : "Fail to update";
            Console.WriteLine(message);
        }

        private void Delete(int Id) 
        {
            var item = db.Blogs.FirstOrDefault(x => x.Id == Id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            db.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successfully" : "Fail to delete";
            Console.WriteLine(message);
        }
    }
}
