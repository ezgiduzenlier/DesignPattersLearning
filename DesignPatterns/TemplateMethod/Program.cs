// iç içe onlarca if yazmaktansa bir şablon oluşturup her methodun içindeki her işlemin farklı durumlara göre farklı davranabilmesini sağlar.
// örneğin, kadın erkek ve çocuk için farklı hesaplama sistemi olan bi oyun.




ScoringAlgorithm algorithm;
Console.WriteLine("Mans");
algorithm = new MensScoringAlgorithm();
Console.WriteLine(algorithm.GenerateScore(10,new TimeSpan(0,2,10)));

Console.WriteLine("Women");
algorithm = new WomensScoringAlgorithm();
Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 10)));

Console.WriteLine("Children");
algorithm = new ChildrenScoringAlgorithm();
Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 10)));

Console.ReadLine();


abstract class ScoringAlgorithm
{
    public int GenerateScore(int hits, TimeSpan time)
    {
        int score = CalculateBaseScore(hits);// herkes için bu puan hesaplama sistemi
        int reduction = CalculateReduction(time);//puan kırma methodu
        return CalculateOverallScore(score, reduction); 
    }

    public abstract int CalculateOverallScore(int score, int reduction);
    public abstract int CalculateReduction(TimeSpan time);
    public abstract int CalculateBaseScore(int hits);
}
class MensScoringAlgorithm : ScoringAlgorithm
{
    public override int CalculateBaseScore(int hits)//her vurus 100 puan
    {
        return hits * 100;
    }

    public override int CalculateReduction(TimeSpan time)//toplam sürenin 5te 1i kadar kesinti olucak
    {
        return (int)time.TotalSeconds / 5;
    }

    public override int CalculateOverallScore(int score, int reduction)//sonuc
    {
        return score - reduction;
    }

}
class WomensScoringAlgorithm : ScoringAlgorithm
{
    public override int CalculateBaseScore(int hits)//her vurus 100 puan
    {
        return hits * 100;
    }

    public override int CalculateReduction(TimeSpan time)//toplam sürenin 5te 1i kadar kesinti olucak
    {
        return (int)time.TotalSeconds / 3;
    }

    public override int CalculateOverallScore(int score, int reduction)//sonuc
    {
        return score - reduction;
    }

}
class ChildrenScoringAlgorithm : ScoringAlgorithm
{
    public override int CalculateBaseScore(int hits)
    {
        return hits * 80;
    }

    public override int CalculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 2;
    }

    public override int CalculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

}