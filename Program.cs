using System;
using System.Linq;
using Class_10.Models;

namespace Class_10
{
    class Program
    {
        static void Main(string[] args)
        {   
            int choice;

            do
            {
                System.Console.WriteLine("What would you like to do?\n1. Display Blogs\n2. Add Blog\n" + 
                "3. Display Posts\n4. Add Post\n5. Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    // read blogs
                    using(var db = new BlogContext())
                    {
                        System.Console.WriteLine("here is the list of blogs");
                        foreach (var blogerinos in db.Blogs)
                        {
                            System.Console.WriteLine($"Blog: {blogerinos.BlogId}: {blogerinos.Name}");
                        }
                    }
                } else if (choice == 2)
                {
                    System.Console.WriteLine("Enter blog name:");
                    var blogName = Console.ReadLine();

                    // create new blog
                    var blog = new Blog();
                    blog.Name = blogName;

                    // save the blog object to database
                    using(var db = new BlogContext())
                    {
                        db.Add(blog);
                        db.SaveChanges();
                    }
                } else if (choice == 3)
                {
                    // list post for blog
                    using (var db = new BlogContext())
                    {
                        var bloogies = db.Blogs;
                        var posts = db.Posts.ToList();
                        
                        System.Console.WriteLine("here is the list of blogs");
                        foreach (var blogerinos in db.Blogs)
                        {
                            System.Console.WriteLine($"Blog: {blogerinos.BlogId}: {blogerinos.Name}");
                        }
                        System.Console.WriteLine("which blogs posts would you like to see?");
                        var blogPostsSelected = Convert.ToInt32(Console.ReadLine());

                        posts = posts.Where(l => l.BlogId == blogPostsSelected).ToList();

                        var blogForPost = bloogies.Where(s => s.BlogId == blogPostsSelected).FirstOrDefault();

                        var x = new Post();
                        x.BlogId = blogPostsSelected;

                        foreach (var posties in posts)
                        {
                            System.Console.WriteLine($"Blog: {blogForPost.Name} Posts: {posties.Title} {posties.Content}");
                        }

                    }
                } else if (choice == 4)
                {
                    // lists posts to figure out which one they want to add it to.
                    using(var db = new BlogContext())
                    {
                        System.Console.WriteLine("here is the list of blogs");
                        foreach (var blogerinos in db.Blogs)
                        {
                            System.Console.WriteLine($"Blog: {blogerinos.BlogId}: {blogerinos.Name}");
                        }
                    }

                    System.Console.WriteLine("What blog would you like to add your post to");
                    var selection = Convert.ToInt32(Console.ReadLine());

                    //add posts
                    System.Console.WriteLine("Enter post titles");
                    var postTitle = Console.ReadLine();

                    System.Console.WriteLine("enter the content of the post");
                    var content = Console.ReadLine();


                    var post = new Post();
                    post.Title = postTitle;
                    post.BlogId = selection;
                    post.Content = content;

                    using (var db = new BlogContext())
                    {
                        db.Add(post);
                        db.SaveChanges();
                    }
                }

            } while (choice != 5);
            
        }
    }
}
