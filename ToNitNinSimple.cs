// See https://aka.ms/new-console-template for more information
using System;


void  ValidatePriceValue(int price){
    if (price < 1){
        throw new ArgumentException($"{price} is less than 1. Price can not be less than 1");
    }
    else if (price % 100 == 99){
        throw new ArgumentException($"{price} ends in 99. Price can not end in 99");
    }
}

int RoundedUpToHundreds (int num){
    return (int)(Math.Ceiling(num / 100.0) * 100) - 1;
}

int RoundedDownToHundreds  (int num){
    return (int)(Math.Floor(num / 100.0) * 100) - 1;
}

int ToNitNinPrice (int price){

    ValidatePriceValue(price);

    if (RoundedUpToHundreds(price) - price == price - RoundedDownToHundreds(price) || RoundedDownToHundreds(price) < 0 ){
        return RoundedUpToHundreds(price);
    }

    return RoundedUpToHundreds(price) - price < price - RoundedDownToHundreds(price) ?
            RoundedUpToHundreds(price) : RoundedDownToHundreds(price);
}

int singleInt = 255;
Console.WriteLine($"Price {singleInt} converted to the closest positive integer that ends in 99: {ToNitNinPrice(singleInt)}");
