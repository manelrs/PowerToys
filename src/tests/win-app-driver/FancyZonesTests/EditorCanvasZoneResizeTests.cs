﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;

namespace PowerToysTests
{
    [TestClass]
    public class FancyZonesEditorCanvasZoneResizeTests : FancyZonesEditor
    {
        private void MoveCorner(WindowsElement corner, bool shiftLeft, bool shiftUp, int xOffset, int yOffset)
        {
            int shiftX = shiftLeft ? -(corner.Rect.Width / 2) + 1 : (corner.Rect.Width / 2) - 1;
            int shiftY = shiftUp ? -(corner.Rect.Height / 2) + 1 : (corner.Rect.Height / 2) - 1;
            
            new Actions(session).MoveToElement(corner)
                .MoveByOffset(shiftX, shiftY)
                .ClickAndHold().MoveByOffset(xOffset, yOffset).Release().Perform();
        }

        [TestMethod]
        public void MoveTopBorder()
        {
            WindowsElement topBorder = session.FindElementByAccessibilityId("NResize");
            WindowsElement bottomBorder = session.FindElementByAccessibilityId("SResize");
            Assert.IsNotNull(topBorder);
            Assert.IsNotNull(bottomBorder);

            //up
            new Actions(session).MoveToElement(topBorder).ClickAndHold().MoveByOffset(0, -5000).Release().Perform();
            Assert.IsTrue(topBorder.Rect.Y >= 0);

            //down
            new Actions(session).MoveToElement(topBorder).ClickAndHold().MoveByOffset(0, 5000).Release().Perform();
            Assert.IsTrue(topBorder.Rect.Y <= bottomBorder.Rect.Y);
        }

        [TestMethod]
        public void MoveBottomBorder()
        {
            WindowsElement topBorder = session.FindElementByAccessibilityId("NResize");
            WindowsElement bottomBorder = session.FindElementByAccessibilityId("SResize");
            Assert.IsNotNull(topBorder);
            Assert.IsNotNull(bottomBorder);

            //up
            new Actions(session).MoveToElement(bottomBorder).ClickAndHold().MoveByOffset(0, -5000).Release().Perform();
            Assert.IsTrue(topBorder.Rect.Y <= bottomBorder.Rect.Y);

            //down
            new Actions(session).MoveToElement(bottomBorder).ClickAndHold().MoveByOffset(0, 5000).Release().Perform();
            Assert.IsTrue(bottomBorder.Rect.Y <= Screen.PrimaryScreen.WorkingArea.Bottom);
        }

        [TestMethod]
        public void MoveLeftBorder()
        {
            WindowsElement leftBorder = session.FindElementByAccessibilityId("WResize");
            WindowsElement rightBorder = session.FindElementByAccessibilityId("EResize");
            Assert.IsNotNull(leftBorder);
            Assert.IsNotNull(rightBorder);

            //to the left
            new Actions(session).MoveToElement(leftBorder).ClickAndHold().MoveByOffset(-5000, 0).Release().Perform();
            Assert.IsTrue(leftBorder.Rect.Y <= Screen.PrimaryScreen.WorkingArea.Bottom);

            //to the right
            new Actions(session).MoveToElement(leftBorder).ClickAndHold().MoveByOffset(5000, 0).Release().Perform();
            Assert.IsTrue(leftBorder.Rect.X <= rightBorder.Rect.X);
        }
        
        [TestMethod]
        public void MoveRightBorder()
        {
            WindowsElement leftBorder = session.FindElementByAccessibilityId("WResize");
            WindowsElement rightBorder = session.FindElementByAccessibilityId("EResize");
            Assert.IsNotNull(leftBorder);
            Assert.IsNotNull(rightBorder);

            //to the left
            new Actions(session).MoveToElement(rightBorder).ClickAndHold().MoveByOffset(-5000, 0).Release().Perform();
            Assert.IsTrue(leftBorder.Rect.X <= rightBorder.Rect.X); 
            
            //to the right
            new Actions(session).MoveToElement(rightBorder).ClickAndHold().MoveByOffset(5000, 0).Release().Perform();
            Assert.IsTrue(leftBorder.Rect.X <= Screen.PrimaryScreen.WorkingArea.Right);
        }

