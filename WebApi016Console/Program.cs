// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var url = "https://localhost:7295/Identity/Account/Login";

var httpClient = new HttpClient();
var content = httpClient.GetStringAsync(url).Result;

Console.WriteLine(content);

var form = new Dictionary<string, string>();
form.Add("Input.Email", "XXXXX");
form.Add("Input.Password", "XXXXX");
form.Add("_RequestVerifivationToken", "XXXXX");
form.Add("Input.RememberMe", "false");

var resutl = httpClient.PostAsync(url, new FormUrlEncodedContent(form)).Result;
Console.WriteLine(resutl);
