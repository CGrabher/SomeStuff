using System;
using System.Linq;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
//Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();

//All Blogs
var allBlogs = db.Blogs.ToList();
foreach (var oneBlog in allBlogs)
{
    Console.WriteLine($"Blog URL: {blog.Url}");
}

//Query blogs with specific criteria
var filteredBlogs = db.Blogs
    .Where(b => b.Url.Contains("dotnet"))
    .ToList();
foreach (var oneBlog in filteredBlogs)
{
    Console.WriteLine($"Blog URL: {blog.Url}");
}

//Update a single blog entry
var blogToUpdate = db.Blogs.FirstOrDefault(b => b.BlogId == 5);
if (blogToUpdate != null)
{
    blogToUpdate.Url = "https://updated-blog-url.com";
    db.SaveChanges();
}

//Adding a new post to a specific blog
var blogToAddPost = db.Blogs.FirstOrDefault(b => b.BlogId == 5);
if (blogToAddPost != null)
{
    blogToAddPost.Posts.Add(new Post { Title = "New Post", Content = "This is a new post." });
    db.SaveChanges();
}

//Delete a single blog entry
var postToDelete = db.Posts.FirstOrDefault(p => p.PostId == 1);
if (postToDelete != null)
{
    db.Posts.Remove(postToDelete);
    db.SaveChanges();
}

