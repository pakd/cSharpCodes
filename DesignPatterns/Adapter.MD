# Adapter Pattern

The Adapter Design Pattern is a structural design pattern that allows objects with incompatible interfaces to work together. It acts as a bridge between two incompatible types by converting the interface of one class into an interface expected by the client.

# Example
```csharp

public interface IDisplayService
{
    void DisplayMenu(string xmlData);
    void DisplayRecommendation(string xmlData);
}

public class FancyUI
{
    public void ShowMenu(string jsonData)
    {
        Console.WriteLine("Fancy UI displaying menu: " + jsonData);
    }

    public void ShowRecommendation(string jsonData)
    {
        Console.WriteLine("Fancy UI displaying recommendation: " + jsonData);
    }
}

public class FancyUIAdapter : IDisplayService
{
    private readonly FancyUI fancyUI = new FancyUI();

    public void DisplayMenu(string xmlData)
    {
        string json = ConvertXmlToJson(xmlData);
        fancyUI.ShowMenu(json);
    }

    public void DisplayRecommendation(string xmlData)
    {
        string json = ConvertXmlToJson(xmlData);
        fancyUI.ShowRecommendation(json);
    }

    private string ConvertXmlToJson(string xmlData)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlData);
        return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
    }
}

class Program
{
    static void Main()
    {
        string xmlMenu = @"<menu><item>Pasta</item><item>Salad</item></menu>";
        string xmlRecommendation = @"<recommendation><item>Lasagna</item></recommendation>";

        IDisplayService displayService = new FancyUIAdapter();

        displayService.DisplayMenu(xmlMenu);
        displayService.DisplayRecommendation(xmlRecommendation);
    }
}

```

# Reference
1. https://www.youtube.com/watch?v=wA3keqCeKtM