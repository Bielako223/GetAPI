using httpclient;

ApiHelper.InitializeClient();

var ret = await ComicProcessor.LoadComic();

Console.WriteLine($"{ret.Num} {ret.Img}");
Console.ReadLine();


