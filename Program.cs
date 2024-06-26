using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 3!");

app.MapGet("/user", () => new {
    Name = "B. Carlos Almeida Capela",
    Cpf = "92097588204"
});

app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("teste", "Benedito Carlos");
    return new {
        Name = "B. Carlos Almeida Capela",
        Cpf = "92097588204"
    };
});

app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;
});

// Query Parametro
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

// Query Router
app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
    return code;
});

app.Run();

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}