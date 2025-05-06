// See https://aka.ms/new-console-template for more information
using Xunit;


class NitNinPrice {

    protected static int RoundedUpToHundreds (int num){
        return (int)(Math.Ceiling(num / 100.0) * 100) - 1;
    }

    protected static int RoundedDownToHundreds  (int num){
        return (int)(Math.Floor(num / 100.0) * 100) - 1;
    }

    protected static int ClosestNitNinToPrice (int price){

        if (RoundedUpToHundreds(price) - price == price - RoundedDownToHundreds(price) || RoundedDownToHundreds(price) < 0 ){
            return RoundedUpToHundreds(price);
        }

        return RoundedUpToHundreds(price) - price < price - RoundedDownToHundreds(price) ?
                RoundedUpToHundreds(price) : RoundedDownToHundreds(price);

    }

    private static void CheckPriceValue(int price){
        if (price < 1){
            throw new ArgumentException($"{price} is less than 1. Price can not be less than 1");
        }
        else if (price % 100 == 99){
            throw new ArgumentException($"{price} ends in 99. Price can not end in 99");
        }
    }

    public static int ToNitNinPrice(int price){
        CheckPriceValue(price);
        return ClosestNitNinToPrice(price);
    }

    public static List<int> ToNitNinPrice(List<int> price){
        List<int> result = [];
        foreach (int num in price)
        {
            CheckPriceValue(num);
            result.Add(ClosestNitNinToPrice(num));
        }
        return result;
    }

}




public class NitNinPriceTest
{
    [Theory]
    [InlineData(10, 99)]
    [InlineData(249, 299)]
    [InlineData(10000, 9999)]
    [InlineData(296, 299)]
    [InlineData(410, 399)]
    [InlineData(152, 199)]
    public void SingleIntInput(int input,int expectedOutput){
        int output = NitNinPrice.ToNitNinPrice(input);
        Assert.Equal(output, expectedOutput);
        
    }

    [Theory]
    [InlineData(new int[] { 244, 351, 3440, 5 }, new int[] { 199, 399, 3399, 99 })]
    [InlineData(new int[] { 5, 330, 20 }, new int[] { 99, 299, 99 })]
    [InlineData(new int[] { 6355 }, new int[] { 6399 })]
    public void ListIntInput(int[] input,int[] expectedOutput){

        List<int> output = NitNinPrice.ToNitNinPrice(new List<int>(input));
        Assert.Equal(output, expectedOutput);
        
    }

    [Fact]
    public void LessThanOneExcept(){
        Assert.Throws<ArgumentException>(() => NitNinPrice.ToNitNinPrice(0));
    }

    [Fact]
    public void EndInNitNinExceptV1(){
        Assert.Throws<ArgumentException>(() => NitNinPrice.ToNitNinPrice(99));
    }

    [Fact]
    public void EndInNitNinExceptV2(){
        Assert.Throws<ArgumentException>(() => NitNinPrice.ToNitNinPrice(399));
    }
}