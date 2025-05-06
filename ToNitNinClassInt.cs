// See https://aka.ms/new-console-template for more information
using System;

int singleInt = 0;

NitNinPrice nitninPrice = new(singleInt);
Console.WriteLine($"Price {singleInt} converted to the closest positive integer that ends in 99: {nitninPrice.ToNitNinPrice()}");


class NitNinPrice (int price ){

    public int Price { get; } = ValidatePriceValue(price);

    private static int  ValidatePriceValue(int _price){
        if (_price < 1){
            throw new ArgumentException($"{_price} is less than 1. Price can not be less than 1");
        }
        else if (_price % 100 == 99){
            throw new ArgumentException($"{_price} ends in 99. Price can not end in 99");
        }
        return _price;
    }

    protected  int RoundedUpToHundreds (){
        return (int)(Math.Ceiling(Price / 100.0) * 100) - 1;
    }

    protected int RoundedDownToHundreds  (){
        return (int)(Math.Floor(Price / 100.0) * 100) - 1;
    }

    public  int ToNitNinPrice (){

        if (RoundedUpToHundreds() - Price == Price - RoundedDownToHundreds() || RoundedDownToHundreds() < 0 ){
            return RoundedUpToHundreds();
        }

        return RoundedUpToHundreds() - Price < Price - RoundedDownToHundreds() ?
                RoundedUpToHundreds() : RoundedDownToHundreds();

    }


}
