using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardShuffler.Api.Controllers.Tests
{
    [TestClass()]
    public class CardControllerTests
    {       
        private CardController _controller { get; set; }
        public CardControllerTests() {
            _controller = new CardController();
        }

        [TestMethod()]
        public void ShufflerTestPrintCards()
        {
            var cardList = _controller.Shuffler(DataSeeder());
            foreach (var card in cardList) {
                Console.WriteLine("Card No." + card);
            }
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ShufflerTestCardCount() {     
            var cardList = _controller.Shuffler(DataSeeder());
            Console.WriteLine("Expected No. Of Cards is " + 52 + ". Actual number of card is " + cardList.Count);
            Assert.AreEqual(cardList.Count, 52);
        }

        [TestMethod()]
        public void ShufflerTestCardDuplicate()
        {

            var cardList = _controller.Shuffler(DataSeeder());
            var anyDuplicate = cardList.GroupBy(x => x).Any(g => g.Count() > 1);


            if (anyDuplicate == true)
            {
                Console.WriteLine("There is a duplicate within the set of cards.");
                Assert.Fail();
            }
            else { Assert.IsTrue(true); }
        }

        [TestMethod()]
        public void ShufflerTestLowestCardNo()
        {

            var cardList = _controller.Shuffler(DataSeeder());
            if (cardList.Min() != 1)
            {
                Console.WriteLine("Lowest card no must be 1");
                Assert.Fail();
            }
            else { Assert.IsTrue(true); }
        }
        [TestMethod()]
        public void ShufflerTestHighestCardNo()
        {

            var cardList = _controller.Shuffler(DataSeeder());
            if (cardList.Max() != 52)
            {
                Console.WriteLine("Lowest card no must be 1");
                Assert.Fail();
            }
            else { Assert.IsTrue(true); }
        }

        #region Test Data
        private IList<int> DataSeeder()
        {
            //Fill Data
            var CardList = new List<int>();
            for (int a = 1; a <= 52; a++)
            {
                CardList.Add(a);
            }
            return CardList;
        }
        #endregion
    }
}