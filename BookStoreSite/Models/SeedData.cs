
using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreSite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BookStoreSite.Data
{
    public static class SeedData
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookStoreSiteContext>();

                context.Database.EnsureCreated();

                if (!context.Books.Any())    // Check if the database contains any books
                {
                    try
                    {
                        context.Books.AddRange(new List<Book>
                        {
                            new Book
                            {
                                Title = "The Great Gatsby",
                                 Description= "Story",
                                Language = "English",
                                ISBN = "9780743273565",
                                DatePublished = DateTime.Parse("1925-4-10"),
                                Price = 10,
                                Author = "F. Scott Fitzgerald",
                                ImageUrl = "/images/great-gatsby.jpg"
                            },

                            new Book
                            {
                                Title = "To Kill a Mockingbird",
                                 Description= "Story",
                                Language = "English",
                                ISBN = "9780061120084",
                                DatePublished = DateTime.Parse("1960-7-11"),
                                Price = 12,
                                Author = "Harper Lee",
                                ImageUrl = "/images/to-kill-a-mockingbird.jpg"
                            },

                            new Book
                            {
                                Title = "1984",
                                Description= "Story",
                                Language = "English",
                                ISBN = "9780451524935",
                                DatePublished = DateTime.Parse("1949-6-8"),
                                Price = 8,
                                Author = "George Orwell",
                                ImageUrl = "/images/1984.jpg"
                            },new Book
                    {
                        Title = "Bröderna Lejonhjärta",
                         Description= "Story",
                        Language = "Swedish",
                        ISBN = "9789129688313",
                        DatePublished = DateTime.Parse("2013-9-26"),
                        Price = 139,
                        Author = "Astrid Lindgren",
                        ImageUrl = "/images/lejonhjärta.jpg"
                    },

                    new Book
                    {
                        Title = "The Fellowship of the Ring",
                         Description= "Story",
                        Language = "English",
                        ISBN = "9780261102354",
                        DatePublished = DateTime.Parse("1991-7-4"),
                        Price = 100,
                        Author = "J. R. R. Tolkien",
                        ImageUrl = "/images/lotr.jpg"
                    },

                    new Book
                    {
                        Title = "Mystic River",
                        Language = "English",
                         Description= "Story",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("2011-6-1"),
                        Price = 91,
                        Author = "Dennis Lehane",
                        ImageUrl = "/images/mystic-river.jpg"
                    },

                    new Book
                    {
                        Title = "Of Mice and Men",
                         Description= "Story",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-1-2"),
                        Price = 166,
                        Author = "John Steinbeck",
                        ImageUrl = "/images/of-mice-and-men.jpg"
                    },

                    new Book
                    {
                        Title = "The Old Man and the Sea",
                         Description= "Story",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-8-18"),
                        Price = 84,
                        Author = "Ernest Hemingway",
                        ImageUrl = "/images/old-man-and-the-sea.jpg"
                    },

                    new Book
                    {
                        Title = "The Road",
                         Description= "Story",
                        Language = "English",
                        ISBN = "9780307386458",
                        DatePublished = DateTime.Parse("2007-5-1"),
                        Price = 95,
                        Author = "Cormac McCarthy",
                        ImageUrl = "/images/the-road.jpg"
                    }
                

                    });

                        context.SaveChanges();
                        Console.WriteLine("Database seeded successfully!");
                    }
                    catch (DbUpdateException ex)
                    {
                        // Log the details of the exception
                        Console.WriteLine($"Error saving changes to the database: {ex.Message}");
                        Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                        throw;  // rethrow the exception to signal the failure
                    }
                }
            }
        }
    }
}
