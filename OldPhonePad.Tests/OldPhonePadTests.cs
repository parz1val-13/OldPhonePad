using Xunit;

namespace OldPhonePad.Tests
{
    public class OldPhonePadTests
    {
        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TUNGO")]
        [InlineData("222 2 22#", "CAB")]
        [InlineData("9999#", "Z")]
        [InlineData("1#", "&")]
        [InlineData("0#", " ")]
        [InlineData("", "")]
        public void Decode_ShouldReturnExpectedOutput(string input, string expected)
        {
            var result = OldPhonePad.PhonePad.Decode(input);
            Assert.Equal(expected, result);
        }
    }
}
