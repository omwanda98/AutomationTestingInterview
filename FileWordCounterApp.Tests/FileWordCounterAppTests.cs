using System;
using Xunit;

namespace FileWordCounterApp.Tests
{
    public class FileWordCounterTests
    {
        [Theory]
        [InlineData("C:/Users/jay/Desktop/test/FileWordCounterApp.Tests/plain_text.txt")]
        [InlineData("C:/Users/jay/Desktop/test/FileWordCounterApp.Tests/sample.csv")]
        [InlineData("C:/Users/jay/Desktop/test/FileWordCounterApp.Tests/sample.json")]
        public void CountWordsInFile_ShouldNotThrowExceptionForValidInput(string filePath)
        {
            var wordCounter = new FileWordCounter();
            
            // This line will call the method and we are not asserting the count.
            wordCounter.CountWordsInFile(filePath);

            // If the method runs without exceptions, the test will pass.
        }

        [Theory]
        [InlineData("non_existent_file.txt")]
        [InlineData("unsupported_format.xls")]
        public void CountWordsInFile_ShouldThrowExceptionForInvalidInput(string filePath)
        {
            var wordCounter = new FileWordCounter();

            Assert.Throws<FileNotFoundException>(() => wordCounter.CountWordsInFile(filePath));
        }
    }
}
