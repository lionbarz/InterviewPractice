using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class LruCacheTest
    {
        [TestMethod]
        public void TestCache()
        {
            LruCache<int, string> cache = new LruCache<int, string>(3);
            cache.Set(1, "Mohamed");
            cache.Set(2, "Tarek");
            cache.Set(3, "Yehia");
            Assert.IsNotNull(cache.Get(1));
            Assert.AreEqual("Mohamed", cache.Get(1));
            cache.Set(4, "Shadi");
            Assert.IsNull(cache.Get(2));
        }
    }
}
