using BlazorArtGalleryAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BlazorArtGalleryAPITests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      var jsonstring = JsonConvert.SerializeObject(new User());
      
    }
  }
}