        [TestMethod]
        public void MoveTopLeftCorner()
        {
            WindowsElement topLeftCorner = session.FindElementByAccessibilityId("NWResize");
            WindowsElement bottomBorder = session.FindElementByAccessibilityId("SResize");
            WindowsElement rightBorder = session.FindElementByAccessibilityId("EResize");
            Assert.IsNotNull(topLeftCorner);
            Assert.IsNotNull(bottomBorder);
            Assert.IsNotNull(rightBorder);

            //up
            MoveCorner(topLeftCorner, true, true, 0, -5000);
            Assert.IsTrue(topLeftCorner.Rect.Y >= 0);

            //down
            MoveCorner(topLeftCorner, true, true, 0, 5000);
            Assert.IsTrue(topLeftCorner.Rect.Y <= bottomBorder.Rect.Y);

            //up-left
            MoveCorner(topLeftCorner, true, true, -5000, -5000);
            Assert.IsTrue(topLeftCorner.Rect.Y >= 0);
            Assert.IsTrue(topLeftCorner.Rect.X >= 0);

            //up-right
            MoveCorner(topLeftCorner, true, true, 5000, -5000);
            Assert.IsTrue(topLeftCorner.Rect.Y >= 0);
            Assert.IsTrue(topLeftCorner.Rect.X <= rightBorder.Rect.X);

            //to the left
            MoveCorner(topLeftCorner, true, true, -5000, 0);
            Assert.IsTrue(topLeftCorner.Rect.X >= 0);

            //to the right
            MoveCorner(topLeftCorner, true, true, 5000, 0);
            Assert.IsTrue(topLeftCorner.Rect.X <= rightBorder.Rect.X);

            //down-left
            MoveCorner(topLeftCorner, true, true, -5000, 5000);
            Assert.IsTrue(topLeftCorner.Rect.Y <= bottomBorder.Rect.Y);
            Assert.IsTrue(topLeftCorner.Rect.X >= 0);

            //down-right
            MoveCorner(topLeftCorner, true, true, 5000, 5000);
            Assert.IsTrue(topLeftCorner.Rect.Y <= bottomBorder.Rect.Y);
            Assert.IsTrue(topLeftCorner.Rect.X <= rightBorder.Rect.X);
        }

        [TestMethod]
        public void MoveTopRightCorner()
        {
            WindowsElement topRightCorner = session.FindElementByAccessibilityId("NEResize");
            WindowsElement bottomBorder = session.FindElementByAccessibilityId("SResize");
            WindowsElement leftBorder = session.FindElementByAccessibilityId("WResize");
            Assert.IsNotNull(topRightCorner);
            Assert.IsNotNull(bottomBorder);
            Assert.IsNotNull(leftBorder);

            //up
            MoveCorner(topRightCorner, false, true, 0, -5000);
            Assert.IsTrue(topRightCorner.Rect.Y >= 0);

            //down
            MoveCorner(topRightCorner, false, true, 0, 5000);
            Assert.IsTrue(topRightCorner.Rect.Y <= bottomBorder.Rect.Y);

            //up-left
            MoveCorner(topRightCorner, false, true, -5000, -5000);
            Assert.IsTrue(topRightCorner.Rect.Y >= 0);
            Assert.IsTrue(topRightCorner.Rect.X >= leftBorder.Rect.X);

            //up-right
            MoveCorner(topRightCorner, false, true, 5000, -5000);
            Assert.IsTrue(topRightCorner.Rect.Y >= 0);
            Assert.IsTrue(leftBorder.Rect.X <= Screen.PrimaryScreen.WorkingArea.Right);

            //to the left
            MoveCorner(topRightCorner, false, true, -5000, 0);
            Assert.IsTrue(topRightCorner.Rect.X >= leftBorder.Rect.X);

            //to the right
            MoveCorner(topRightCorner, false, true, 5000, 0);
            Assert.IsTrue(leftBorder.Rect.X <= Screen.PrimaryScreen.WorkingArea.Right);

            //down-right
            MoveCorner(topRightCorner, false, true, 5000, 5000);
            Assert.IsTrue(topRightCorner.Rect.Y <= bottomBorder.Rect.Y);
            Assert.IsTrue(leftBorder.Rect.X <= Screen.PrimaryScreen.WorkingArea.Right);

            //down-left
            MoveCorner(topRightCorner, false, true, -5000, 5000);
            Assert.IsTrue(topRightCorner.Rect.Y <= bottomBorder.Rect.Y);
            Assert.IsTrue(topRightCorner.Rect.X >= leftBorder.Rect.X);
        }

