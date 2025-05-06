// See https://aka.ms/new-console-template for more information

int singleInt = 51;
List<int> listInt = [244, 351, 3440, 5];

Console.WriteLine($"Price {singleInt} converted to the closest positive integer that ends in 99: {NitNinPrice.ToNitNinPrice(singleInt)}");

int i = 0;
foreach (int price in NitNinPrice.ToNitNinPrice(listInt)){
    Console.WriteLine($"Price {listInt[i]} converted to the closest positive integer that ends in 99: {price}");
    i++;
}

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
