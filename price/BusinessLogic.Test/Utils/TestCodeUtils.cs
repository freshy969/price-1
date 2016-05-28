using BusinessLogic.Utils;
using Xunit;

namespace BusinessLogic.Test.Utils
{
    [Collection("TestCodeUtils")]
    public class TestCodeUtils
    {
        [Fact]
        public void CreateCode_ReturnsCorrectCode()
        {
            Assert.Equal(null, CodeUtils.CreateCode(null));
            Assert.Equal(null, CodeUtils.CreateCode(""));
            Assert.Equal("kg", CodeUtils.CreateCode(" kg "));
            Assert.Equal("kg", CodeUtils.CreateCode("KG"));
            Assert.Equal("ces", CodeUtils.CreateCode(" Čęš "));
            Assert.Equal("kgas_(1)", CodeUtils.CreateCode("kg.as,(1)"));
            Assert.Equal("kg_as", CodeUtils.CreateCode("kg,    as"));
        }
    }
}