        [TestMethod]
        public void MoveBottomLeftCorner()
        {
            WindowsElement bottomLeftCorner = session.FindElementByAccessibilityId("SWResize");
            WindowsElement topBorder = session.FindElementByAccessibilityId("NResize");
            WindowsElement rightBorder = session.FindElementByAccessibilityId("EResize");
            Assert.IsNotNull(bottomLeftCorner);
            Assert.IsNotNull(topBorder);
            Assert.IsNotNull(rightBorder);

            //down
            MoveCorner(bottomLeftCorner, true, false, 0, 5000);
            Assert.IsTrue(bottomLeftCorner.Rect.Y <= Screen.PrimaryScreen.WorkingArea.Bottom);

            //up
            MoveCorner(bottomLeftCorner, true, false, 0, -5000);
            Assert.IsTrue(bottomLeftCorner.Rect.Y >= topBorder.Rect.Y);

            //down-right
            MoveCorner(bottomLeftCorner, true, false, 5000, 5000);
            Assert.IsTrue(bottomLeftCorner.Rect.Y <= Screen.PrimaryScreen.WorkingArea.Bottom);
            Assert.IsTrue(bottomLeftCorner.Rect.X <= rightBorder.Rect.X);

            //down-left
            MoveCorner(bottomLeftCorner, true, false, -5000, 5000);
            Assert.IsTrue(bottomLeftCorner.Rect.Y <= Screen.PrimaryScreen.WorkingArea.Bottom);
            Assert.IsTrue(bottomLeftCorner.Rect.X >= 0);

            //to the right
            MoveCorner(bottomLeftCorner, true, false, 5000, 0);
            Assert.IsTrue(bottomLeftCorner.Rect.X <= rightBorder.Rect.X);

            //to the left
            MoveCorner(bottomLeftCorner, true, false, -5000, 0);
            Assert.IsTrue(bottomLeftCorner.Rect.X >= 0);

            //up-left
            MoveCorner(bottomLeftCorner, true, false, -5000, -5000);
            Assert.IsTrue(bottomLeftCorner.Rect.Y >= topBorder.Rect.Y);
            Assert.IsTrue(bottomLeftCorner.Rect.X >= 0);

            //up-right
            MoveCorner(bottomLeftCorner, true, false, 5000, -5000);
            Assert.IsTrue(bottomLeftCorner.Rect.Y >= topBorder.Rect.Y);
            Assert.IsTrue(bottomLeftCorner.Rect.X <= rightBorder.Rect.X);
        }

        [TestMethod]
        public void MoveBottomRightCorner()
        {
            WindowsElement bottomRightCorner = session.FindElementByAccessibilityId("SEResize");
            WindowsElement topBorder = session.FindElementByAccessibilityId("NResize");
            WindowsElement leftBorder = session.FindElementByAccessibilityId("WResize");
            Assert.IsNotNull(bottomRightCorner);
            Assert.IsNotNull(topBorder);
            Assert.IsNotNull(leftBorder);

            //to the right
            MoveCorner(bottomRightCorner, false, false, 5000, 0);
            Assert.IsTrue(bottomRightCorner.Rect.X <= Screen.PrimaryScreen.WorkingArea.Right);

            //to the left
            MoveCorner(bottomRightCorner, false, false, -5000, 0);
            Assert.IsTrue(bottomRightCorner.Rect.X >= leftBorder.Rect.X);

            //down
            MoveCorner(bottomRightCorner, false, false, 0, 5000);
            Assert.IsTrue(bottomRightCorner.Rect.Y <= Screen.PrimaryScreen.WorkingArea.Bottom);

            //up
            MoveCorner(bottomRightCorner, false, false, 0, -5000);
            Assert.IsTrue(bottomRightCorner.Rect.Y >= topBorder.Rect.Y);

            //up-left
            MoveCorner(bottomRightCorner, false, false, -5000, -5000);
            Assert.IsTrue(bottomRightCorner.Rect.Y >= topBorder.Rect.Y);
            Assert.IsTrue(bottomRightCorner.Rect.X >= leftBorder.Rect.X);

            //up-right
            MoveCorner(bottomRightCorner, false, false, 5000, -5000);
            Assert.IsTrue(bottomRightCorner.Rect.Y >= topBorder.Rect.Y);
            Assert.IsTrue(bottomRightCorner.Rect.X <= Screen.PrimaryScreen.WorkingArea.Right);

            //down-right
            MoveCorner(bottomRightCorner, false, false, 5000, 5000);
            Assert.IsTrue(bottomRightCorner.Rect.Y <= Screen.PrimaryScreen.WorkingArea.Bottom);
            Assert.IsTrue(bottomRightCorner.Rect.X <= Screen.PrimaryScreen.WorkingArea.Right);

            //down-left
            MoveCorner(bottomRightCorner, false, false, -5000, 5000);
            Assert.IsTrue(bottomRightCorner.Rect.Y <= Screen.PrimaryScreen.WorkingArea.Bottom);
            Assert.IsTrue(bottomRightCorner.Rect.X >= leftBorder.Rect.X);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context, false);
            ResetSettings();

            if (!isPowerToysLaunched)
            {
                LaunchPowerToys();
            }
            OpenEditor();
            OpenCustomLayouts();

            //create canvas zone
            OpenCreatorWindow("Create new custom", "Custom layout creator");
            session.FindElementByAccessibilityId("newZoneButton").Click();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            new Actions(session).MoveToElement(session.FindElementByXPath("//Button[@Name=\"Cancel\"]")).Click().Perform();
            CloseEditor();
            TearDown();
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {
            
        }
    }
}