using FormProcessorApi.Controllers;
using FormProcessorApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace FormProcessorApi.Test
{
    [TestClass]
    public class ReportControllerTests
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var context = Substitute.For<FormDetailsContext>();
            var formController = new FormDetailsController(context);
            var rptController = new ReportController(context);

            await formController.PostFormDetails(new FormDetails()
            {
                Filename = "test1.png",
                TemplateId = 0,
                IsTemplate = true,
                Questions = new Question[]
                  {
                      new Question() {
                       Text = "What is your favorite color?" }
                  }
            });
        }
    }
}
