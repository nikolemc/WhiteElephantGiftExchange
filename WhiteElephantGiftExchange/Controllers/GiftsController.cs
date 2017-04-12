﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhiteElephantGiftExchange.Models;
using WhiteElephantGiftExchange.Services;

namespace WhiteElephantGiftExchange.Controllers
{
    public class GiftsController : Controller
    {
        // GET: Gifts
        public ActionResult Index()
        {

            // get all gifts
            var gifts = new GiftServices().GetAllGifts();
            // pass them to the view
            return View(gifts);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var Contents = collection["Contents"];
            var GiftHint = collection["GiftHint"];
            var WrappingPaperColor = collection["WrappingPaperColor"];
            var Height = collection["Height"];
            var Width = collection["Width"];
            var Depth = collection["Depth"];
            var Weight = collection["Weight"];
            var IsOpened = collection["IsOpened"];
            var newGift = new Gifts // adding gift 
            {
                Contents = Contents,
                GiftHint = GiftHint,
                WrappingPaperColor = WrappingPaperColor,
                Height = double.Parse(Height),
                Width = double.Parse(Width),
                Depth = double.Parse(Depth),
                Weight = double.Parse(Weight),
                IsOpened = bool.Parse(IsOpened),

            };

            var updateGift = new Gifts //update gift
            {
                Contents = Contents,
                GiftHint = GiftHint,
                WrappingPaperColor = WrappingPaperColor,
                Height = double.Parse(Height),
                Width = double.Parse(Width),
                Depth = double.Parse(Depth),
                Weight = double.Parse(Weight),
                IsOpened = bool.Parse(IsOpened),

            };
            // make a new gift with these ^^^
            // send that gift to the db with a method/service
            new GiftServices().AddGift(newGift);

            // TODO: Put into our database
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var gift = new GiftServices().GetGift(Id);
            return View(gift);
        }

        [HttpPost] //edit the gifts in the database
        public ActionResult Edit(int Id, FormCollection collection)
        {
         
            //Gifts gift = GetGiftFromDatabase(Id);
            var Contents = collection["Contents"];
            var GiftHint = collection["GiftHint"];
            var WrappingPaperColor = collection["WrappingPaperColor"];
            var Height = collection["Height"];
            var Width = collection["Width"];
            var Depth = collection["Depth"];
            var Weight = collection["Weight"];
            var IsOpened = collection["IsOpened"];
            var newGift = new Gifts // adding gift 
            {
                Id = Id,
                Contents = Contents,
                GiftHint = GiftHint,
                WrappingPaperColor = WrappingPaperColor,
                Height = double.Parse(Height),
                Width = double.Parse(Width),
                Depth = double.Parse(Depth),
                Weight = double.Parse(Weight),
                IsOpened = bool.Parse(IsOpened),
            };

            new GiftServices().UpdateGift(newGift);
            return RedirectToAction("Index");

            //try
            //{
            //    new GiftServices().UpdateGift(newGift);
            //    return RedirectToAction("Edit");
            //}

            //catch
            //{
            //    return View(newGift);
            //}
        }

    }
}