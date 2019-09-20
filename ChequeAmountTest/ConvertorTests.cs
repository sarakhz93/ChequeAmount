using System;
using Xunit;
using Autofac;
using ChequeAmount.Models;

namespace ChequeAmountTest
{
    public class ConvertorTests
    {
        private IContainer _autofacContainer;

        public ConvertorTests()
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<NumberToWordConvertor>().As<INumberToWordConvertor>().InstancePerLifetimeScope();

            var container = builder.Build();

            _autofacContainer = container;

        }

        [Theory]
        [InlineData("123.026", "One Hundred Twenty Three and Zero Two Six Paisa Only")]
        [InlineData("6543213.25", "Six Million Five Hundred Fourty Three Thousand Two Hundred Thirteen and Two Five Paisa Only")]
        [InlineData("123.021", "One Hundred Twenty Three and Zero Two One Paisa Only")]
         //[InlineData("000.000", " Only")]
        //[InlineData("000", "Zero Dollars :)")]
        //[InlineData(".00021", "Zero Dollars :)")]
        //[InlineData(".25", " Twenty Five Cents")]
        public void Convert_ValueSHouldBeConverted(string number, string expectedWords)
        {
            var convertor = _autofacContainer.Resolve<INumberToWordConvertor>();

            string actual = convertor.NumberToWords(number);

            Assert.Equal(expectedWords, actual);
        }
    }
}
