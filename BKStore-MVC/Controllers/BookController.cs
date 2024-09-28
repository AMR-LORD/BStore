﻿using BKStore_MVC.Models;
using BKStore_MVC.Repository;
using BKStore_MVC.Repository.Interfaces;
using BKStore_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BKStore_MVC.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;

        ICategoryRepository categoryRepository;
        public BookController(IBookRepository _bookRepository, ICategoryRepository _categoryRepository)
        {
            bookRepository = _bookRepository;
            categoryRepository = _categoryRepository;
        }

        public IActionResult Index()
        {
            return View("Index", bookRepository.GetAll());  
        } // Show All Books

        public  IActionResult Details(int Bookid)
        {
             Book book =  bookRepository.GetByID(Bookid);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            Category category = categoryRepository.GetByID(book.CategoryID);

            BookWithAuthorWithPuplisherWithCategVM bookVM =
                new BookWithAuthorWithPuplisherWithCategVM();

            // Pass Book Props to Book View Model Class
            bookVM.BookID = book.BookID;
            bookVM.BookImagePath = book.ImagePath;
            bookVM.Title = book.Title;
            bookVM.Price = book.Price;
            bookVM.StockQuantity = book.StockQuantity;
            bookVM.Description = book.Description;
            bookVM.CategoryID = category.CategoryID;
            bookVM.CategoryName = category.Name;

            return View("Details", bookVM);
        } // Show Book by id

        [HttpGet]
        public IActionResult New()
        {
            ViewData["Categories"] = categoryRepository.GetAll();
           //  ViewData["DeptList"] =DepartmentRepository.GetAll();

            return View("New");
        } // Add New Book

        [HttpPost]
        public IActionResult SaveNew(Book bookFromRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //save
                    bookRepository.Add(bookFromRequest);
                    bookRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }
            ViewData["CategoryName"] = categoryRepository.GetAll();

            return RedirectToAction("New", bookFromRequest);
        } // Save Data

        public IActionResult Edit(int id)
        {
           Book bookModel =  bookRepository.GetByID(id);

            BookWithAuthorWithPuplisherWithCategVM bookVM =
                new BookWithAuthorWithPuplisherWithCategVM();

            bookVM.BookID = bookModel.BookID;
            bookVM.Title = bookModel.Title;
            bookVM.AuthorName = bookModel.AuthorName;
            bookVM.StockQuantity = bookModel.StockQuantity;
            bookVM.Price = bookModel.Price;
            bookVM.BookImagePath = bookModel.ImagePath;
            bookVM.categories = categoryRepository.GetAll(); 
            bookVM.PublisherName = bookModel.PublisherName;
            bookVM.Description = bookModel.Description;
            bookVM.CategoryID = bookModel.CategoryID;
            bookVM.categories = categoryRepository.GetAll();

            return View("Edit", bookVM);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, BookWithAuthorWithPuplisherWithCategVM bookFromRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Book bookFromDB = 
                        bookRepository.GetByID(id);

                    bookFromDB.Title = bookFromRequest.Title;
                    bookFromDB.AuthorName = bookFromRequest.AuthorName;
                    bookFromDB.StockQuantity = bookFromRequest.StockQuantity;
                    bookFromDB.Price = bookFromRequest.Price;
                    bookFromDB.PublisherName = bookFromRequest.PublisherName;
                    bookFromDB.Description = bookFromRequest.Description;
                    bookFromDB.ImagePath = bookFromRequest.BookImagePath;
                    bookFromDB.CategoryID = bookFromRequest.CategoryID;

                    bookRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }

            bookFromRequest.categories = categoryRepository.GetAll();
            return View("Edit", bookFromRequest);
        }







    }
}
